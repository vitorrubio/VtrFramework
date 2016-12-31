using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtrFramework.Extensions;

namespace VtrFramework.Test.Extensions
{
    /// <summary>
    ///This is a test class for VtrStringExtensionsTest and is intended
    ///to contain all VtrStringExtensionsTest Unit Tests
    ///</summary>
    [TestFixture, Description("Teste de métodos de extensão para string"), Category("ExtensionMethods")]
    public class StringExtensionsTest
    {

        /// <summary>
        ///A test for ToDatabase
        ///</summary>
        [Test, Description("Teste de método que limpa string antes de ir para bd"), Category("ExtensionMethods")]
        public void ToDatabaseTest()
        {
            string source = "1° ETAPA";
            string erro1 = "1Â° ETAPA";
            string erro2 = "1A° ETAPA";
            bool toupper = true;
            bool removebreaks = true;
            bool removetabs = true;

            string expected = "1 ETAPA";
            string actual;

            actual = source.ToUsAscii().ToDatabase(
                toupper: toupper,
                removebreaks: removebreaks,
                removetabs: removetabs);

            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(erro1, actual);
            Assert.AreNotEqual(erro2, actual);
            Console.WriteLine(actual);
            actual = source.ToDatabase(toupper: toupper,
                removebreaks: removebreaks,
                removetabs: removetabs).ToUsAscii();
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(erro1, actual);
            Assert.AreNotEqual(erro2, actual);
        }


        /// <summary>
        ///A test for ToDatabase
        ///</summary>
        [Test, Description("Teste de método que limpa string antes de ir para bd"), Category("ExtensionMethods")]
        public void ToDatabaseTest2()
        {
            string source = "\"\\1° Profª ÁÂATEÉ\t \tLÓOGO Contagem:._0123456789@_ +-*/%()[]{}";
            string expected = "1 Prof AAATEE LOOGO Contagem._0123456789_ -".ToUpper();

            Assert.AreEqual(expected, source.ToDatabase());
        }



        /// <summary>
        ///A test for ToDatabase
        ///</summary>
        [Test, Description("Teste de método que limpa string antes de ir para bd"), Category("ExtensionMethods")]
        public void ToDatabaseTest3()
        {
            string source = "";
            string expected = "".ToUpper();

            Assert.AreEqual(expected, source.ToDatabase());
        }



        /// <summary>
        ///A test for ReplaceDiacritics
        ///</summary>
        [Test, Description("Substitui caracteres acentuados por equivalentes sem acento"), Category("ExtensionMethods"), TestCase("çãçá"), TestCase("çâçä")]
        public void ReplaceDiacriticsTest1(string source)
        {
            string expected = "caca";
            string actual = source.ReplaceDiacritics();
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for ReplaceDiacritics
        ///</summary>
        [Test, Description("Substitui caracteres acentuados por equivalentes sem acento"), Category("ExtensionMethods"), TestCase("çªçª")]
        public void ReplaceDiacriticsTest2(string source)
        {
            string expected = "caca";
            string actual = source.ReplaceDiacritics();
            Assert.AreNotEqual(expected, actual);
            Console.WriteLine(actual);
        }

        /// <summary>
        ///A test for ToUsAscii
        ///</summary>
        [Test, Description("TConverte unicode para ascii"), Category("ExtensionMethods")]
        public void ToAsciiTest1()
        {
            string source = "1° ETAPA";
            string expected = "1 ETAPA";
            string actual = source.ToUsAscii();
            Assert.AreEqual(expected, actual);
        }



        /// <summary>
        ///A test for ToUsAscii
        ///</summary>
        [Test, Description("TConverte unicode para ascii"), Category("ExtensionMethods")]
        public void ToAsciiTest2()
        {
            string source = "1Â° ETAPA";
            string expected = "1 ETAPA";
            string actual = source.ToUsAscii();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for matches
        ///</summary>
        [Test, Description("Testa se uma string combina com um padrão"), Category("ExtensionMethods"), TestCase("29918516860", @"\d{11,11}")]
        public void matchesTest1(string valor, string padrao)
        {
            bool expected = valor.matches(padrao);
            Assert.IsTrue(expected);
        }


        /// <summary>
        ///A test for matches
        ///</summary>
        [Test, Description("Testa se uma string NÃO combina com um padrão"), Category("ExtensionMethods"), TestCase("299185168600", @"^[\d]{11,11}$")]
        public void matchesTest2(string valor, string padrao)
        {
            bool expected = valor.matches(padrao);
            Assert.IsFalse(expected);
        }


        /// <summary>
        ///A test for matches
        ///</summary>
        [Test, Description("Testa se uma string NÃO combina com um padrão"), Category("ExtensionMethods"), TestCase("2991851686a", @"^[\d]{11,11}$")]
        public void matchesTest3(string valor, string padrao)
        {
            bool expected = valor.matches(padrao);
            Assert.IsFalse(expected);
        }


        /// <summary>
        ///A test for OnlyPrintablesTest
        ///</summary>
        [Test, Description("Testa a remoção de caracteres não imprimíveis / não padrão"), Category("ExtensionMethods")]
        public void OnlyPrintablesTest()
        {
            string source = "ÁÂATEÉ LÓOGO Contagem:._0123456789@_ +-*/%()[]{}";
            string expected = "ATE LOGO Contagem._0123456789_ -";

            Console.WriteLine(source.OnlyPrintables());
            Assert.AreEqual(expected, source.OnlyPrintables());
        }


        [Test,
            Description("Testa a remoção de caracteres de controle"),
            Category("ExtensionMethods"),
            TestCase("teste\r\nde\tcontrole")]
        public void RemoveCtrlCharsTest(string teste)
        {
            string expected = "testedecontrole";
            Assert.AreEqual(expected, teste.RemoveCtrlChars());
        }


        [Test]
        [Description("Testa se uma string é uma data ou não")]
        [Category("ExtensionMethods")]
        public void IsDateTest()
        {
            Assert.IsTrue("14/02/1983".IsDate());

            Assert.IsFalse("14/15/1983".IsDate());

            Assert.IsFalse("02/15/1983".IsDate());
        }

    }
}
