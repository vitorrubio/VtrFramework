using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using VtrFramework.Infra;

namespace VtrFramework.Test.Infra
{
    [TestFixture]
    public class VtrDatabaseTest
    {
        [Test]
        public void CreateTest()
        {
            var bco = new VtrSystemDatabase(new VtrAppConfigConnectionStringProvider());
            string srvname = bco.Query ("select @@servername as name")[0]["name"].ToString();
            Assert.IsNotEmpty(srvname);
            Console.WriteLine(srvname);
        }
    }
}
