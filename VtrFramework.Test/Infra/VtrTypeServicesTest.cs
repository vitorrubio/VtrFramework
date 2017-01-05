using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtrFramework.Infra;

namespace VtrFramework.Test.Infra
{
    [TestFixture]
    public class VtrTypeServicesTest
    {
        [Test]
        public void GetTest()
        {
            var tipo = typeof(DateTime);
            var dbTipo = SqlDbType.DateTime;

            var resultado = VtrTypeServices.TypeToSqlDbType(tipo);

            Assert.AreEqual(dbTipo, resultado);
        }


        [Test]
        public void TestByteArray()
        {

            //byte[] x = { 1 };
            //Type t = x.GetType();
            Type t = typeof(byte[]);
            Console.WriteLine(t.IsValueType);
            Console.WriteLine(t.Name);
        }


        [Test]
        public void TestNullableType()
        {

            //Nullable<int> x = 0;
            //Type t = x.GetType();
            Type t = typeof(Nullable<int>);
            Console.WriteLine(t.IsValueType);
            Console.WriteLine(t.Name);
        }


        [Test]
        public void TestDateTimeType()
        {

            //Nullable<int> x = 0;
            //Type t = x.GetType();
            Type t = typeof(DateTime);
            Console.WriteLine(t.IsValueType);
            Console.WriteLine(t.Name);
        }


        [Test]
        public void TypeMapsTest()
        {
            Dictionary<Type, SqlDbType> dic = new Dictionary<Type, SqlDbType>();

            dic.Add(typeof(Int16), SqlDbType.SmallInt); //short
            dic.Add( typeof(Int32),  SqlDbType.Int); //int
            dic.Add( typeof(Int64),    SqlDbType.BigInt); //long
            dic.Add( typeof(sbyte),  SqlDbType.Int); 
            dic.Add( typeof(UInt16),  SqlDbType.Int); //ushort
            dic.Add( typeof(UInt32),  SqlDbType.BigInt); //uint
            dic.Add( typeof(UInt64),    SqlDbType.BigInt); //ulong
            dic.Add( typeof(byte),  SqlDbType.TinyInt);
            dic.Add( typeof(float),  SqlDbType.Float);
            dic.Add( typeof(decimal),  SqlDbType.Decimal);
            dic.Add( typeof(double),  SqlDbType.Float);
            dic.Add( typeof(bool),  SqlDbType.Bit);
            dic.Add( typeof(DateTime),  SqlDbType.DateTime);
            dic.Add( typeof(Nullable<Int16>),  SqlDbType.SmallInt); //short
            dic.Add( typeof(Nullable<Int32>),  SqlDbType.Int); //int
            dic.Add( typeof(Nullable<Int64>),    SqlDbType.BigInt); //long
            dic.Add( typeof(Nullable<sbyte>),  SqlDbType.Int);
            dic.Add( typeof(Nullable<UInt16>),  SqlDbType.Int); //ushort
            dic.Add( typeof(Nullable<UInt32>),  SqlDbType.BigInt); //uint
            dic.Add( typeof(Nullable<UInt64>),    SqlDbType.BigInt); //ulong
            dic.Add( typeof(Nullable<byte>),  SqlDbType.TinyInt);
            dic.Add( typeof(Nullable<float>),  SqlDbType.Float);
            dic.Add( typeof(Nullable<decimal>),  SqlDbType.Decimal);
            dic.Add( typeof(Nullable<double>),  SqlDbType.Float);
            dic.Add( typeof(Nullable<bool>),  SqlDbType.Bit);
            dic.Add( typeof(Nullable<DateTime>),  SqlDbType.DateTime);
            dic.Add( typeof(string),  SqlDbType.NVarChar);
            dic.Add( typeof(byte[]),  SqlDbType.VarBinary);
        }


    }
}
