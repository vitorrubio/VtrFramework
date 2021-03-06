﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtrFramework.Infra;
using VtrFramework.MetaData;

namespace VtrFramework.MetaData.Test
{
    [TestFixture]
    public class VtrMsSqlTableRepositoryTest
    {
        [Test]
        public void CreateTest()
        {
            VtrAppConfigConnectionStringProvider prov = new VtrAppConfigConnectionStringProvider();
            VtrSystemDatabase db = new VtrSystemDatabase( prov );

            VtrMsSqlTableRepository obj1 = new VtrMsSqlTableRepository(db);
            Assert.IsNotNull(obj1);

            VtrMsSqlTableRepository obj2 = new VtrMsSqlTableRepository(prov);
            Assert.IsNotNull(obj2);
        }


        [Test]
        public void GetAllTest()
        {
            VtrMsSqlTableRepository rep = new VtrMsSqlTableRepository(new VtrAppConfigConnectionStringProvider());
            var tabelas = rep.GetAll();

            Assert.Greater(tabelas.Count, 0);
            Assert.Contains(new VtrTable {Nome="UmaTabelaQualquer", Schema="DBO", DatabaseName = "VtrTemplate" }, tabelas);

            var UmaTabelaQualquer = tabelas.Where(t => t.Nome == "UmaTabelaQualquer").FirstOrDefault();
            Assert.IsNotNull(UmaTabelaQualquer);

            Assert.Greater(UmaTabelaQualquer.Campos.Count, 0 );
            Assert.Contains(new VtrField(UmaTabelaQualquer) { Nome = "Observacao" }, UmaTabelaQualquer.Campos);
        }



        [Test]
        public void GetAllWithGetDBTest()
        {
            VtrMsSqlTableRepository rep = new VtrMsSqlTableRepository(VtrContext.GetDB());
            var tabelas = rep.GetAll();

            Assert.Greater(tabelas.Count, 0);
            Assert.Contains(new VtrTable { Nome = "UmaTabelaQualquer", Schema = "DBO", DatabaseName = "VtrTemplate" }, tabelas);

            var UmaTabelaQualquer = tabelas.Where(t => t.Nome == "UmaTabelaQualquer").FirstOrDefault();
            Assert.IsNotNull(UmaTabelaQualquer);

            Assert.Greater(UmaTabelaQualquer.Campos.Count, 0);
            Assert.Contains(new VtrField(UmaTabelaQualquer) { Nome = "Observacao" }, UmaTabelaQualquer.Campos);
        }
    }
}
