using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using VtrFramework.Extensions;

namespace VtrFramework.Test.Extensions
{
    [TestFixture, Description("Teste de métodos de extensão para enuns"), Category("ExtensionMethods")]
    public class VtrEnumExtensionsTest
    {
        public enum TargetEnum
        {
            [System.ComponentModel.Description("Opção 1")]
            Opcao1,

            [EnumMember(Value ="Opção 2")]
            Opcao2,

            [Text("Opção 3")]
            Opcao3,

            Opcao4
        }

        [Test]
        [Description("Teste de método que traz descrição amigável do enum")]
        [Category("ExtensionMethods")]
        public void ToTextTest()
        {
            Assert.AreEqual("Opção 1", TargetEnum.Opcao1.ToText());
            Assert.AreEqual("Opção 2", TargetEnum.Opcao2.ToText());
            Assert.AreEqual("Opção 3", TargetEnum.Opcao3.ToText());
            Assert.AreEqual("Opcao4", TargetEnum.Opcao4.ToText());
        }
    }
}
