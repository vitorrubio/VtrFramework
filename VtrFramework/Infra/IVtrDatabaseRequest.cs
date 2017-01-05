using System.Collections.Generic;
using System.Data;

namespace VtrFramework.Infra
{
    public interface IVtrDatabaseRequest
    {
        DataSet ExecuteProcedureGetDataset(string comando, params VtrParameter[] parametros);
        DataTable ExecuteProcedureGetDataTable(string comando, params VtrParameter[] parametros);
        List<DataRow> ExecuteProcedureGetEnumerable(string comando, params VtrParameter[] parametros);
        DataSet ExecuteQueryGetDataset(string comando, params VtrParameter[] parametros);
        DataTable ExecuteQueryGetDataTable(string comando, params VtrParameter[] parametros);
        List<DataRow> ExecuteQueryGetEnumerable(string comando, params VtrParameter[] parametros);
        List<DataRow> Procedure(string proc, params VtrParameter[] parametros);
        List<T> Procedure<T>(string comando, params VtrParameter[] parametros) where T : class, new();
        int? ProcedureNonQuery(string comando, params VtrParameter[] parametros);
        List<DataRow> Query(string comando, params VtrParameter[] parametros);
        List<T> Query<T>(string comando, params VtrParameter[] parametros) where T : class, new();
        int? SqlNonQuery(string comando, params VtrParameter[] parametros);
    }
}