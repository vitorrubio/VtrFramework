using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtrFramework.Infra;

namespace VtrFramework.Test.Infra
{
    [TestFixture]
    public class ConnectionStringProviderTest
    {
        [Test]
        [Description("Verifica se está trazendo a connection string do ambiente de teste")]
        public void GetConnectionStringTest()
        {
            ConnectionStringProviderDeTestes prov = new ConnectionStringProviderDeTestes();
            Assert.AreEqual(@"Data Source=.\SQLEXPRESS;Initial Catalog=VtrTemplate;Persist Security Info=True;User ID=vitor;Password=vitor", prov.GetConnectionString());
        }
    }
}
