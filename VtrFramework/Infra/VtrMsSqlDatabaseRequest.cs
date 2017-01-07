using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Reflection;





namespace VtrFramework.Infra
{



    /// <summary>
    /// classe de infraestrutura para criação de conexão e objetos de query e acesso direto ao banco de dados
    /// </summary>
    public class VtrMsSqlDatabaseRequest : IVtrDatabaseRequest
    {

        #region campos privados

        private IVtrConnectionStringProvider _connStrProvider;


        #endregion





        #region constructors

        /// <summary>
        /// constructor padrão aceita a conection string tirada de um objeto Sistema ou de resources da dll ou de constantes
        /// </summary>
        /// <param name="connectionString">string - parâmetros de conexão completos do sistema com o pwd já decriptado</param>
        public VtrMsSqlDatabaseRequest(IVtrConnectionStringProvider connStrProv)
        {

            if (connStrProv == null)
                throw new ArgumentNullException(ExceptionMessages.ConnectionStringProviderParameter, ExceptionMessages.NullConnectionsTringProviderExceptionMessage);

            if (string.IsNullOrWhiteSpace(connStrProv.GetConnectionString()))
                throw new ArgumentNullException(ExceptionMessages.ConnectionStringParameter, ExceptionMessages.NullConnectionStringExceptionMessage);

            _connStrProvider = connStrProv;

        }

        #endregion




        #region métodos públicos para execução de comandos e procedures


        /// <summary>
        /// Executa uma procedure no banco de dados com vários parâmetros retornando um Dataset
        /// serve para aplicações que fazem comandos através de procedures
        /// </summary>
        /// <param name="comando"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public virtual System.Data.DataSet ExecuteProcedureGetDataset(string comando, params VtrParameter[] parametros)
        {
            return this.ExecuteSqlGetDataset(comando, CommandType.StoredProcedure, parametros);
        }

        /// <summary>
        /// Executa um comando no banco de dados com vários parâmetros retornando um Dataset
        /// para sistemas que executam queries ad hoc
        /// </summary>
        /// <param name="comando"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public virtual System.Data.DataSet ExecuteQueryGetDataset(string comando, params VtrParameter[] parametros)
        {
            return this.ExecuteSqlGetDataset(comando, CommandType.Text, parametros);
        }

        /// <summary>
        /// Executa o método ExecuteProcedureGetDataset extraindo a primeira tabela
        /// </summary>
        /// <param name="comando"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public virtual DataTable ExecuteProcedureGetDataTable(string comando, params VtrParameter[] parametros)
        {
            var result = this.ExecuteProcedureGetDataset(comando, parametros);
            if (result.Tables.Count > 0)
                return result.Tables[0];
            else
                return null;
        }

        /// <summary>
        /// executa o método ExecuteQueryGetDataset e traz a primeira tabela
        /// </summary>
        /// <param name="comando"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public virtual DataTable ExecuteQueryGetDataTable(string comando, params VtrParameter[] parametros)
        {
            var result = this.ExecuteQueryGetDataset(comando, parametros);
            if (result.Tables.Count > 0)
                return result.Tables[0];
            else
                return null;
        }

        /// <summary>
        /// executa  ExecuteProcedureGetDataTable e traz os resultados como enumerable
        /// </summary>
        /// <param name="comando"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public virtual List<DataRow> ExecuteProcedureGetEnumerable(string comando, params VtrParameter[] parametros)
        {
            var result = this.ExecuteProcedureGetDataTable(comando, parametros);
            if (result != null)
                return result.AsEnumerable().ToList<DataRow>();
            else
                return null;
        }

        /// <summary>
        /// executa a ExecuteQueryGetDataTable e traz enumerable
        /// </summary>
        /// <param name="comando"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public virtual List<DataRow> ExecuteQueryGetEnumerable(string comando, params VtrParameter[] parametros)
        {
            var result = this.ExecuteQueryGetDataTable(comando, parametros);
            if (result != null)
                return result.AsEnumerable().ToList<DataRow>();
            else
                return null;
        }

