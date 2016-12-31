using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtrFramework.Test.Infra
{
    [TestFixture]
    public class ContextoTest
    {
        [Test]
        public void GetCompleteUserNameTest()
        {

            Console.WriteLine("Nome: " + Contexto.GetCompleteUserName("", "vitor"));

        }
    }
}
