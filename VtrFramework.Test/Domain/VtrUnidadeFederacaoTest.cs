using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtrFramework.Domain;

namespace VtrFramework.Test.Domain
{
    [TestFixture]
    public class VtrUnidadeFederacaoTest
    {
        [Test]
        public void ListarTest()
        {

            var ufs = VtrUnidadeFederacao.GetUnidadeFederacaoList();
            Assert.IsNotNull(ufs);
            CollectionAssert.IsNotEmpty(ufs);
            CollectionAssert.AllItemsAreNotNull(ufs);
            CollectionAssert.AllItemsAreUnique(ufs);


        }
    }
}