        /// <summary>
        /// Executa qualquer query com uma lista de parâmetros e traz o resultado como uma lista de DataRow
        /// </summary>
        /// <param name="comando"></param>
        /// <param name="parametros"></param>
        /// <returns>lista de DataRow</returns>
        public virtual List<DataRow> Query(string comando, params VtrParameter[] parametros)
        {
            var resultado = new List<DataRow>();

            var dados = this.ExecuteQueryGetEnumerable(comando, parametros);

            if ((dados!=null) && (dados.Count > 0))
            {
                resultado.AddRange(dados);
            }

            return resultado;
        }

        /// <summary>
        /// Executa qualquer procedure com uma lista de parâmetros e traz o resultado como uma lista de DataRow
        /// </summary>
        /// <param name="comando"></param>
        /// <param name="parametros"></param>
        /// <returns>lista de DataRow</returns>
        public virtual List<DataRow> Procedure(string proc, params VtrParameter[] parametros)
        {

            var resultado = new List<DataRow>();

            var dados = this.ExecuteProcedureGetEnumerable(proc, parametros);

            if ((dados != null) && (dados.Count > 0))
            {
                resultado.AddRange(dados);
            }

            return resultado;
        }

        /// <summary>
        /// Executa uma query com a lista de parâmetros e traz o resultset na forma de uma List T generico
        /// </summary>
        /// <typeparam name="T">Tipo da lista de retorno</typeparam>
        /// <param name="comando">comando sql ad hoc</param>
        /// <param name="parametros">parametros do tipo Parametro() infinitos</param>
        /// <returns>lista de T</returns>
        public virtual List<T> Query<T>(string comando, params VtrParameter[] parametros) where T : class, new()
        {
            List<T> resultado = new List<T>();
            resultado.AddRange(this.DataRowsToEntityByReflection<T>(Query(comando, parametros)));
            return resultado;
        }

        /// <summary>
        /// Executa uma procedure com a lista de parâmetros  e traz o resultset como uma List generica do tipo T
        /// </summary>
        /// <typeparam name="T">Tipo da lista de retorno</typeparam>
        /// <param name="comando">procedure sql</param>
        /// <param name="parametros">parametros do tipo Parametro() infinitos</param>
        /// <returns>lista de T</returns>
        public virtual List<T> Procedure<T>(string comando, params VtrParameter[] parametros) where T : class, new()
        {
            List<T> resultado = new List<T>();
            resultado.AddRange(this.DataRowsToEntityByReflection<T>(Procedure(comando, parametros)));
            return resultado;
        }






        #region nonquery commands / commandos without resultset (comandos não query - sem resultset)

        /// <summary>
        /// Executa um comando sql sem retrornar um resultset
        /// </summary>
        /// <param name="comando"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public virtual int? SqlNonQuery(string comando, params VtrParameter[] parametros)
        {
            return this.ExecuteSqlNonQuery(comando, CommandType.Text, parametros);
        }

        /// <summary>
        /// Executa uma procedure sem retornar um resultset
        /// </summary>
        /// <param name="comando"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public virtual int? ProcedureNonQuery(string comando, params VtrParameter[] parametros)
        {
            return this.ExecuteSqlNonQuery(comando, CommandType.StoredProcedure, parametros);
        }

        #endregion

        #endregion






        #region métodos privados


        /// <summary>
        /// executa um comando SQL com vários parâmetros passando-se o tipo de comando
        /// </summary>
        /// <param name="comando">comando a ser executado</param>
        /// <param name="commType">tipo de comando</param>
        /// <param name="parametros">lista de parâmetros</param>
        /// <returns></returns>
        private System.Data.DataSet ExecuteSqlGetDataset(string comando, System.Data.CommandType commType, params VtrParameter[] parametros)
        {

            if (string.IsNullOrEmpty(comando))
                throw new ArgumentException(ExceptionMessages.NullCommand);

            

            DataSet ds = new System.Data.DataSet();

            SqlConnection conn = new SqlConnection(_connStrProvider.GetConnectionString());

            SqlCommand cmd = new SqlCommand(comando, conn);

            if (commType == CommandType.StoredProcedure)
            {
                cmd.CommandType = commType;
            }
            else if (commType == CommandType.Text)
            {
                cmd.CommandType = commType;
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCommandType);
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);


