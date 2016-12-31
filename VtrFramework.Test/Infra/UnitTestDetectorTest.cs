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
    public class UnitTestDetectorTest
    {
        [Test]
        public void IsInTestTest()
        {

            Assert.IsTrue(UnitTestDetector.IsInTest());

        }
    }
}
