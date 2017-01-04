using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using VtrFramework.Domain;
using NUnit.Framework;

namespace VtrFramework.Test.Domain
{
    [TestFixture]
    public class HierarchicalListTest
    {
        [Test]
        public void NewTest()
        {
            var lista = new HierarchicalList();

            Assert.AreEqual(0, lista.Count);
        }

        [Test]
        public void AddTest()
        {
            var lista = new HierarchicalList();
            var parametro = lista.Add(1, null, "C:");

            Assert.AreEqual(1, lista.Count);
            Assert.AreEqual(parametro, lista[0]);
        }





        [Test]
        public void GetRoot()
        {
            var lista = new HierarchicalList();
            var parametro1 = lista.Add(1, null, "C:");
            var parametro2 = lista.Add(2, 1, "Windows");
            var parametro3 = lista.Add(3, 1, "Usuários");
            var parametro4 = lista.Add(4, 2, "System");

            Assert.AreEqual("C:", lista.GetRoot().FirstOrDefault().ToString());
        }
    }
}
