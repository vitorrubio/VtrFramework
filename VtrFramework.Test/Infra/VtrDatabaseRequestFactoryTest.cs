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
    public class VtrDatabaseRequestFactoryTest
    {
        [Test]
        public void CreateDatabaseRequestTest()
        {
            VtrDatabaseRequestFactory fac = new VtrDatabaseRequestFactory();
            var dbrec = fac.CreateDatabaseRequest(new VtrConnectionStringProviderDeTestes());
            Assert.IsNotNull(dbrec);
            Assert.IsInstanceOf<IVtrDatabaseRequest>(dbrec);
        }
    }
}
