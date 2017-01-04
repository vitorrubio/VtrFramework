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
    public class HierarchicalParameterMicrosoftTest
    {
        [TestMethod]
        public void EqualsTest()
        {
            var lista = new HierarchicalList();
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

            var parametro3 = lista.Add(1, null, "D:");
            var parametro4 = lista.Add(2, null, "C:");


            Assert.AreNotEqual(parametro3, parametro4);
            Assert.IsTrue(parametro3 != parametro4);
            Assert.IsFalse(parametro3 == parametro4);
            Assert.IsFalse(parametro3.Equals(parametro4));
        }








        [TestMethod]
        public void StringImplicitConversionTest()
        {
            var lista = new HierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");

            //aqui está testando a conversão de parametro1 para string, e não a igualdade entre as variáveis
            Assert.IsTrue("C:".Equals(parametro1));
            Assert.IsTrue(parametro1 == "C:");
            Assert.IsTrue("C:" == parametro1);


            //numa implementação correta de operadores e conversões, as asserções abaixo DEVEM FALHAR
            //Assert.IsTrue(parametro1.Equals("C:"));
            //Assert.AreEqual("C:", parametro1);
            //Assert.AreEqual(parametro1, "C:");
        }

        [TestMethod]
        public void ToStringTest()
        {
            var lista = new HierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");
            string valor = parametro1;
            Assert.AreEqual("C:", valor);
            Assert.AreEqual("C:", (string)parametro1);
        }


    }
}
