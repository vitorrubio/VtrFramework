using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using VtrFramework.CodeGenerator;
using VtrFramework;
using VtrFramework.Infra;
using VtrFramework.MetaData;

namespace dllBBI.Test.Genesis.MetaData
{

    [TestFixture]
    public class VtrCodeGenerationWorkTest
    {

        [Test]
        public void ExportarProjetoTest()
        {

            //string caminho = @"C:\temp\VtrTemplate\Source\";
            string caminho = @"C:\temp\VtrTemplate\";
            string nameSpace = "VtrTemplate";
            
            VtrCodeGenerationWork exp = new VtrCodeGenerationWork(VtrContext.GetDB(), nameSpace, caminho);

            exp.GeneratorFactories.Add(new VtrGeneratorFactory<VtrAutoProperitesClassGenerator>());
            exp.GeneratorFactories.Add(new VtrGeneratorFactory<VtrViewModelGenerator>());
            //gerador de repositórios com método DataRowsToEntity
            //exp.GeneratorFactories.Add(new VtrGeneratorFactory<VtrRepositoryGenerator>());

            //gerador de repositórios usando Query<> genérico
            exp.GeneratorFactories.Add(new VtrGeneratorFactory<VtrRepositoryGeneratorWithGenericQuery>());

            //exp.GeneratorFactories.Add(new ExportadorFactory<ExportadorWidgetsDePopUpModal>());
            //exp.GeneratorFactories.Add(new ExportadorFactory<ExportadorWidgetsDeMioloDeFormulario>());

            //exp.GeneratorFactories.Add(new ExportadorFactory<DeletadorTriggerUpdate>());
            //exp.GeneratorFactories.Add(new ExportadorFactory<DeletadorTriggerInsteadOfDelete>());
            //exp.GeneratorFactories.Add(new ExportadorFactory<DeletadorTriggerDelete>());

            //exp.GeneratorFactories.Add(new ExportadorFactory<ExportadorTabelaDeLog>());
            //exp.GeneratorFactories.Add(new ExportadorFactory<ExportadorTriggerUpdate>());
            //exp.GeneratorFactories.Add(new ExportadorFactory<ExportadorTriggerInsteadOfDelete>());
            //exp.GeneratorFactories.Add(new ExportadorFactory<ExportadorTriggerDelete>());


            exp.ExportarProjeto();

        }


        //[Test]
        //public void ExportarProjetoTecnunCommerceTest()
        //{

        //    //string caminho = @"C:\temp\TFWTemplate\Source\";
        //    string caminho = @"C:\temp\TecnunCommerce\";
        //    string nameSpace = "TecnunCommerce";

        //    IVtrConnectionStringProvider provider = new VtrLiteralConnectionStringProvider(@"Data Source=.\SQLEXPRESS;Initial Catalog=TecnunCommerce;Persist Security Info=True;User ID=tecnun;Password=tecnun");
        //    IVtrSystemDatabase db = new VtrSystemDatabase(provider);

        //    VtrCodeGenerationWork exp = new VtrCodeGenerationWork(db, nameSpace, caminho);
        //    exp.GeneratorFactories.Add(new VtrGeneratorFactory<VtrViewModelGenerator>());
        //    exp.GeneratorFactories.Add(new VtrGeneratorFactory<VtrRepositoryGeneratorWithGenericQuery>());

        //    exp.ExportarProjeto();

        //}


        [Test]
        public void ExportarProjetoAPartirDeAssemplyTest()
        {



            VtrModelToMsSqlExtrator extrator = new VtrModelToMsSqlExtrator(@"C:\Users\vitor\Desktop\LibraryMarota\LibraryMarota\bin\Debug\LibraryMarota.dll",
                "LibraryMarota.Domain.DomainModel",
                "dbo",
                "VtrTemplate");

            var tabelas = extrator.GetTables();



            VtrCodeGenerationWork exp = new VtrCodeGenerationWork(VtrContext.GetDB(), "LibraryMarota", @"c:\temp\libmarota\");


            exp.GeneratorFactories.Add(new VtrGeneratorFactory<VtrRepositoryGeneratorWithGenericQuery>());
            exp.GeneratorFactories.Add(new VtrGeneratorFactory<VtrViewModelGenerator>());

            exp.ExportarProjeto(tabelas);

        }
    }
}
