using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using VtrFramework.Extensions;

namespace VtrFramework.Test
{
    [TestFixture, Description("Teste de utilitários para enums"), Category("Tools")]
    public class VtrEnumToolsTest
    {
        public enum TargetEnum
        {

            [Text("Opção 1")]
            Opcao1,

            [Text("Opção 2")]
            Opcao2,

            [Text("Opção 3")]
            Opcao3,

            [Text("Opção 4")]
            Opcao4

        }

        [Test]
        [Description("Teste de método que publica os itens de um enum em um dropdown")]
        [Category("Tools")]
        public void PublicaEnumTest()
        {

            DropDownList ddl = new DropDownList();
            VtrEnumTools.PublicaEnum<TargetEnum>(ddl);

            Assert.AreEqual(5, ddl.Items.Count);

            Assert.IsNotNull(ddl.Items.FindByText("Opção 4"));

        }
    }
}
