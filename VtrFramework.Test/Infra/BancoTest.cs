using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using VtrFramework.Infra;

namespace VtrFramework.Test.Infra
{
    [TestFixture]
    public class BancoTest
    {
        [Test]
        public void CreateTest()
        {
            var bco = new SystemDatabase(new ConnectionStringProviderDeTestes());
            string srvname = bco.Query ("select @@servername as name")[0]["name"].ToString();
            Assert.IsNotEmpty(srvname);
            Console.WriteLine(srvname);
        }
    }
}
