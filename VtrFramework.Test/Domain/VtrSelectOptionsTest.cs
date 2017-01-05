using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtrFramework.Domain;

namespace VtrFramework.Test.Domain
{
    [TestFixture]
    public class VtrSelectOptionsTest
    {
        [Test]
        public void CreateTest()
        {
            var op = new VtrSelectOptions();

            op.id = "1";
            op.disable = false;
            op.text = "texto";

            Assert.AreEqual("1", op.id);
            Assert.AreEqual(false, op.disable);
            Assert.AreEqual("texto", op.text);
        }
    }
}
