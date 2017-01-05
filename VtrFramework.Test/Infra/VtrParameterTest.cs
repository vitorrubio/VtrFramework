using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtrFramework.Infra;

namespace VtrFramework.Test.Infra
{
    [TestFixture]
    public class VtrParameterTest
    {
        [Test]
        public void CreateIntTest()
        {
            var p1 = new VtrParameter("@parametro", 1);
            Assert.AreEqual("@parametro", p1.Nome);
            Assert.AreEqual(1, p1.Valor);
        }


        [Test]
        public void CreateStringTest()
        {
            var p1 = new VtrParameter("@parametro", "1");
            Assert.AreEqual("@parametro", p1.Nome);
            Assert.AreEqual("1", p1.Valor);
        }


        [Test]
        public void CreateByteArrayTest()
        {
            byte[] v1 = null;
            byte[] v2 = { };
            byte[] v3 = { 1 };

            var p1 = new VtrParameter("@parametro", v1); //se for nulo, a conversão automática não acontece, deve ser setado o tipo manualmente
            var p2 = new VtrParameter("@parametro", v2);
            var p3 = new VtrParameter("@parametro", v3);

            Assert.AreEqual("@parametro", p1.Nome);
            Assert.AreEqual(DBNull.Value, p1.Valor); //o tipo varbinary nunca pode ser null

            Assert.AreEqual("@parametro", p2.Nome);
            Assert.AreEqual(v2, p2.Valor);

            Assert.AreEqual("@parametro", p3.Nome);
            Assert.AreEqual(v3, p3.Valor);
  
        }

    }
}
