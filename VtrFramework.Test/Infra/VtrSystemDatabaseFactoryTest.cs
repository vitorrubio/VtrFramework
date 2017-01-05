using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VtrFramework.Infra;

namespace VtrFramework.Test.Infra
{
    [TestFixture]
    public class VtrSystemDatabaseFactoryTest
    {
        [Test]
        public void GetSystemDatabaseTest()
        {
            var sysdt = VtrSystemDatabaseFactory.GetSystemDatabase();
            Assert.IsInstanceOf<ISystemDatabase>(sysdt);
        }
    }
}
