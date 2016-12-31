using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtrFramework.Domain;

namespace VtrFramework.Test.Domain
{
    [TestClass]
    public class HierarquicalParameterMicrosoftTest
    {
        [TestMethod]
        public void EqualsTest()
        {
            var lista = new HierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");
            var parametro2 = lista.Add(1, null, "D:");
            Assert.AreEqual(parametro1, parametro2);
            Assert.IsTrue(parametro1 == parametro2);
            Assert.IsTrue(parametro1.Equals(parametro2));
            Assert.IsFalse( object.ReferenceEquals(parametro1, parametro2));
        }

        


        [TestMethod]
        public void ReferenceEqualsTest()
        {
            var lista = new HierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");
            var parametro2 = lista[0];
            Assert.AreEqual(parametro1, parametro2);
            Assert.IsTrue(parametro1 == parametro2);
            Assert.IsTrue(parametro1.Equals(parametro2));
            Assert.IsTrue(object.ReferenceEquals(parametro1, parametro2));
        }





        [TestMethod]
        public void NotEqualsTest()
        {
            var lista = new HierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");
            var parametro2 = lista.Add(2, null, "D:");
            Assert.AreNotEqual(parametro1, parametro2);
            Assert.IsTrue(parametro1 != parametro2);
            Assert.IsFalse(parametro1 == parametro2);
            Assert.IsFalse(parametro1.Equals(parametro2));
        }



        [TestMethod]
        public void IntImplicitConversionTest()
        {
            var lista = new HierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");

            Assert.IsTrue(1.Equals(parametro1));
            Assert.IsTrue(parametro1.Equals(1));
            Assert.IsTrue(parametro1 == 1);
            Assert.IsTrue(1 == parametro1);

            Assert.AreEqual(parametro1, 1); //wtf
            Assert.AreEqual(1, parametro1); //wtf
        }



        [TestMethod]
        public void IntExplicitConversionTest()
        {
            var lista = new HierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");
            int id = (int) parametro1;
            Assert.AreEqual(1, id);
            Assert.AreEqual(1, (int)parametro1);
        }

        [TestMethod]
        public void StringImplicitConversionTest()
        {
            var lista = new HierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");

            Assert.IsTrue("C:".Equals(parametro1));
            Assert.IsTrue(parametro1.Equals("C:"));
            Assert.IsTrue(parametro1 == "C:");
            Assert.IsTrue("C:" == parametro1);

            Assert.AreEqual("C:", parametro1); //wtf
            Assert.AreEqual(parametro1, "C:"); //wtf
        }

        [TestMethod]
        public void StringExplicitConversionTest()
        {
            var lista = new HierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");
            string valor = parametro1;
            Assert.AreEqual("C:", valor);
            Assert.AreEqual("C:", (string)parametro1);
        }


    }
}
