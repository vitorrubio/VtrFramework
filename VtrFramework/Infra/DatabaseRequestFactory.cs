using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtrFramework.Infra
{
    public class DatabaseRequestFactory
    {
        public virtual IDatabaseRequest CreateDatabaseRequest(IConnectionStringProvider connStrProv)
        {
            //todo: colocar a lógica para possíveis outros bancos de dados aqui
            return new MsSqlDatabaseRequest(connStrProv);
        }
    }
}
