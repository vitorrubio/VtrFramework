using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtrFramework.Infra
{
    public static class TypeServices
    {


        private static Dictionary<Type, SqlDbType> _typeSqlDbTypeMap = new Dictionary<Type, SqlDbType>()
        {
            { typeof(Int16),  SqlDbType.SmallInt},
            { typeof(Int32),  SqlDbType.Int},
            { typeof(Int64),    SqlDbType.BigInt},
            { typeof(sbyte),  SqlDbType.Int},

            { typeof(UInt16),  SqlDbType.Int},
            { typeof(UInt32),  SqlDbType.BigInt},
            { typeof(UInt64),    SqlDbType.BigInt},
            { typeof(byte),  SqlDbType.TinyInt},

            { typeof(float),  SqlDbType.Float},
            { typeof(decimal),  SqlDbType.Decimal},
            { typeof(double),  SqlDbType.Float},
            { typeof(bool),  SqlDbType.Bit},

            { typeof(DateTime),  SqlDbType.DateTime},



            { typeof(Nullable<Int16>),  SqlDbType.SmallInt},
            { typeof(Nullable<Int32>),  SqlDbType.Int},
            { typeof(Nullable<Int64>),    SqlDbType.BigInt},
            { typeof(Nullable<sbyte>),  SqlDbType.Int},

            { typeof(Nullable<UInt16>),  SqlDbType.Int},
            { typeof(Nullable<UInt32>),  SqlDbType.BigInt},
            { typeof(Nullable<UInt64>),    SqlDbType.BigInt},
            { typeof(Nullable<byte>),  SqlDbType.TinyInt},

            { typeof(Nullable<float>),  SqlDbType.Float},
            { typeof(Nullable<decimal>),  SqlDbType.Decimal},
            { typeof(Nullable<double>),  SqlDbType.Float},
            { typeof(Nullable<bool>),  SqlDbType.Bit},

            { typeof(Nullable<DateTime>),  SqlDbType.DateTime},



            { typeof(string),  SqlDbType.NVarChar},
            { typeof(byte[]),  SqlDbType.VarBinary},
            { typeof(Guid),  SqlDbType.UniqueIdentifier}
        };

        public static Type GetDeclaredType<TSelf>(TSelf self)
        {
            return typeof(TSelf);
        }

        public static SqlDbType TypeToSqlDbType(Type tp)
        {
            SqlDbType result = SqlDbType.NVarChar;

            if (_typeSqlDbTypeMap.ContainsKey(tp))
                result = _typeSqlDbTypeMap[tp];

            return result;
        }
    }
}
