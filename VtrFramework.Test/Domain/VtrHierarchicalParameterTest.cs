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
    public class VtrHierarchicalParameterTest
    {
        [Test]
        public void EqualsTest()
        {
            var lista = new VtrHierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");
            var parametro2 = lista.Add(1, null, "C:");
            Assert.AreEqual(parametro1, parametro2);
            Assert.IsTrue(parametro1 == parametro2);
            Assert.IsTrue(parametro1.Equals(parametro2));
            Assert.IsFalse(object.ReferenceEquals(parametro1, parametro2));
        }

        


        [Test]
        public void ReferenceTest()
        {
            var lista = new VtrHierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");
            var parametro2 = lista[0];
            Assert.AreEqual(parametro1, parametro2);
            Assert.IsTrue(parametro1 == parametro2);
            Assert.IsTrue(parametro1.Equals(parametro2));
            Assert.IsTrue(object.ReferenceEquals(parametro1, parametro2));
        }





        [Test]
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





        [Test]
        public void ToStringTest()
        {
            var lista = new VtrHierarchicalList("\\");
            var parametro1 = lista.Add(1, null, "C:");
            string valor = parametro1.ToString();
            Assert.AreEqual("C:", valor);

            var parametro2 = lista.Add(2, 1, "Windows");
            var parametro3 = lista.Add(3, 1, "Usuários");
            var parametro4 = lista.Add(4, 2, "System");

            Assert.AreEqual("C:\\Windows\\System", parametro4.ToString());
        }


        [Test]
        public void HasChildrenTest()
        {
            var lista = new VtrHierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");
            var parametro2 = lista.Add(2, 1, "Windows");
            var parametro3 = lista.Add(3, 1, "Usuários");
            var parametro4 = lista.Add(4, 2, "System");

            Assert.IsTrue(parametro1.HasChildren);
            Assert.IsTrue(parametro2.HasChildren);
            Assert.IsFalse(parametro3.HasChildren);
            Assert.IsFalse(parametro4.HasChildren);

            Assert.AreEqual(2, (parametro1.GetChildren() as VtrHierarchicalList).Count);
            Assert.AreEqual(1, (parametro2.GetChildren() as VtrHierarchicalList).Count);
        }


        [Test]
        public void GetChildrenTest()
        {
            var lista = new VtrHierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");
            var parametro2 = lista.Add(2, 1, "Windows");
            var parametro3 = lista.Add(3, 1, "Usuários");
            var parametro4 = lista.Add(4, 2, "System");

            Assert.Contains(parametro2, parametro1.GetChildren() as VtrHierarchicalList);
            Assert.Contains(parametro3, parametro1.GetChildren() as VtrHierarchicalList);
            CollectionAssert.DoesNotContain(parametro1.GetChildren() as VtrHierarchicalList, parametro1);


        }


        [Test]
        public void GetParentTest()
        {
            var lista = new VtrHierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");
            var parametro2 = lista.Add(2, 1, "Windows");
            var parametro3 = lista.Add(3, 1, "Usuários");
            var parametro4 = lista.Add(4, 2, "System");

            Assert.AreEqual(parametro1, parametro2.GetParent());
            Assert.AreNotEqual(parametro1, parametro1.GetParent());


        }

        [Test]
        public void PathTest()
        {
            var lista = new VtrHierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");
            var parametro2 = lista.Add(2, 1, "Windows");
            var parametro3 = lista.Add(3, 1, "Usuários");
            var parametro4 = lista.Add(4, 2, "System");

            Assert.AreEqual("C:/Windows/System", parametro4.ValorPath);
            Assert.AreEqual("1/2/4", parametro4.IdPath);


        }





        [Test]
        public void EqualsOperatorOverrideTest()
        {
            var lista = new VtrHierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");
            var parametro2 = lista.Add(1, null, "C:");


            Assert.IsTrue(parametro1 == parametro1);
            Assert.IsTrue(parametro1 == parametro2);

        }
    }
}
