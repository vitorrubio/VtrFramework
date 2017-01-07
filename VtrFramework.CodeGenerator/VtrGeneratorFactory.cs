using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VtrFramework.MetaData;

namespace VtrFramework.CodeGenerator
{
    public class VtrGeneratorFactory<T> : IVtrGeneratorFactory where T:class, IVtrGenerator
    {

        public virtual IVtrGenerator Create(VtrTable tabela, string nameSpace, string path)
        {
            return (Activator.CreateInstance(typeof(T), tabela, nameSpace, path) as IVtrGenerator);
        }
    }
}
