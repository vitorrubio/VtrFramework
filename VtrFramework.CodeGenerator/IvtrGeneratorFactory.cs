using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VtrFramework.MetaData;

namespace VtrFramework.CodeGenerator
{
    public interface IVtrGeneratorFactory
    {
        IVtrGenerator Create(VtrTable tabela, string nameSpace, string path);
    }
}
