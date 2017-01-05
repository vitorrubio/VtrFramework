using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtrFramework.Infra
{
    public class VtrDatabaseRequestFactory
    {
        public virtual IVtrDatabaseRequest CreateDatabaseRequest(IVtrConnectionStringProvider connStrProv)
        {
            //todo: colocar a lógica para possíveis outros bancos de dados aqui
            return new VtrMsSqlDatabaseRequest(connStrProv);
        }
    }
}
