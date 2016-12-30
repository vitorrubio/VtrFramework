using System.Collections.Generic;
using System.Data;

namespace VtrFramework.Infra
{
    public interface IDatabaseRequest
    {
        DataSet ExecuteProcedureGetDataset(string comando, params Parametro[] parametros);
        DataTable ExecuteProcedureGetDataTable(string comando, params Parametro[] parametros);
        List<DataRow> ExecuteProcedureGetEnumerable(string comando, params Parametro[] parametros);
        DataSet ExecuteQueryGetDataset(string comando, params Parametro[] parametros);
        DataTable ExecuteQueryGetDataTable(string comando, params Parametro[] parametros);
        List<DataRow> ExecuteQueryGetEnumerable(string comando, params Parametro[] parametros);
        List<DataRow> Procedure(string proc, params Parametro[] parametros);
        List<T> Procedure<T>(string comando, params Parametro[] parametros) where T : class, new();
        int? ProcedureNonQuery(string comando, params Parametro[] parametros);
        List<DataRow> Query(string comando, params Parametro[] parametros);
        List<T> Query<T>(string comando, params Parametro[] parametros) where T : class, new();
        int? SqlNonQuery(string comando, params Parametro[] parametros);
    }
}