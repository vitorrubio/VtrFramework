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
    public class VtrMsSqlDatabaseRequestTest
    {
        [Test]
        public void CreateTest()
        {
            var prov = new VtrTestConnectionStringProvider();
            var req = new VtrMsSqlDatabaseRequest(prov);
        }


        [Test]
        public void QueryTest()
        {
            var prov = new VtrTestConnectionStringProvider();
            var req = new VtrMsSqlDatabaseRequest(prov);
            var dados = req.Query("select @@VERSION");
            Console.WriteLine(dados[0][0]);
        }
    }
}
