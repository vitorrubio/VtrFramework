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
    public class VtrFieldTest
    {
        [Test]
        public void CreateTest()
        {
            VtrField field = new VtrField(new VtrTable());
            Assert.IsNotNull(field);
        }
    }
}
