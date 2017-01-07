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
    public class VtrForeignKeyTest
    {
        [Test]
        public void CreateTest()
        {
            VtrForeignKey obj = new VtrForeignKey();
            Assert.IsNotNull(obj);
        }
    }
}
