using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtrFramework.Infra
{
    public static class VtrTypeServices
    {

        #region campos privados estáticos

        /// <summary>
        /// mantém um dicionário de tipos .net para serem mapeados para SqlDbType
        /// </summary>
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
            { typeof(Guid),  SqlDbType.UniqueIdentifier},
            { typeof(Nullable<Guid>),  SqlDbType.UniqueIdentifier}
        };


        /// <summary>
        /// mantém um dicionário de tipos MsSql para serem mapeados para SqlDbType
        /// </summary>
        private static Dictionary<string, SqlDbType> _msSqlTypeSqlDbTypeMap = new Dictionary<string, SqlDbType>()
        {
            { "smallint",  SqlDbType.SmallInt},
            { "int",  SqlDbType.Int},
            { "integer",  SqlDbType.Int},
            { "bigint",    SqlDbType.BigInt},
            { "tinyint",  SqlDbType.TinyInt},
            { "bit",  SqlDbType.Bit},

            { "float",  SqlDbType.Float},
            { "decimal",  SqlDbType.Decimal},
            { "double",  SqlDbType.Float},
            { "double precision",  SqlDbType.Float},
            { "extended",  SqlDbType.Float},
            { "numeric",  SqlDbType.Float},

            { "datetime",  SqlDbType.DateTime},
            { "datetime2",  SqlDbType.DateTime2},
            { "smalldatetime",  SqlDbType.SmallDateTime},
            { "datetimeoffset",  SqlDbType.DateTimeOffset},

            { "char",  SqlDbType.Char},
            { "nchar",  SqlDbType.NChar},
            { "varchar",  SqlDbType.VarChar},
            { "nvarchar",  SqlDbType.NVarChar},

            { "varbinary",  SqlDbType.VarBinary},
            { "binary",  SqlDbType.Binary},
            { "uniqueidentifier",  SqlDbType.UniqueIdentifier}

        };






        /// <summary>
        /// mantém um dicionário de tipos .net para MSSQL
        /// </summary>
        private static Dictionary<Type, string> _dotNetTypeToMsSqlType = new Dictionary<Type, string>()
        {
            { typeof(Int16),  "smallint"},
            { typeof(Int32),  "int"},
            { typeof(Int64),    "bigint"},
            { typeof(sbyte),  "int"},

            { typeof(UInt16),  "int"},
            { typeof(UInt32),  "bigint"},
            { typeof(UInt64),    "bigint"},
            { typeof(byte),  "tinyint"},

            { typeof(float),  "float"},
            { typeof(decimal),  "decimal"},
            { typeof(double),  "double precision"},
            { typeof(bool),  "bit"},

            { typeof(DateTime),  "datetime"},



            { typeof(Nullable<Int16>),  "smallint"},
            { typeof(Nullable<Int32>),  "int"},
            { typeof(Nullable<Int64>),    "bigint"},
            { typeof(Nullable<sbyte>),  "int"},

            { typeof(Nullable<UInt16>),  "int"},
            { typeof(Nullable<UInt32>),  "bigint"},
            { typeof(Nullable<UInt64>),    "bigint"},
            { typeof(Nullable<byte>),  "tinyint"},

            { typeof(Nullable<float>),  "float"},
            { typeof(Nullable<decimal>),  "decimal"},
            { typeof(Nullable<double>),  "double precision"},
            { typeof(Nullable<bool>),  "bit"},

            { typeof(Nullable<DateTime>),  "datetime"},



            { typeof(string),  "varchar"},
            { typeof(byte[]),  "varbinary"},
            { typeof(Guid),  "uniqueidentifier"},
            { typeof(Nullable<Guid>),  "uniqueidentifier"}

        };

        #endregion



        #region métodos estáticos públicos

        /// <summary>
        /// converte um tipo .net para um tipo SqlDbType
        /// </summary>
        /// <param name="tp"></param>
        /// <returns></returns>
        public static SqlDbType DotNetTypeToSqlDbType(Type tp)
        {
            SqlDbType result = SqlDbType.NVarChar;

            if (_typeSqlDbTypeMap.ContainsKey(tp))
                result = _typeSqlDbTypeMap[tp];

            return result;
        }


        /// <summary>
        /// converte um tipo MsSql para um tipo SqlDbType
        /// </summary>
        /// <param name="tp"></param>
        /// <returns></returns>
        public static SqlDbType MsSqlTypeToSqlDbType(string tp)
        {
            SqlDbType result = SqlDbType.NVarChar;
            tp = tp.ToLower();
            if (_msSqlTypeSqlDbTypeMap.ContainsKey(tp))
                result = _msSqlTypeSqlDbTypeMap[tp];

            return result;
        }



        /// <summary>
        /// converte um tipo .net para a string de um tipo SQL
        /// </summary>
        /// <param name="tp"></param>
        /// <returns></returns>
        public static string DotNetTypeToMsSqlType(Type tp)
        {
            string result = "";

            if (_typeSqlDbTypeMap.ContainsKey(tp))
                result = _dotNetTypeToMsSqlType[tp];

            return result;
        }

        #endregion




    }
}
