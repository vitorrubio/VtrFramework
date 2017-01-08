using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using VtrFramework.CodeGenerator;
using VtrFramework;
using VtrFramework.Infra;

namespace dllBBI.Test.Genesis.MetaData
{

    [TestFixture]
    public class VtrCodeGenerationWorkTest
    {

        [Test]
        public void ExportarProjetoTest()
        {

            //string caminho = @"C:\temp\VtrTemplate\Source\";
            string caminho = @"C:\Users\vitor\Dropbox\VtrFramework\VtrFramework.CodeGenerator.Test\GeneratedCode\";
            string nameSpace = "VtrTemplate";
            
            VtrCodeGenerationWork exp = new VtrCodeGenerationWork(VtrContext.GetDB(), nameSpace, caminho);

            exp.GeneratorFactories.Add(new VtrGeneratorFactory<VtrAutoProperitesClassGenerator>());

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



        [Test]
        public void SmartTestTest()
        {

            //string caminho = @"C:\temp\VtrTemplate\Source\";
            string caminho = @"C:\Users\vitor\Dropbox\tecnun\ecommerce\src\smart\";
            string nameSpace = "VtrTemplate";

            VtrCodeGenerationWork exp = new VtrCodeGenerationWork(VtrContext.GetDB(
                new VtrLiteralConnectionStringProvider(
                      @"Data Source=.\SQLEXPRESS;Initial Catalog=smart;Persist Security Info=True;User ID=smart;Password=smart"
                    )
            ), nameSpace, caminho);

            exp.GeneratorFactories.Add(new VtrGeneratorFactory<VtrAutoProperitesClassGenerator>());

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
    }
}
