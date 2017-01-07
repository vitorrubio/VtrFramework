using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using VtrFramework.Infra;
using VtrFramework;

namespace VtrFramework.Infra
{


    /// <summary>
    /// representa um banco de dados de um sistema, delega todos os possíveis comandos a uma classe criada por DatabaseRequestFactory 
    /// que implemente IDatabaseRequest
    /// </summary> 
    public class VtrSystemDatabase : VtrBaseSystemDatabase, IVtrSystemDatabase
    {

        #region propriedades privadas

        private IVtrConnectionStringProvider _connectionStringProvider;
        private IVtrDatabaseRequest _dabaseRequest;

        #endregion





        #region constructors

        /// <summary>
        /// construtor padrão, aceita um IConnectionStringProvider, que definirá de onde vem a connection string
        /// </summary>
        /// <param name="connStrProvider"></param>
        public VtrSystemDatabase(IVtrConnectionStringProvider connStrProvider)
        {

            if (connStrProvider == null)
                throw new ArgumentNullException(ExceptionMessages.ConnectionStringProviderParameter, ExceptionMessages.NullConnectionsTringProviderExceptionMessage);

            if(string.IsNullOrWhiteSpace(connStrProvider.GetConnectionString()))
                throw new ArgumentNullException(ExceptionMessages.ConnectionStringParameter, ExceptionMessages.NullConnectionStringExceptionMessage);

            this._connectionStringProvider = connStrProvider;

            VtrDatabaseRequestFactory fac = new VtrDatabaseRequestFactory();
            this._dabaseRequest = fac.CreateDatabaseRequest(this._connectionStringProvider);

        }

        #endregion


        #region métodos públicos



        /// <summary>      
        /// Obtém a connection string para a configuração do sistema selecionado
        /// </summary>
        /// <returns></returns>
        public override string GetConnectionString()
        {
            return this._connectionStringProvider.GetConnectionString();
        }



        public override DataSet ExecuteProcedureGetDataset(string comando, params VtrParameter[] parametros)
        {
            return this._dabaseRequest.ExecuteProcedureGetDataset(comando, parametros);
        }

        public override DataTable ExecuteProcedureGetDataTable(string comando, params VtrParameter[] parametros)
        {
            return this._dabaseRequest.ExecuteProcedureGetDataTable(comando, parametros);

        }
        public override List<DataRow> ExecuteProcedureGetEnumerable(string comando, params VtrParameter[] parametros)
        {
            return this._dabaseRequest.ExecuteProcedureGetEnumerable(comando, parametros);
        }

        public override DataSet ExecuteQueryGetDataset(string comando, params VtrParameter[] parametros)
        {
            return this._dabaseRequest.ExecuteQueryGetDataset(comando, parametros);

        }

        public override DataTable ExecuteQueryGetDataTable(string comando, params VtrParameter[] parametros)
        {
            return this._dabaseRequest.ExecuteQueryGetDataTable(comando, parametros);
        }

        public override List<DataRow> ExecuteQueryGetEnumerable(string comando, params VtrParameter[] parametros)
        {
            return this._dabaseRequest.ExecuteQueryGetEnumerable(comando, parametros);
        }

        public override List<DataRow> Procedure(string proc, params VtrParameter[] parametros)
        {

            return this._dabaseRequest.Procedure(proc, parametros);
        }

        public override List<T> Procedure<T>(string comando, params VtrParameter[] parametros) /*where T : class, new()*/
        {
            return this._dabaseRequest.Procedure<T>(comando, parametros);
        }

        public override int? ProcedureNonQuery(string comando, params VtrParameter[] parametros)
        {
            return this._dabaseRequest.ProcedureNonQuery(comando, parametros);
        }

        public override List<DataRow> Query(string comando, params VtrParameter[] parametros)
        {
            return this._dabaseRequest.Query(comando, parametros);
        }

        public override List<T> Query<T>(string comando, params VtrParameter[] parametros) /*where T : class, new()*/
        {
            return this._dabaseRequest.Query<T>(comando, parametros);

        }

        public override int? SqlNonQuery(string comando, params VtrParameter[] parametros)
        {
            return this._dabaseRequest.SqlNonQuery(comando, parametros);
        }


        #endregion

    }

}
