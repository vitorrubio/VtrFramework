using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtrFramework.MetaData
{
    public interface IVtrModelExtrator
    {
        List<VtrTable> GetTables();
    }
}
