using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VtrFramework.Infra;

namespace VtrFramework.Test.Infra
{
    [TestFixture]
    public class SystemDatabaseTest
    {
        [Test]
        public void QueryTest()
        {
            string query = "select db_name()";


            var sdDev = new SystemDatabase(new ConnectionStringProviderDeTestes() );
            Assert.AreEqual("vtrtemplate", sdDev.Query(query)[0][0].ToString().ToLower()); 

        }



    }
}
