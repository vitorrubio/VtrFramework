using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtrFramework.MetaData;

namespace VtrFramework.MetaData.Test
{
    [TestFixture]
    public class VtrTableTest
    {
        [Test]
        public void CreateTest()
        {
            VtrTable obj = new VtrTable();
            Assert.IsNotNull(obj);
        }
    }
}
