using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VtrFramework.Infra;

namespace VtrFramework.Test.Infra
{
    [TestFixture]
    public class VtrSystemDatabaseTest
    {
        [Test]
        public void QueryTest()
        {
            string query = "select db_name()";


            var sdDev = new VtrSystemDatabase(new VtrAppConfigConnectionStringProvider() );
            Assert.AreEqual("vtrtemplate", sdDev.Query(query)[0][0].ToString().ToLower()); 

        }



    }
}
