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
        public static ISystemDatabase GetSystemDatabase()
        {
            IVtrConnectionStringProvider connStrProv = 
                VtrContext.IsInTest() ? 
                new VtrConnectionStringProviderDeTestes() as IVtrConnectionStringProvider : 
                new VtrAppConfigConnectionStringProvider() as IVtrConnectionStringProvider;

            return new VtrSystemDatabase(connStrProv);
        }
    }
}
