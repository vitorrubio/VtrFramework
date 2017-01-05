using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtrFramework.Infra
{
    /// <summary>
    /// implementa a interface IConnectionStringProvider provendo uma connectionstring fixa para testes
    /// </summary>
    public class VtrConnectionStringProviderDeTestes : IVtrConnectionStringProvider
    {
        /// <summary>
        /// retorna a connectionstring
        /// </summary>
        /// <returns></returns>
        public virtual string GetConnectionString()
        {

            return @"Data Source=.\SQLEXPRESS;Initial Catalog=VtrTemplate;Persist Security Info=True;User ID=vitor;Password=vitor";

        }
    }
}
