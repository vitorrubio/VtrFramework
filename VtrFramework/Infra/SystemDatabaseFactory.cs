using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace VtrFramework.Infra
{
    /// <summary>
    /// fábrica de contextos de sistemas
    /// </summary>
    public static class SystemDatabaseFactory
    {
        
        /// <summary>
        /// Cria uma instância de SystemDatabase de acordo com as configurações
        /// </summary>
        /// <returns></returns>
        public static ISystemDatabase GetSystemDatabase()
        {
            IConnectionStringProvider connStrProv = 
                Contexto.IsInTest() ? 
                new ConnectionStringProviderDeTestes() as IConnectionStringProvider : 
                new AppConfigConnectionStringProvider() as IConnectionStringProvider;

            return new SystemDatabase(connStrProv);
        }
    }
}
