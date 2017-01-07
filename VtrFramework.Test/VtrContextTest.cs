using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtrFramework.Test
{
    [TestFixture]
    public class VtrContextTest
    {
        [Test]
        public void GetCurrentLogin()
        {
            var nome = VtrContext.GetCurrentLogin();
            Console.WriteLine(nome);
            Assert.IsNotEmpty(nome);

        }
    }
}