            foreach (VtrParameter item in parametros)
            {
                //salvaguarda para substituir null por DBNull mesmo se usado por outras bibliotecas mais antigas.
                SqlParameter sqlParam = cmd.Parameters.AddWithValue(item.Nome, item.Valor ?? DBNull.Value);
                sqlParam.SqlDbType = ((item != null) && (item.Valor != null) && (item.Valor != DBNull.Value)) ? VtrTypeServices.DotNetTypeToSqlDbType(item.Valor.GetType()) :SqlDbType.NVarChar;
            }

            try
            {
                da.Fill(ds, "Dados");
            }
            catch (Exception err)
            {

                string nomeApp = Assembly.GetExecutingAssembly().GetName().Name;
                string versionApp = Assembly.GetExecutingAssembly().GetName().Version.Major.ToString();
                string connStr = _connStrProvider.GetConnectionString();

                var texto = string.Format("Erro ao tentar conectar-se ao banco de dados. Sistema:{0}, Versão:{1}, ConnectionString:{2}, erro:{3}", nomeApp, versionApp, connStr, err.ToString());

                //todo: logar o erro aqui

                throw new Exception(texto + err.Message, err);
            }
            finally
            {
                conn.Close();
            }
            return ds;

        }



        /// <summary>
        /// executa um comando sql não query e traz os resultados afetados
        /// ideal para comandos que não trazem resultset
        /// </summary>
        /// <param name="comando">comando a ser executado</param>
        /// <param name="commType">tipo de comando</param>
        /// <param name="parametros">lista de parâmetros</param>
        /// <returns></returns>
        private int? ExecuteSqlNonQuery(string comando, System.Data.CommandType commType, params VtrParameter[] parametros)
        {

            int? resultado = null;

            if (string.IsNullOrEmpty(comando))
                throw new ArgumentException(ExceptionMessages.NullCommand);



            SqlConnection conn = new SqlConnection(_connStrProvider.GetConnectionString());
            SqlCommand comm = new SqlCommand(comando, conn);


            if (commType == CommandType.StoredProcedure)
            {
                comm.CommandType = commType;
            }
            else if (commType == CommandType.Text)
            {
                comm.CommandType = commType;
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCommandType);
            }

            foreach (VtrParameter item in parametros)
            {
                //salvaguarda para substituir null por DBNull mesmo se usado por outras bibliotecas mais antigas.
                SqlParameter sqlParam = comm.Parameters.AddWithValue(item.Nome, item.Valor ?? DBNull.Value);
                sqlParam.SqlDbType = ((item != null) && (item.Valor != null) && (item.Valor != DBNull.Value)) ? VtrTypeServices.DotNetTypeToSqlDbType(item.Valor.GetType()) : SqlDbType.NVarChar;
            }

