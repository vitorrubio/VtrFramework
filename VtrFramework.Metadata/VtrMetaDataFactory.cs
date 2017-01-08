using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtrFramework.Infra;
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

        public static IVtrTableRepository GetTableRepository(IVtrSystemDatabase db)
        {
            return new VtrMsSqlTableRepository(db);
        }

        public static IVtrTableRepository GetTableRepository(IVtrConnectionStringProvider prov)
        {
            return new VtrMsSqlTableRepository(VtrContext.GetDB(prov));
        }
    }
}
