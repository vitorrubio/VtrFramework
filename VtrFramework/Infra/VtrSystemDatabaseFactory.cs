using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace VtrFramework.Infra
{
    /// <summary>
    /// fábrica de contextos de sistemas
    /// </summary>
    public static class VtrSystemDatabaseFactory
    {
        
        /// <summary>
        /// Cria uma instância de SystemDatabase de acordo com as configurações
        /// </summary>
        /// <returns></returns>
        public static IVtrSystemDatabase GetSystemDatabase()
        {
            IVtrConnectionStringProvider connStrProv = 
                VtrContext.IsInTest() ? 
                new VtrTestConnectionStringProvider() as IVtrConnectionStringProvider : 
                new VtrAppConfigConnectionStringProvider() as IVtrConnectionStringProvider;

            return new VtrSystemDatabase(connStrProv);
        }
    }
}
