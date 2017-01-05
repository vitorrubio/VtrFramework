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
    public class VtrHierarchicalParameterMicrosoftTest
    {
        [TestMethod]
        public void EqualsTest()
        {
            var lista = new VtrHierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");
            var parametro2 = lista.Add(1, null, "C:");
            Assert.AreEqual(parametro1, parametro2);
            Assert.IsTrue(parametro1 == parametro2);
            Assert.IsTrue(parametro1.Equals(parametro2));
            Assert.IsFalse( object.ReferenceEquals(parametro1, parametro2));
        }

        


        [TestMethod]
        public void ReferenceEqualsTest()
        {
            var lista = new VtrHierarchicalList();
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
            var lista = new VtrHierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");
            var parametro2 = lista.Add(2, null, "D:");
            Assert.AreNotEqual(parametro1, parametro2);
            Assert.IsTrue(parametro1 != parametro2);
            Assert.IsFalse(parametro1 == parametro2);
            Assert.IsFalse(parametro1.Equals(parametro2));

            var parametro3 = lista.Add(1, null, "D:");
            var parametro4 = lista.Add(2, null, "C:");


            Assert.AreNotEqual(parametro3, parametro4);
            Assert.IsTrue(parametro3 != parametro4);
            Assert.IsFalse(parametro3 == parametro4);
            Assert.IsFalse(parametro3.Equals(parametro4));
        }



        [TestMethod]
        public void ToStringTest()
        {
            var lista = new VtrHierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");
            string valor = parametro1.ToString();
            Assert.AreEqual("C:", valor);


            var parametro2 = lista.Add(2, 1, "Windows");
            var parametro3 = lista.Add(3, 1, "Usuários");
            var parametro4 = lista.Add(4, 2, "System");

            Assert.AreEqual("C:/Windows/System", parametro4.ToString());
        }


    }
}
