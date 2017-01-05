using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtrFramework.Test.Infra
{
    [TestFixture]
    public class VtrContextTest
    {
        [Test]
        public void GetCompleteUserNameTest()
        {

            Console.WriteLine("Nome: " + VtrContext.GetCompleteUserName("", "vitor"));

        }
    }
}
