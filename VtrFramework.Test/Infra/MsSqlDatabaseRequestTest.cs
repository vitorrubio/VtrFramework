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
    public class MsSqlDatabaseRequestTest
    {
        [Test]
        public void CreateTest()
        {
            var prov = new ConnectionStringProviderDeTestes();
            var req = new MsSqlDatabaseRequest(prov);
        }


        [Test]
        public void QueryTest()
        {
            var prov = new ConnectionStringProviderDeTestes();
            var req = new MsSqlDatabaseRequest(prov);
            var dados = req.Query("select @@VERSION");
            Console.WriteLine(dados[0][0]);
        }
    }
}
