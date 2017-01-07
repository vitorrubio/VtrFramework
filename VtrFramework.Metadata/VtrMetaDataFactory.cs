using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtrFramework.MetaData;

namespace VtrFramework.MetaData
{
    public class VtrMetaDataFactory
    {
        //public virtual IVtrFieldTypeInfo GetFieldTypeInfo(VtrField field)
        //{

        //}


        public static IVtrTableRepository GetTableRepository()
        {
            return new VtrMsSqlTableRepository( VtrContext.GetDB() );
        }
    }
}
