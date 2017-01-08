using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtrTemplate.Data.Repository;
using VtrTemplate.Domain.DomainModel;

namespace VtrFramework.CodeGenerator.Test.GeneratedCodeTests.Data
{
    [TestFixture]
    public class UmaTabelaQualquerRepositoryTest
    {
        [Test]
        public void SaveTest()
        {
            UmaTabelaQualquer reg = new UmaTabelaQualquer();
            reg.Nome = "teste";

            UmaTabelaQualquerRepository rep = new UmaTabelaQualquerRepository();
            rep.Save(reg);

            reg.Nome = "teste2";
            rep.Save(reg);

           

            Assert.Greater(reg.Id, 0);

            int id = reg.Id;
            reg = null;
            reg = rep.GetById(id);
            Assert.IsNotNull(reg);
            Assert.AreEqual("teste2", reg.Nome);
        }

        [Test]
        public void DeleteTest()
        {
            UmaTabelaQualquer reg = new UmaTabelaQualquer();
            reg.Nome = "teste";

            UmaTabelaQualquerRepository rep = new UmaTabelaQualquerRepository();
            rep.Save(reg);

            Assert.Greater(reg.Id, 0);
            rep.Delete(reg);

            int id = reg.Id;
            reg = null;
            reg = rep.GetById(id);
            Assert.IsNull(reg);
        }

        [Test]
        public void GetAllTest()
        {
            UmaTabelaQualquerRepository rep = new UmaTabelaQualquerRepository();
            var todos = rep.GetAll();
            Assert.Greater(todos.Count, 0);
        }


    }
}
