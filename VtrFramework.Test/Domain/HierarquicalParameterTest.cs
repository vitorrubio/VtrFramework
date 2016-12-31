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
    public class HierarquicalParameterTest
    {
        [Test]
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

        


        [Test]
        public void ReferenceTest()
        {
            var lista = new HierarchicalList();
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
            var lista = new HierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");
            var parametro2 = lista.Add(2, null, "D:");
            Assert.AreNotEqual(parametro1, parametro2);
            Assert.IsTrue(parametro1 != parametro2);
            Assert.IsFalse(parametro1 == parametro2);
            Assert.IsFalse(parametro1.Equals(parametro2));
        }



        [Test]
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



        [Test]
        public void IntExplicitConversionTest()
        {
            var lista = new HierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");
            int id = (int) parametro1;
            Assert.AreEqual(1, id);
            Assert.AreEqual(1, (int)parametro1);
        }

        [Test]
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

        [Test]
        public void StringExplicitConversionTest()
        {
            var lista = new HierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");
            string valor = parametro1;
            Assert.AreEqual("C:", valor);
            Assert.AreEqual("C:", (string)parametro1);
        }


        [Test]
        public void HasChildrenTest()
        {
            var lista = new HierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");
            var parametro2 = lista.Add(2, 1, "Windows");
            var parametro3 = lista.Add(3, 1, "Usuários");
            var parametro4 = lista.Add(4, 2, "System");

            Assert.IsTrue(parametro1.HasChildren);
            Assert.IsTrue(parametro2.HasChildren);
            Assert.IsFalse(parametro3.HasChildren);
            Assert.IsFalse(parametro4.HasChildren);

            Assert.AreEqual(2, (parametro1.GetChildren() as HierarchicalList).Count);
            Assert.AreEqual(1, (parametro2.GetChildren() as HierarchicalList).Count);
        }


        [Test]
        public void GetChildrenTest()
        {
            var lista = new HierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");
            var parametro2 = lista.Add(2, 1, "Windows");
            var parametro3 = lista.Add(3, 1, "Usuários");
            var parametro4 = lista.Add(4, 2, "System");

            Assert.Contains(parametro2, parametro1.GetChildren() as HierarchicalList);
            Assert.Contains(parametro3, parametro1.GetChildren() as HierarchicalList);
            CollectionAssert.DoesNotContain(parametro1.GetChildren() as HierarchicalList, parametro1);


        }


        [Test]
        public void GetParentTest()
        {
            var lista = new HierarchicalList();
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
            var lista = new HierarchicalList();
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
            var lista = new HierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");
            var parametro2 = lista.Add(1, null, "C:");


            Assert.IsTrue(parametro1 == parametro1);
            Assert.IsTrue(parametro1 == parametro2);
            Assert.IsTrue(1 == parametro1);
            Assert.IsTrue(parametro1 == 1);
        }
    }
}
