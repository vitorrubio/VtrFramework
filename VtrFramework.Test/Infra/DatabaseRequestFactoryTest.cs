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
    public class DatabaseRequestFactoryTest
    {
        [Test]
        public void CreateDatabaseRequestTest()
        {
            DatabaseRequestFactory fac = new DatabaseRequestFactory();
            var dbrec = fac.CreateDatabaseRequest(new ConnectionStringProviderDeTestes());
            Assert.IsNotNull(dbrec);
            Assert.IsInstanceOf<IDatabaseRequest>(dbrec);
        }
    }
}