            try
            {
                conn.Open();
                resultado = comm.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                string nomeApp = Assembly.GetExecutingAssembly().GetName().Name;
                string versionApp = Assembly.GetExecutingAssembly().GetName().Version.Major.ToString();
                string connStr = _connStrProvider.GetConnectionString();

                var texto = string.Format("Erro ao tentar conectar-se ao banco de dados. Sistema:{0}, Versão:{1}, ConnectionString:{2}, erro:{3}", nomeApp, versionApp, connStr, err.ToString());

                //todo: logar o erro aqui

                throw new Exception(texto + err.Message, err);
            }
            finally
            {
                conn.Close();
            }
            return resultado;
        }



        /// <summary>
        /// usa reflection para converter de datarows para o tipo generico
        /// </summary>
        /// <typeparam name="T">Tipo da lista de retorno</typeparam>
        /// <param name="resultado">Lista de DataRows</param>
        /// <param name="dados">lista de T</param>
        private List<T> DataRowsToEntityByReflection<T>(List<DataRow> dados) where T : class, new()
        {
            List<T> resultado = new List<T>();

            if ((dados != null) && (dados.Count > 0))
            {
                var propriedades = typeof(T).GetProperties();
                foreach (DataRow d in dados)
                {
                    T item = new T();

                    foreach (DataColumn c in d.Table.Columns)
                    {

                        var prop = propriedades.Where(p => p.Name == c.ColumnName).FirstOrDefault();
                        if (prop != null)
                        {
                            //tipos valor
                            if (prop.PropertyType.IsValueType)
                            {
                                //tipos nao nulaveis
                                if (prop.PropertyType == typeof(Int16))
                                {
                                    prop.SetValue(item, VtrConvert.ToInteger(d[c]), null);
                                }
                                else if (prop.PropertyType == typeof(Int32))
                                {
                                    prop.SetValue(item, VtrConvert.ToInteger(d[c]), null);
                                }
                                else if (prop.PropertyType == typeof(Int64))
                                {
                                    prop.SetValue(item, VtrConvert.ToInt64(d[c]), null);
                                }
                                else if (prop.PropertyType == typeof(long))
                                {
                                    prop.SetValue(item, VtrConvert.ToInt64(d[c]), null);
                                }
                                else if (prop.PropertyType == typeof(int))
                                {
                                    prop.SetValue(item, VtrConvert.ToInteger(d[c]), null);
                                }
                                else if (prop.PropertyType == typeof(DateTime))
                                {
                                    prop.SetValue(item, VtrConvert.ToDateTime(d[c]), null);
                                }
                                else if (prop.PropertyType == typeof(byte))
                                {
                                    prop.SetValue(item, VtrConvert.ToInteger(d[c]), null);
                                }
                                else if (prop.PropertyType == typeof(decimal))
                                {
                                    prop.SetValue(item, VtrConvert.ToDouble(d[c]), null);
                                }
                                else if (prop.PropertyType == typeof(float))
                                {
                                    prop.SetValue(item, VtrConvert.ToDouble(d[c]), null);
                                }
                                else if (prop.PropertyType == typeof(double))
                                {
                                    prop.SetValue(item, VtrConvert.ToDouble(d[c]), null);
                                }
                                else if (prop.PropertyType == typeof(bool))
                                {
                                    prop.SetValue(item, VtrConvert.ToBool(d[c]), null);
                                }


                                //tipos nulaveis
                                else if (Nullable.GetUnderlyingType(prop.PropertyType) == typeof(Int16))
                                {
                                    prop.SetValue(item, VtrConvert.ToNullableInteger(d[c]), null);
                                }
                                else if (Nullable.GetUnderlyingType(prop.PropertyType) == typeof(Int32))
                                {
                                    prop.SetValue(item, VtrConvert.ToNullableInteger(d[c]), null);
                                }
                                else if (Nullable.GetUnderlyingType(prop.PropertyType) == typeof(Int64))
                                {
                                    prop.SetValue(item, VtrConvert.ToNullableInt64(d[c]), null);
                                }
                                else if (Nullable.GetUnderlyingType(prop.PropertyType) == typeof(long))
                                {
                                    prop.SetValue(item, VtrConvert.ToNullableInt64(d[c]), null);
                                }
                                else if (Nullable.GetUnderlyingType(prop.PropertyType) == typeof(int))
                                {
                                    prop.SetValue(item, VtrConvert.ToNullableInteger(d[c]), null);
                                }
                                else if (Nullable.GetUnderlyingType(prop.PropertyType) == typeof(DateTime))
                                {
                                    prop.SetValue(item, VtrConvert.ToNullableDateTime(d[c]), null);
                                }
                                else if (Nullable.GetUnderlyingType(prop.PropertyType) == typeof(byte))
                                {
                                    prop.SetValue(item, VtrConvert.ToNullableInteger(d[c]), null);
                                }
                                else if (Nullable.GetUnderlyingType(prop.PropertyType) == typeof(decimal))
                                {
                                    prop.SetValue(item, VtrConvert.ToNullableDouble(d[c]), null);
                                }
                                else if (Nullable.GetUnderlyingType(prop.PropertyType) == typeof(float))
                                {
                                    prop.SetValue(item, VtrConvert.ToNullableDouble(d[c]), null);
                                }
                                else if (Nullable.GetUnderlyingType(prop.PropertyType) == typeof(double))
                                {
                                    prop.SetValue(item, VtrConvert.ToNullableDouble(d[c]), null);
                                }
                                else if (prop.PropertyType == typeof(bool))
                                {
                                    prop.SetValue(item, VtrConvert.ToNullableBool(d[c]), null);
                                }
                            }

                            else //tipos referencia
                            {
                                if (prop.PropertyType == typeof(string))
                                {
                                    prop.SetValue(item, d[c].ToString(), null);
                                }
                                else
                                {
                                    prop.SetValue(item, d[c], null);
                                }
                            }
                        }
                    }

                    resultado.Add(item);
                }
            }

            return resultado;
        }


        #endregion


    }
}
