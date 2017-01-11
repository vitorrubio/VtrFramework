using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtrFramework.Infra
{
    public class VtrLiteralConnectionStringProvider : IVtrConnectionStringProvider
    {
        private readonly string _connectionString;
        public VtrLiteralConnectionStringProvider(string connStr)
        {
            this._connectionString = connStr;
        }

        public virtual string GetConnectionString()
        {
            return _connectionString;
        }

        public virtual string GetConnectionString(string nome)
        {
            System.Diagnostics.Debug.WriteLine("Parametro nome ignorado nesta classe");
            System.Diagnostics.Trace.WriteLine("Parametro nome ignorado nesta classe");
            return _connectionString;
        }
    }
}
