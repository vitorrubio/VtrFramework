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
    public class VtrAppConfigConnectionStringProvider : IVtrConnectionStringProvider
    {
        /// <summary>
        /// retorna a connectionstring
        /// </summary>
        /// <returns></returns>
        public virtual string GetConnectionString()
        {
            //return @"Data Source=.\SQLEXPRESS;Initial Catalog=VtrTemplate;Persist Security Info=True;User ID=vitor;Password=vitor";

            return VtrContext.IsInTest() ?
            @"Data Source=.\SQLEXPRESS;Initial Catalog=VtrTemplate;Persist Security Info=True;User ID=vitor;Password=vitor" :
            System.Configuration.ConfigurationManager.ConnectionStrings["VtrTemplate"].ConnectionString;
        }


        /// <summary>
        /// retorna a connectionstring peno nome
        /// </summary>
        /// <returns></returns>
        public virtual string GetConnectionString(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentNullException("O nome da connection string não pode ser nulo");

            return VtrContext.IsInTest() ?
            @"Data Source=.\SQLEXPRESS;Initial Catalog=VtrTemplate;Persist Security Info=True;User ID=vitor;Password=vitor" :
            System.Configuration.ConfigurationManager.ConnectionStrings[nome].ConnectionString;
        }
    }
}
