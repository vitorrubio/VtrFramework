using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using VtrFramework.Infra;

namespace VtrFramework.Infra
{
    public abstract class BaseSystemDatabase : ISystemDatabase
    {


        #region métodos públicos

        /// <summary>
        /// Obtém a connection string para a configuração do sistema selecionado
        /// </summary>
        /// <returns></returns>
        public abstract string GetConnectionString();

        public abstract DataSet ExecuteProcedureGetDataset(string comando, params Parametro[] parametros);
        public abstract DataTable ExecuteProcedureGetDataTable(string comando, params Parametro[] parametros);
        public abstract List<DataRow> ExecuteProcedureGetEnumerable(string comando, params Parametro[] parametros);
        public abstract DataSet ExecuteQueryGetDataset(string comando, params Parametro[] parametros);
        public abstract DataTable ExecuteQueryGetDataTable(string comando, params Parametro[] parametros);
        public abstract List<DataRow> ExecuteQueryGetEnumerable(string comando, params Parametro[] parametros);
        public abstract List<DataRow> Procedure(string proc, params Parametro[] parametros);
        public abstract List<T> Procedure<T>(string comando, params Parametro[] parametros) where T : class, new();
        public abstract int? ProcedureNonQuery(string comando, params Parametro[] parametros);
        public abstract List<DataRow> Query(string comando, params Parametro[] parametros);
        public abstract List<T> Query<T>(string comando, params Parametro[] parametros) where T : class, new();
        public abstract int? SqlNonQuery(string comando, params Parametro[] parametros);

        #endregion


    }
}
