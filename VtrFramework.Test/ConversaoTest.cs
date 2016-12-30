
using NUnit.Framework;
using System;
using System.Globalization;
using VtrFramework;

namespace VtrFramework.Test
{
    
    

    [TestFixture]
    public class ConversaoTest
    {
        #region testes gerais

        [TestFixture]
        public class TestesGerais //testes gerais
        {
            

            [Test]
            public void NULL_AND_NullableBoolCompareTest()
            {
                Nullable<bool> flagnull = null;
                Nullable<bool> flagnew = new Nullable<bool>();

                Assert.AreEqual(flagnew, flagnull);
                Assert.IsNull(flagnull);
                Assert.IsNull(flagnew);

                Assert.IsFalse(flagnull.HasValue);
                Assert.IsFalse(flagnew.HasValue);

            }

        }

        #endregion

        #region testes dos extension methods

        [TestFixture]
        public class TestesExtensionMethods //testes dos extension methods
        {
            


            [Test]
            public void IsNullTest()
            {
                object testenull = null;
                object testeDbNull = DBNull.Value;
                string strnull = null;
                string strvazia = "";
                string strspaco = " ";
                string traco = "-";
                string tracoespaco = " - ";



                Assert.IsTrue(testenull.IsNull());
                Assert.IsTrue(testeDbNull.IsNull());
                Assert.IsTrue(strnull.IsNull());
                Assert.IsFalse(strvazia.IsNull());
                Assert.IsFalse(strspaco.IsNull());
                Assert.IsFalse(traco.IsNull());
                Assert.IsFalse(tracoespaco.IsNull());
            }


            
        }

        #endregion



        #region conversao bool / string método 

        [TestFixture]
        public class TestesConversaoBoolStringNovo 
        {
            


            [Test]
            public void NULL_BoolToStringTest()
            {
                Nullable<bool> flag = null;
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                string expected = string.Empty;
                string actual;
                actual = Conversao.ToString(flag, culture);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void BoolToStringTest_NULL()
            {
                Nullable<bool> flag = new Nullable<bool>();
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                string expected = string.Empty;
                string actual;
                actual = Conversao.ToString(flag, culture);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void BoolToStringTest1_NULL()
            {
                Nullable<bool> flag = new Nullable<bool>();
                string expected = string.Empty;
                string actual;
                actual = Conversao.ToString(flag);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void BoolToStringTest2_NULL()
            {
                Nullable<bool> flag = new Nullable<bool>();
                string expected = "nulo";
                string actual;
                actual = Conversao.ToString(flag, "nulo", "s", "n");
                Assert.AreEqual(expected, actual);
            }




            [Test]
            public void BoolToStringTest_TRUE()
            {
                Nullable<bool> flag = new Nullable<bool>(true);
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                string expected = "True";
                string actual;
                actual = Conversao.ToString(flag, culture);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void BoolToStringTest1_TRUE()
            {
                Nullable<bool> flag = new Nullable<bool>(true);
                string expected = "True";
                string actual;
                actual = Conversao.ToString(flag);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void BoolToStringTest2_TRUE()
            {
                Nullable<bool> flag = new Nullable<bool>(true);
                string expected = "s";
                string actual;
                actual = Conversao.ToString(flag, "nulo", "s", "n");
                Assert.AreEqual(expected, actual);
            }




            [Test]
            public void BoolToStringTest_FALSE()
            {
                Nullable<bool> flag = new Nullable<bool>(false);
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                string expected = "False";
                string actual;
                actual = Conversao.ToString(flag, culture);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void BoolToStringTest1_FALSE()
            {
                Nullable<bool> flag = new Nullable<bool>(false);
                string expected = "False";
                string actual;
                actual = Conversao.ToString(flag);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void BoolToStringTest2_FALSE()
            {
                Nullable<bool> flag = new Nullable<bool>(false);
                string expected = "n";
                string actual;
                actual = Conversao.ToString(flag, "nulo", "s", "n");
                Assert.AreEqual(expected, actual);
            }


            
        }

        #endregion

        #region conversao bool / string  - literais

        [TestFixture]
        public class TesteConversaoBoolStringNovoComConstantes 
        {

            [Test]
            public void BoolToStringTest_TRUE()
            {
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                string expected = "True";
                string actual;
                actual = Conversao.ToString(true, culture);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void BoolToStringTest1_TRUE()
            {
                string expected = "True";
                string actual;
                actual = Conversao.ToString(true);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void BoolToStringTest2_TRUE()
            {
                string expected = "s";
                string actual;
                actual = Conversao.ToString(true, "nulo", "s", "n");
                Assert.AreEqual(expected, actual);
            }




            [Test]
            public void BoolToStringTest_FALSE()
            {
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                string expected = "False";
                string actual;
                actual = Conversao.ToString(false, culture);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void BoolToStringTest1_FALSE()
            {
                string expected = "False";
                string actual;
                actual = Conversao.ToString(false);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void BoolToStringTest2_FALSE()
            {
                string expected = "n";
                string actual;
                actual = Conversao.ToString(false, "nulo", "s", "n");
                Assert.AreEqual(expected, actual);
            }



        }

        #endregion

        #region conversão DateTime / string

        [TestFixture]
        public class TesteConversaoDateTimeStringNovo 
        {


            [Test]
            public void DateTimeToStringTest_NULL()
            {
                Nullable<DateTime> data = new Nullable<DateTime>();
                string expected = string.Empty;
                string actual;
                actual = Conversao.ToString(data);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void DateTimeToStringTest1_NULL()
            {
                Nullable<DateTime> data = new Nullable<DateTime>();
                string format = Conversao.DEFAULT_DATETIME_FORMAT;
                string expected = string.Empty;
                string actual;
                actual = Conversao.ToString(data, format);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void DateTimeToStringTest2_NULL()
            {
                Nullable<DateTime> data = new Nullable<DateTime>();
                string format = Conversao.DEFAULT_DATETIME_FORMAT;
                IFormatProvider culture = Conversao.DEFAULT_CULTURE_INFO;
                string expected = string.Empty;
                string actual;
                actual = Conversao.ToString(data, format, culture);
                Assert.AreEqual(expected, actual);
            }




            [Test]
            public void DateTimeToStringTest()
            {
                Nullable<DateTime> data = new Nullable<DateTime>(new DateTime(1983, 2, 14, 13, 55, 59));
                string expected = "14/02/1983 13:55:59";
                string actual;
                actual = Conversao.ToString(data);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void DateTimeToStringTest1_1()
            {
                Nullable<DateTime> data = new Nullable<DateTime>(new DateTime(1983, 2, 14, 13, 55, 59));
                string format = Conversao.DEFAULT_DATETIME_FORMAT;
                string expected = "14/02/1983 13:55:59";
                string actual;
                actual = Conversao.ToString(data, format);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void DateTimeToStringTest1_2()
            {
                Nullable<DateTime> data = new Nullable<DateTime>(new DateTime(1983, 2, 14, 13, 55, 59));
                string format = Conversao.DEFAULT_DATE_FORMAT;
                string expected = "14/02/1983";
                string actual;
                actual = Conversao.ToString(data, format);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void DateTimeToStringTest1_3()
            {
                Nullable<DateTime> data = new Nullable<DateTime>(new DateTime(1983, 2, 14, 13, 55, 59));
                string format = "yyyy-MM-dd hh:mm:ss tt";
                string expected = "1983-02-14 01:55:59 PM";
                string actual;
                actual = Conversao.ToString(data, format, CultureInfo.InvariantCulture);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void DateTimeToStringTest2()
            {
                Nullable<DateTime> data = new Nullable<DateTime>(new DateTime(1983, 2, 14, 13, 55, 59));
                string format = Conversao.DEFAULT_DATETIME_FORMAT;
                IFormatProvider culture = Conversao.DEFAULT_CULTURE_INFO;
                string expected = "14/02/1983 13:55:59";
                string actual;
                actual = Conversao.ToString(data, format, culture);
                Assert.AreEqual(expected, actual);
            }
        }

        #endregion

        #region conversão double / string 

        [TestFixture]
        public class TesteConversaoDoubleStringNovo 
        {

            [Test]
            public void DoubleToStringTest_NULL()
            {
                Nullable<double> numero = new Nullable<double>();
                string format = Conversao.DEFAULT_FLOAT_FORMAT;
                IFormatProvider culture = Conversao.DEFAULT_CULTURE_INFO;
                string expected = string.Empty;
                string actual;
                actual = Conversao.ToString(numero, format, culture);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void DoubleToStringTest1_NULL()
            {
                Nullable<double> numero = new Nullable<double>();
                string expected = string.Empty;
                string actual;
                actual = Conversao.ToString(numero);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void DoubleToStringTest2_NULL()
            {
                Nullable<double> numero = new Nullable<double>();
                string format = Conversao.DEFAULT_FLOAT_FORMAT;
                string expected = string.Empty;
                string actual;
                actual = Conversao.ToString(numero, format);
                Assert.AreEqual(expected, actual);
            }










            [Test]
            public void DoubleToStringTest_POSITIVO()
            {
                Nullable<double> numero = new Nullable<double>(10000000000.05);
                string format = Conversao.DEFAULT_FLOAT_FORMAT;
                IFormatProvider culture = Conversao.DEFAULT_CULTURE_INFO;
                string expected = "10.000.000.000,05";
                string actual;
                actual = Conversao.ToString(numero, format, culture);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void DoubleToStringTest1_POSITIVO()
            {
                Nullable<double> numero = new Nullable<double>(10000000000.05);
                string expected = "10.000.000.000,05";
                string actual;
                actual = Conversao.ToString(numero);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void DoubleToStringTest2_POSITIVO()
            {
                Nullable<double> numero = new Nullable<double>(10000000000.05);
                string format = Conversao.DEFAULT_FLOAT_FORMAT;
                string expected = "10.000.000.000,05";
                string actual;
                actual = Conversao.ToString(numero, format);
                Assert.AreEqual(expected, actual);
            }




            [Test]
            public void DoubleToStringTest_NEGATIVO()
            {
                Nullable<double> numero = new Nullable<double>(-10000000000.05);
                string format = Conversao.DEFAULT_FLOAT_FORMAT;
                IFormatProvider culture = Conversao.DEFAULT_CULTURE_INFO;
                string expected = "-10.000.000.000,05";
                string actual;
                actual = Conversao.ToString(numero, format, culture);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void DoubleToStringTest1_NEGATIVO()
            {
                Nullable<double> numero = new Nullable<double>(-10000000000.05);
                string expected = "-10.000.000.000,05";
                string actual;
                actual = Conversao.ToString(numero);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void DoubleToStringTest2_NEGATIVO()
            {
                Nullable<double> numero = new Nullable<double>(-10000000000.05);
                string format = Conversao.DEFAULT_FLOAT_FORMAT;
                string expected = "-10.000.000.000,05";
                string actual;
                actual = Conversao.ToString(numero, format);
                Assert.AreEqual(expected, actual);
            }

        }

        #endregion

        #region conversão long ou Int64 / string 

        [TestFixture]
        public class TesteConversaoLongStringNovo 
        {
            [Test]
            public void IntegerToStringTest1_NULL()
            {
                Nullable<long> numero = new Nullable<long>();
                string expected = string.Empty;
                string actual;
                actual = Conversao.ToString(numero);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void IntegerToStringTest2_NULL()
            {
                Nullable<long> numero = new Nullable<long>();
                string format = Conversao.DEFAULT_INTEGER_FORMAT;
                IFormatProvider culture = Conversao.DEFAULT_CULTURE_INFO;
                string expected = string.Empty;
                string actual;
                actual = Conversao.ToString(numero, format, culture);
                Assert.AreEqual(expected, actual);
            }



            [Test]
            public void IntegerToStringTest3_NULL()
            {
                Nullable<long> numero = new Nullable<long>();
                string format = Conversao.DEFAULT_INTEGER_FORMAT;
                string expected = string.Empty;
                string actual;
                actual = Conversao.ToString(numero, format);
                Assert.AreEqual(expected, actual);
            }








            [Test]
            public void IntegerToStringTest1_POSITIVO()
            {
                Nullable<long> numero = new Nullable<long>(999999999999);
                string expected = "999.999.999.999";
                string actual;
                actual = Conversao.ToString(numero);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void IntegerToStringTest2_POSITIVO()
            {
                Nullable<long> numero = new Nullable<long>(999999999999);
                string format = Conversao.DEFAULT_INTEGER_FORMAT;
                IFormatProvider culture = Conversao.DEFAULT_CULTURE_INFO;
                string expected = "999.999.999.999";
                string actual;
                actual = Conversao.ToString(numero, format, culture);
                Assert.AreEqual(expected, actual);
            }



            [Test]
            public void IntegerToStringTest3_POSITIVO()
            {
                Nullable<long> numero = new Nullable<long>(999999999999);
                string format = Conversao.DEFAULT_INTEGER_FORMAT;
                string expected = "999.999.999.999";
                string actual;
                actual = Conversao.ToString(numero, format);
                Assert.AreEqual(expected, actual);
            }





            [Test]
            public void IntegerToStringTest1_NEGATIVO()
            {
                Nullable<long> numero = new Nullable<long>(-999999999999);
                string expected = "-999.999.999.999";
                string actual;
                actual = Conversao.ToString(numero);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void IntegerToStringTest2_NEGATIVO()
            {
                Nullable<long> numero = new Nullable<long>(-999999999999);
                string format = Conversao.DEFAULT_INTEGER_FORMAT;
                IFormatProvider culture = Conversao.DEFAULT_CULTURE_INFO;
                string expected = "-999.999.999.999";
                string actual;
                actual = Conversao.ToString(numero, format, culture);
                Assert.AreEqual(expected, actual);
            }



            [Test]
            public void IntegerToStringTest3_NEGATIVO()
            {
                Nullable<long> numero = new Nullable<long>(-999999999999);
                string format = Conversao.DEFAULT_INTEGER_FORMAT;
                string expected = "-999.999.999.999";
                string actual;
                actual = Conversao.ToString(numero, format);
                Assert.AreEqual(expected, actual);
            }

        }

        #endregion 

        #region conversão int / string

        [TestFixture]
        public class TesteConversaoIntegerToStringNovo 
        {
            [Test]
            public void IntegerToStringTest1_NULL()
            {
                Nullable<int> numero = new Nullable<int>();
                string expected = string.Empty;
                string actual;
                actual = Conversao.ToString(numero);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void IntegerToStringTest2_NULL()
            {
                Nullable<int> numero = new Nullable<int>();
                string format = Conversao.DEFAULT_INTEGER_FORMAT;
                IFormatProvider culture = Conversao.DEFAULT_CULTURE_INFO;
                string expected = string.Empty;
                string actual;
                actual = Conversao.ToString(numero, format, culture);
                Assert.AreEqual(expected, actual);
            }



            [Test]
            public void IntegerToStringTest3_NULL()
            {
                Nullable<int> numero = new Nullable<int>();
                string format = Conversao.DEFAULT_INTEGER_FORMAT;
                string expected = string.Empty;
                string actual;
                actual = Conversao.ToString(numero, format);
                Assert.AreEqual(expected, actual);
            }








            [Test]
            public void IntegerToStringTest1_POSITIVO()
            {
                Nullable<int> numero = new Nullable<int>(999999999);
                string expected = "999.999.999";
                string actual;
                actual = Conversao.ToString(numero);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void IntegerToStringTest2_POSITIVO()
            {
                Nullable<int> numero = new Nullable<int>(999999999);
                string format = Conversao.DEFAULT_INTEGER_FORMAT;
                IFormatProvider culture = Conversao.DEFAULT_CULTURE_INFO;
                string expected = "999.999.999";
                string actual;
                actual = Conversao.ToString(numero, format, culture);
                Assert.AreEqual(expected, actual);
            }



            [Test]
            public void IntegerToStringTest3_POSITIVO()
            {
                Nullable<int> numero = new Nullable<int>(999999999);
                string format = Conversao.DEFAULT_INTEGER_FORMAT;
                string expected = "999.999.999";
                string actual;
                actual = Conversao.ToString(numero, format);
                Assert.AreEqual(expected, actual);
            }





            [Test]
            public void IntegerToStringTest1_NEGATIVO()
            {
                Nullable<int> numero = new Nullable<int>(-999999999);
                string expected = "-999.999.999";
                string actual;
                actual = Conversao.ToString(numero);
                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void IntegerToStringTest2_NEGATIVO()
            {
                Nullable<int> numero = new Nullable<int>(-999999999);
                string format = Conversao.DEFAULT_INTEGER_FORMAT;
                IFormatProvider culture = Conversao.DEFAULT_CULTURE_INFO;
                string expected = "-999.999.999";
                string actual;
                actual = Conversao.ToString(numero, format, culture);
                Assert.AreEqual(expected, actual);
            }



            [Test]
            public void IntegerToStringTest3_NEGATIVO()
            {
                Nullable<int> numero = new Nullable<int>(-999999999);
                string format = Conversao.DEFAULT_INTEGER_FORMAT;
                string expected = "-999.999.999";
                string actual;
                actual = Conversao.ToString(numero, format);
                Assert.AreEqual(expected, actual);
            }

        }

        #endregion 



        #region conversao null object para bool 

        [TestFixture]
        public class TesteNullObjectToBoolNovo
        {
            [Test]
            public void ToBoolWithCultureTest()
            {
                object obj = null;
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                bool expected = false;
                bool actual;
                actual = Conversao.ToBool(obj, culture);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ToBoolWithoutCultureTest()
            {
                object obj = null;
                bool expected = false;
                bool actual;
                actual = Conversao.ToBool(obj);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ToNullableBoolWithCultureTest()
            {
                object obj = null;
                Nullable<bool> expected = new Nullable<bool>();
                Nullable<bool> actual;
                actual = Conversao.ToNullableBool(obj);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ToNullableBoolWithoutCultureTest()
            {
                object obj = null;
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                Nullable<bool> expected = new Nullable<bool>();
                Nullable<bool> actual;
                actual = Conversao.ToNullableBool(obj, culture);
                Assert.AreEqual(expected, actual);
            }

        }


        #endregion

        #region conversao string para bool 

        [TestFixture]
        public class TesteStringToBoolNovo
        {

            [Test]
            public void ToBoolWithCultureTest()
            {
                object obj = "true";
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                bool expected = true;
                bool actual;
                actual = Conversao.ToBool(obj, culture);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ToBoolWithoutCultureTest()
            {
                object obj = "true";
                bool expected = true;
                bool actual;
                actual = Conversao.ToBool(obj);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ToNullableBoolWithCultureTest()
            {
                object obj = "true";
                Nullable<bool> expected = new Nullable<bool>(true);
                Nullable<bool> actual;
                actual = Conversao.ToNullableBool(obj);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ToNullableBoolWithoutCultureTest()
            {
                object obj = "true";
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                Nullable<bool> expected = new Nullable<bool>(true);
                Nullable<bool> actual;
                actual = Conversao.ToNullableBool(obj, culture);
                Assert.AreEqual(expected, actual);
            }








            [Test]
            public void ToBoolWithCultureTest2()
            {
                object obj = "false";
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                bool expected = false;
                bool actual;
                actual = Conversao.ToBool(obj, culture);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ToBoolWithoutCultureTest2()
            {
                object obj = "false";
                bool expected = false;
                bool actual;
                actual = Conversao.ToBool(obj);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ToNullableBoolWithCultureTest2()
            {
                object obj = "false";
                Nullable<bool> expected = new Nullable<bool>(false);
                Nullable<bool> actual;
                actual = Conversao.ToNullableBool(obj);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ToNullableBoolWithoutCultureTest2()
            {
                object obj = "false";
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                Nullable<bool> expected = new Nullable<bool>(false);
                Nullable<bool> actual;
                actual = Conversao.ToNullableBool(obj, culture);
                Assert.AreEqual(expected, actual);
            }





            [Test]
            public void ToNullableBoolWithCultureTest3()
            {
                object obj = "";
                Nullable<bool> expected = new Nullable<bool>();
                Nullable<bool> actual;
                actual = Conversao.ToNullableBool(obj);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ToNullableBoolWithoutCultureTest3()
            {
                object obj = "";
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                Nullable<bool> expected = new Nullable<bool>();
                Nullable<bool> actual;
                actual = Conversao.ToNullableBool(obj, culture);
                Assert.AreEqual(expected, actual);
            }


        }


        #endregion

        #region conversao int para bool 

        [TestFixture]
        public class TesteIntToBoolNovo
        {

            [Test]
            public void ToBoolWithCultureTest()
            {
                object obj = 1;
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                bool expected = true;
                bool actual;
                actual = Conversao.ToBool(obj, culture);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ToBoolWithoutCultureTest()
            {
                object obj = 1;
                bool expected = true;
                bool actual;
                actual = Conversao.ToBool(obj);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ToNullableBoolWithCultureTest()
            {
                object obj = 1;
                Nullable<bool> expected = new Nullable<bool>(true);
                Nullable<bool> actual;
                actual = Conversao.ToNullableBool(obj);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ToNullableBoolWithoutCultureTest()
            {
                object obj = 1;
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                Nullable<bool> expected = new Nullable<bool>(true);
                Nullable<bool> actual;
                actual = Conversao.ToNullableBool(obj, culture);
                Assert.AreEqual(expected, actual);
            }








            [Test]
            public void ToBoolWithCultureTest2()
            {
                object obj = 0;
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                bool expected = false;
                bool actual;
                actual = Conversao.ToBool(obj, culture);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ToBoolWithoutCultureTest2()
            {
                object obj = 0;
                bool expected = false;
                bool actual;
                actual = Conversao.ToBool(obj);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ToNullableBoolWithCultureTest2()
            {
                object obj = 0;
                Nullable<bool> expected = new Nullable<bool>(false);
                Nullable<bool> actual;
                actual = Conversao.ToNullableBool(obj);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ToNullableBoolWithoutCultureTest2()
            {
                object obj = 0;
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                Nullable<bool> expected = new Nullable<bool>(false);
                Nullable<bool> actual;
                actual = Conversao.ToNullableBool(obj, culture);
                Assert.AreEqual(expected, actual);
            }





            [Test]
            public void ToNullableBoolWithCultureTest3()
            {
                object obj = null;
                Nullable<bool> expected = new Nullable<bool>();
                Nullable<bool> actual;
                actual = Conversao.ToNullableBool(obj);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ToNullableBoolWithoutCultureTest3()
            {
                object obj = null;
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                Nullable<bool> expected = new Nullable<bool>();
                Nullable<bool> actual;
                actual = Conversao.ToNullableBool(obj, culture);
                Assert.AreEqual(expected, actual);
            }


        }


        #endregion

        #region conversao object/string para DateTime 


        [TestFixture]
        public class TesteConversaoToDatetimeNovo
        {

            [Test]
            public void NullToDateTimeTest()
            {
                object obj = null;
                DateTime expected = DateTime.MinValue;
                DateTime actual;
                actual = Conversao.ToDateTime(obj);
                Assert.AreEqual(expected, actual);

            }


            [Test]
            public void NullToDateTimeCultureTest()
            {
                object obj = null;
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                DateTime expected = DateTime.MinValue;
                DateTime actual;
                actual = Conversao.ToDateTime(obj, culture);
                Assert.AreEqual(expected, actual);

            }



            [Test]
            public void StringToDateTimeTest()
            {
                object obj = "14/02/1983";
                DateTime expected = new DateTime(1983, 02, 14);
                DateTime actual;
                actual = Conversao.ToDateTime(obj);
                Assert.AreEqual(expected, actual);

            }


            [Test]
            public void StringToDateTimeCultureTest()
            {
                object obj = "14/02/1983";
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                DateTime expected = new DateTime(1983, 02, 14);
                DateTime actual;
                actual = Conversao.ToDateTime(obj, culture);
                Assert.AreEqual(expected, actual);

            }


            [Test]
            public void ToNullableDateTimeTest()
            {
                object obj = null;
                DateTime? expected = null;
                DateTime? actual;
                actual = Conversao.ToNullableDateTime(obj);
                Assert.AreEqual(expected, actual);

            }


            [Test]
            public void ToNullableDateTimeCultureTest()
            {
                object obj = null;
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                DateTime? expected = null;
                DateTime? actual;
                actual = Conversao.ToNullableDateTime(obj, culture);
                Assert.AreEqual(expected, actual);

            }


            [Test]
            public void BlankStringToDateTimeTest()
            {
                object obj = " ";
                DateTime? expected = null;
                DateTime? actual;
                actual = Conversao.ToNullableDateTime(obj);
                Assert.AreEqual(expected, actual);

            }


            [Test]
            public void BlankStringToDateTimeCultureTest()
            {
                object obj = " ";
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                DateTime? expected = null;
                DateTime? actual;
                actual = Conversao.ToNullableDateTime(obj, culture);
                Assert.AreEqual(expected, actual);

            }


            [Test]
            public void StringToNullableDateTimeTest()
            {
                object obj = "14/02/1983";
                DateTime? expected = new DateTime(1983, 02, 14);
                DateTime? actual;
                actual = Conversao.ToNullableDateTime(obj);
                Assert.AreEqual(expected, actual);

            }


            [Test]
            public void StringToNullableDateTimeCultureTest()
            {
                object obj = "14/02/1983";
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                DateTime? expected = new DateTime(1983, 02, 14);
                DateTime? actual;
                actual = Conversao.ToNullableDateTime(obj, culture);
                Assert.AreEqual(expected, actual);

            }

        }


        #endregion

        #region conversao de object/string para double 

        [TestFixture]
        public class ObjectToDoubleNovo
        {

            [Test]
            public void NullToDoubleTest()
            {
                object obj = null;
                double expected = 0F;
                double actual;
                actual = Conversao.ToDouble(obj);
                Assert.AreEqual(expected, actual);

            }


            [Test]
            public void NullToDoubleCultureTest()
            {
                object obj = null;
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                double expected = 0F;
                double actual;
                actual = Conversao.ToDouble(obj, culture);
                Assert.AreEqual(expected, actual);

            }


            [Test]
            public void NullToDoubleStyleCultureTest()
            {
                object obj = null;
                NumberStyles style = Conversao.DEFAULT_FLOAT_STYLE;
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                double expected = 0F;
                double actual;
                actual = Conversao.ToDouble(obj, style, culture);
                Assert.AreEqual(expected, actual);

            }




            [Test]
            public void NullToDoubleStyleTest()
            {
                object obj = null;
                NumberStyles style = Conversao.DEFAULT_FLOAT_STYLE;
                double expected = 0F;
                double actual;
                actual = Conversao.ToDouble(obj, style);
                Assert.AreEqual(expected, actual);

            }

















            [Test]
            public void BlankStringToDoubleTest()
            {
                object obj = "";
                double expected = 0F;
                double actual;
                actual = Conversao.ToDouble(obj);
                Assert.AreEqual(expected, actual);

            }


            [Test]
            public void BlankStringToDoubleCultureTest()
            {
                object obj = "";
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                double expected = 0F;
                double actual;
                actual = Conversao.ToDouble(obj, culture);
                Assert.AreEqual(expected, actual);

            }


            [Test]
            public void BlankStringToDoubleStyleCultureTest()
            {
                object obj = "";
                NumberStyles style = Conversao.DEFAULT_FLOAT_STYLE;
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                double expected = 0F;
                double actual;
                actual = Conversao.ToDouble(obj, style, culture);
                Assert.AreEqual(expected, actual);

            }




            [Test]
            public void BlankStringToDoubleStyleTest()
            {
                object obj = "";
                NumberStyles style = Conversao.DEFAULT_FLOAT_STYLE;
                double expected = 0F;
                double actual;
                actual = Conversao.ToDouble(obj, style);
                Assert.AreEqual(expected, actual);

            }


















            [Test]
            public void StringToDoubleTest()
            {
                object obj = "-999.999.999.999,12";
                double expected = -999999999999.12;
                double actual;
                actual = Conversao.ToDouble(obj);
                Assert.AreEqual(expected, actual);

            }


            [Test]
            public void StringToDoubleCultureTest()
            {
                object obj = "-999.999.999.999,12";
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                double expected = -999999999999.12;
                double actual;
                actual = Conversao.ToDouble(obj, culture);
                Assert.AreEqual(expected, actual);

            }


            [Test]
            public void StringToDoubleStyleCultureTest()
            {
                object obj = "-999.999.999.999,12";
                NumberStyles style = Conversao.DEFAULT_FLOAT_STYLE;
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                double expected = -999999999999.12;
                double actual;
                actual = Conversao.ToDouble(obj, style, culture);
                Assert.AreEqual(expected, actual);

            }




            [Test]
            public void StringToDoubleStyleTest()
            {
                object obj = "-999.999.999.999,12";
                NumberStyles style = Conversao.DEFAULT_FLOAT_STYLE;
                double expected = -999999999999.12;
                double actual;
                actual = Conversao.ToDouble(obj, style);
                Assert.AreEqual(expected, actual);

            }



            [Test]
            public void NullToNullableDoubleTest()
            {
                object obj = null;
                double? expected = null;
                double? actual;
                actual = Conversao.ToNullableDouble(obj);
                Assert.AreEqual(expected, actual);

            }


            [Test]
            public void NullToNullableDoubleCultureTest()
            {
                object obj = null;
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                double? expected = null;
                double? actual;
                actual = Conversao.ToNullableDouble(obj, culture);
                Assert.AreEqual(expected, actual);

            }


            [Test]
            public void NullToNullableDoubleStyleCultureTest()
            {
                object obj = null;
                NumberStyles style = Conversao.DEFAULT_FLOAT_STYLE;
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                double? expected = null;
                double? actual;
                actual = Conversao.ToNullableDouble(obj, style, culture);
                Assert.AreEqual(expected, actual);

            }




            [Test]
            public void NullToNullableDoubleStyleTest()
            {
                object obj = null;
                NumberStyles style = Conversao.DEFAULT_FLOAT_STYLE;
                double? expected = null;
                double? actual;
                actual = Conversao.ToNullableDouble(obj, style);
                Assert.AreEqual(expected, actual);

            }




            [Test]
            public void BlankStringToNullableDoubleTest()
            {
                object obj = "";
                double? expected = null;
                double? actual;
                actual = Conversao.ToNullableDouble(obj);
                Assert.AreEqual(expected, actual);

            }


            [Test]
            public void BlankStringToNullableDoubleCultureTest()
            {
                object obj = "";
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                double? expected = null;
                double? actual;
                actual = Conversao.ToNullableDouble(obj, culture);
                Assert.AreEqual(expected, actual);

            }


            [Test]
            public void BlankStringToNullableDoubleStyleCultureTest()
            {
                object obj = "";
                NumberStyles style = Conversao.DEFAULT_FLOAT_STYLE;
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                double? expected = null;
                double? actual;
                actual = Conversao.ToNullableDouble(obj, style, culture);
                Assert.AreEqual(expected, actual);

            }




            [Test]
            public void BlankStringNullableToDoubleStyleTest()
            {
                object obj = "";
                NumberStyles style = Conversao.DEFAULT_FLOAT_STYLE;
                double? expected = null;
                double? actual;
                actual = Conversao.ToNullableDouble(obj, style);
                Assert.AreEqual(expected, actual);

            }


















            [Test]
            public void StringToNullableDoubleTest()
            {
                object obj = "-999.999.999.999,12";
                double? expected = -999999999999.12;
                double? actual;
                actual = Conversao.ToNullableDouble(obj);
                Assert.AreEqual(expected, actual);

            }


            [Test]
            public void StringToNullableDoubleCultureTest()
            {
                object obj = "-999.999.999.999,12";
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                double? expected = -999999999999.12;
                double? actual;
                actual = Conversao.ToNullableDouble(obj, culture);
                Assert.AreEqual(expected, actual);

            }


            [Test]
            public void StringToNullableDoubleStyleCultureTest()
            {
                object obj = "-999.999.999.999,12";
                NumberStyles style = Conversao.DEFAULT_FLOAT_STYLE;
                CultureInfo culture = Conversao.DEFAULT_CULTURE_INFO;
                double? expected = -999999999999.12;
                double? actual;
                actual = Conversao.ToNullableDouble(obj, style, culture);
                Assert.AreEqual(expected, actual);

            }




            [Test]
            public void StringToNullableDoubleStyleTest()
            {
                object obj = "-999.999.999.999,12";
                NumberStyles style = Conversao.DEFAULT_FLOAT_STYLE;
                double? expected = -999999999999.12;
                double? actual;
                actual = Conversao.ToNullableDouble(obj, style);
                Assert.AreEqual(expected, actual);

            }
        }

        #endregion









        ///// <summary>
        /////A test for ToDBNull
        /////</summary>
        //[Test]
        //public void ToDBNullTest()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    object expected = null; // TODO: Initialize to an appropriate value
        //    object actual;
        //    actual = Conversao.ToDBNull(obj);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToDateTime
        /////</summary>
        //[Test]
        //public void ToDateTimeTest()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    CultureInfo culture = null; // TODO: Initialize to an appropriate value
        //    DateTime expected = new DateTime(); // TODO: Initialize to an appropriate value
        //    DateTime actual;
        //    actual = Conversao.ToDateTime(obj, culture);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToDateTime
        /////</summary>
        //[Test]
        //public void ToDateTimeTest1()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    DateTime expected = new DateTime(); // TODO: Initialize to an appropriate value
        //    DateTime actual;
        //    actual = Conversao.ToDateTime(obj);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToDouble
        /////</summary>
        //[Test]
        //public void ToDoubleTest()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    NumberStyles style = new NumberStyles(); // TODO: Initialize to an appropriate value
        //    CultureInfo culture = null; // TODO: Initialize to an appropriate value
        //    double expected = 0F; // TODO: Initialize to an appropriate value
        //    double actual;
        //    actual = Conversao.ToDouble(obj, style, culture);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToDouble
        /////</summary>
        //[Test]
        //public void ToDoubleTest1()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    NumberStyles style = new NumberStyles(); // TODO: Initialize to an appropriate value
        //    double expected = 0F; // TODO: Initialize to an appropriate value
        //    double actual;
        //    actual = Conversao.ToDouble(obj, style);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToDouble
        /////</summary>
        //[Test]
        //public void ToDoubleTest2()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    CultureInfo culture = null; // TODO: Initialize to an appropriate value
        //    double expected = 0F; // TODO: Initialize to an appropriate value
        //    double actual;
        //    actual = Conversao.ToDouble(obj, culture);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToDouble
        /////</summary>
        //[Test]
        //public void ToDoubleTest3()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    double expected = 0F; // TODO: Initialize to an appropriate value
        //    double actual;
        //    actual = Conversao.ToDouble(obj);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToInt64
        /////</summary>
        //[Test]
        //public void ToInt64Test()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    long expected = 0; // TODO: Initialize to an appropriate value
        //    long actual;
        //    actual = Conversao.ToInt64(obj);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToInt64
        /////</summary>
        //[Test]
        //public void ToInt64Test1()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    NumberStyles style = new NumberStyles(); // TODO: Initialize to an appropriate value
        //    CultureInfo culture = null; // TODO: Initialize to an appropriate value
        //    long expected = 0; // TODO: Initialize to an appropriate value
        //    long actual;
        //    actual = Conversao.ToInt64(obj, style, culture);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToInt64
        /////</summary>
        //[Test]
        //public void ToInt64Test2()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    CultureInfo culture = null; // TODO: Initialize to an appropriate value
        //    long expected = 0; // TODO: Initialize to an appropriate value
        //    long actual;
        //    actual = Conversao.ToInt64(obj, culture);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToInt64
        /////</summary>
        //[Test]
        //public void ToInt64Test3()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    NumberStyles style = new NumberStyles(); // TODO: Initialize to an appropriate value
        //    long expected = 0; // TODO: Initialize to an appropriate value
        //    long actual;
        //    actual = Conversao.ToInt64(obj, style);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToInteger
        /////</summary>
        //[Test]
        //public void ToIntegerTest()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    int expected = 0; // TODO: Initialize to an appropriate value
        //    int actual;
        //    actual = Conversao.ToInteger(obj);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToInteger
        /////</summary>
        //[Test]
        //public void ToIntegerTest1()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    NumberStyles style = new NumberStyles(); // TODO: Initialize to an appropriate value
        //    int expected = 0; // TODO: Initialize to an appropriate value
        //    int actual;
        //    actual = Conversao.ToInteger(obj, style);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToInteger
        /////</summary>
        //[Test]
        //public void ToIntegerTest2()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    CultureInfo culture = null; // TODO: Initialize to an appropriate value
        //    int expected = 0; // TODO: Initialize to an appropriate value
        //    int actual;
        //    actual = Conversao.ToInteger(obj, culture);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToInteger
        /////</summary>
        //[Test]
        //public void ToIntegerTest3()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    NumberStyles style = new NumberStyles(); // TODO: Initialize to an appropriate value
        //    CultureInfo culture = null; // TODO: Initialize to an appropriate value
        //    int expected = 0; // TODO: Initialize to an appropriate value
        //    int actual;
        //    actual = Conversao.ToInteger(obj, style, culture);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToNullableBool
        /////</summary>
        //[Test]
        //public void ToNullableBoolTest()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    Nullable<bool> expected = new Nullable<bool>(); // TODO: Initialize to an appropriate value
        //    Nullable<bool> actual;
        //    actual = Conversao.ToNullableBool(obj);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToNullableBool
        /////</summary>
        //[Test]
        //public void ToNullableBoolTest1()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    CultureInfo culture = null; // TODO: Initialize to an appropriate value
        //    Nullable<bool> expected = new Nullable<bool>(); // TODO: Initialize to an appropriate value
        //    Nullable<bool> actual;
        //    actual = Conversao.ToNullableBool(obj, culture);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToNullableDateTime
        /////</summary>
        //[Test]
        //public void ToNullableDateTimeTest()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    CultureInfo culture = null; // TODO: Initialize to an appropriate value
        //    Nullable<DateTime> expected = new Nullable<DateTime>(); // TODO: Initialize to an appropriate value
        //    Nullable<DateTime> actual;
        //    actual = Conversao.ToNullableDateTime(obj, culture);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToNullableDateTime
        /////</summary>
        //[Test]
        //public void ToNullableDateTimeTest1()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    Nullable<DateTime> expected = new Nullable<DateTime>(); // TODO: Initialize to an appropriate value
        //    Nullable<DateTime> actual;
        //    actual = Conversao.ToNullableDateTime(obj);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToNullableDouble
        /////</summary>
        //[Test]
        //public void ToNullableDoubleTest()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    Nullable<double> expected = new Nullable<double>(); // TODO: Initialize to an appropriate value
        //    Nullable<double> actual;
        //    actual = Conversao.ToNullableDouble(obj);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToNullableDouble
        /////</summary>
        //[Test]
        //public void ToNullableDoubleTest1()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    NumberStyles style = new NumberStyles(); // TODO: Initialize to an appropriate value
        //    Nullable<double> expected = new Nullable<double>(); // TODO: Initialize to an appropriate value
        //    Nullable<double> actual;
        //    actual = Conversao.ToNullableDouble(obj, style);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToNullableDouble
        /////</summary>
        //[Test]
        //public void ToNullableDoubleTest2()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    NumberStyles style = new NumberStyles(); // TODO: Initialize to an appropriate value
        //    CultureInfo culture = null; // TODO: Initialize to an appropriate value
        //    Nullable<double> expected = new Nullable<double>(); // TODO: Initialize to an appropriate value
        //    Nullable<double> actual;
        //    actual = Conversao.ToNullableDouble(obj, style, culture);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToNullableDouble
        /////</summary>
        //[Test]
        //public void ToNullableDoubleTest3()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    CultureInfo culture = null; // TODO: Initialize to an appropriate value
        //    Nullable<double> expected = new Nullable<double>(); // TODO: Initialize to an appropriate value
        //    Nullable<double> actual;
        //    actual = Conversao.ToNullableDouble(obj, culture);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToNullableInt64
        /////</summary>
        //[Test]
        //public void ToNullableInt64Test()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    Nullable<long> expected = new Nullable<long>(); // TODO: Initialize to an appropriate value
        //    Nullable<long> actual;
        //    actual = Conversao.ToNullableInt64(obj);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToNullableInt64
        /////</summary>
        //[Test]
        //public void ToNullableInt64Test1()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    NumberStyles style = new NumberStyles(); // TODO: Initialize to an appropriate value
        //    CultureInfo culture = null; // TODO: Initialize to an appropriate value
        //    Nullable<long> expected = new Nullable<long>(); // TODO: Initialize to an appropriate value
        //    Nullable<long> actual;
        //    actual = Conversao.ToNullableInt64(obj, style, culture);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToNullableInt64
        /////</summary>
        //[Test]
        //public void ToNullableInt64Test2()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    NumberStyles style = new NumberStyles(); // TODO: Initialize to an appropriate value
        //    Nullable<long> expected = new Nullable<long>(); // TODO: Initialize to an appropriate value
        //    Nullable<long> actual;
        //    actual = Conversao.ToNullableInt64(obj, style);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToNullableInt64
        /////</summary>
        //[Test]
        //public void ToNullableInt64Test3()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    CultureInfo culture = null; // TODO: Initialize to an appropriate value
        //    Nullable<long> expected = new Nullable<long>(); // TODO: Initialize to an appropriate value
        //    Nullable<long> actual;
        //    actual = Conversao.ToNullableInt64(obj, culture);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToNullableInteger
        /////</summary>
        //[Test]
        //public void ToNullableIntegerTest()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    NumberStyles style = new NumberStyles(); // TODO: Initialize to an appropriate value
        //    Nullable<int> expected = new Nullable<int>(); // TODO: Initialize to an appropriate value
        //    Nullable<int> actual;
        //    actual = Conversao.ToNullableInteger(obj, style);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToNullableInteger
        /////</summary>
        //[Test]
        //public void ToNullableIntegerTest1()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    Nullable<int> expected = new Nullable<int>(); // TODO: Initialize to an appropriate value
        //    Nullable<int> actual;
        //    actual = Conversao.ToNullableInteger(obj);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToNullableInteger
        /////</summary>
        //[Test]
        //public void ToNullableIntegerTest2()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    NumberStyles style = new NumberStyles(); // TODO: Initialize to an appropriate value
        //    CultureInfo culture = null; // TODO: Initialize to an appropriate value
        //    Nullable<int> expected = new Nullable<int>(); // TODO: Initialize to an appropriate value
        //    Nullable<int> actual;
        //    actual = Conversao.ToNullableInteger(obj, style, culture);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToNullableInteger
        /////</summary>
        //[Test]
        //public void ToNullableIntegerTest3()
        //{
        //    object obj = null; // TODO: Initialize to an appropriate value
        //    CultureInfo culture = null; // TODO: Initialize to an appropriate value
        //    Nullable<int> expected = new Nullable<int>(); // TODO: Initialize to an appropriate value
        //    Nullable<int> actual;
        //    actual = Conversao.ToNullableInteger(obj, culture);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToString
        /////</summary>
        //[Test]
        //public void ToStringTest()
        //{
        //    Nullable<bool> flag = new Nullable<bool>(); // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = Conversao.ToString(flag);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToString
        /////</summary>
        //[Test]
        //public void ToStringTest1()
        //{
        //    Nullable<bool> flag = new Nullable<bool>(); // TODO: Initialize to an appropriate value
        //    string valorSeNull = string.Empty; // TODO: Initialize to an appropriate value
        //    string valorSeTrue = string.Empty; // TODO: Initialize to an appropriate value
        //    string valorSeFalse = string.Empty; // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = Conversao.ToString(flag, valorSeNull, valorSeTrue, valorSeFalse);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToString
        /////</summary>
        //[Test]
        //public void ToStringTest2()
        //{
        //    Nullable<long> numero = new Nullable<long>(); // TODO: Initialize to an appropriate value
        //    string format = string.Empty; // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = Conversao.ToString(numero, format);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToString
        /////</summary>
        //[Test]
        //public void ToStringTest3()
        //{
        //    Nullable<bool> flag = new Nullable<bool>(); // TODO: Initialize to an appropriate value
        //    CultureInfo culture = null; // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = Conversao.ToString(flag, culture);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToString
        /////</summary>
        //[Test]
        //public void ToStringTest4()
        //{
        //    Nullable<double> numero = new Nullable<double>(); // TODO: Initialize to an appropriate value
        //    string format = string.Empty; // TODO: Initialize to an appropriate value
        //    IFormatProvider culture = null; // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = Conversao.ToString(numero, format, culture);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToString
        /////</summary>
        //[Test]
        //public void ToStringTest5()
        //{
        //    Nullable<double> numero = new Nullable<double>(); // TODO: Initialize to an appropriate value
        //    string format = string.Empty; // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = Conversao.ToString(numero, format);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToString
        /////</summary>
        //[Test]
        //public void ToStringTest6()
        //{
        //    Nullable<double> numero = new Nullable<double>(); // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = Conversao.ToString(numero);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToString
        /////</summary>
        //[Test]
        //public void ToStringTest7()
        //{
        //    Nullable<long> numero = new Nullable<long>(); // TODO: Initialize to an appropriate value
        //    string format = string.Empty; // TODO: Initialize to an appropriate value
        //    IFormatProvider culture = null; // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = Conversao.ToString(numero, format, culture);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToString
        /////</summary>
        //[Test]
        //public void ToStringTest8()
        //{
        //    Nullable<DateTime> data = new Nullable<DateTime>(); // TODO: Initialize to an appropriate value
        //    string format = string.Empty; // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = Conversao.ToString(data, format);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToString
        /////</summary>
        //[Test]
        //public void ToStringTest9()
        //{
        //    Nullable<DateTime> data = new Nullable<DateTime>(); // TODO: Initialize to an appropriate value
        //    string format = string.Empty; // TODO: Initialize to an appropriate value
        //    IFormatProvider culture = null; // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = Conversao.ToString(data, format, culture);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToString
        /////</summary>
        //[Test]
        //public void ToStringTest10()
        //{
        //    Nullable<long> numero = new Nullable<long>(); // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = Conversao.ToString(numero);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToString
        /////</summary>
        //[Test]
        //public void ToStringTest11()
        //{
        //    Nullable<DateTime> data = new Nullable<DateTime>(); // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = Conversao.ToString(data);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToString
        /////</summary>
        //[Test]
        //public void ToStringTest12()
        //{
        //    Nullable<int> numero = new Nullable<int>(); // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = Conversao.ToString(numero);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToString
        /////</summary>
        //[Test]
        //public void ToStringTest13()
        //{
        //    Nullable<int> numero = new Nullable<int>(); // TODO: Initialize to an appropriate value
        //    string format = string.Empty; // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = Conversao.ToString(numero, format);
        //    Assert.AreEqual(expected, actual);
            
        //}

        ///// <summary>
        /////A test for ToString
        /////</summary>
        //[Test]
        //public void ToStringTest14()
        //{
        //    Nullable<int> numero = new Nullable<int>(); // TODO: Initialize to an appropriate value
        //    string format = string.Empty; // TODO: Initialize to an appropriate value
        //    IFormatProvider culture = null; // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = Conversao.ToString(numero, format, culture);
        //    Assert.AreEqual(expected, actual);
            
        //}

        /// <summary>
        ///A test for TrimNull
        ///</summary>
        [Test]
        public void TrimNullTest()
        {
            object obj = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = Conversao.TrimNull(obj);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for DEFAULT_CULTURE_INFO
        ///</summary>
        [Test]
        public void DEFAULT_CULTURE_INFOTest()
        {
            CultureInfo actual;
            actual = Conversao.DEFAULT_CULTURE_INFO;
            
        }

        /// <summary>
        ///A test for DEFAULT_DATETIME_FORMAT
        ///</summary>
        [Test]
        public void DEFAULT_DATETIME_FORMATTest()
        {
            string actual;
            actual = Conversao.DEFAULT_DATETIME_FORMAT;
            
        }

        /// <summary>
        ///A test for DEFAULT_DATE_FORMAT
        ///</summary>
        [Test]
        public void DEFAULT_DATE_FORMATTest()
        {
            string actual;
            actual = Conversao.DEFAULT_DATE_FORMAT;
            
        }



        /// <summary>
        ///A test for DEFAULT_FLOAT_STYLE
        ///</summary>
        [Test]
        public void DEFAULT_FLOAT_STYLETest()
        {
            NumberStyles actual;
            actual = Conversao.DEFAULT_FLOAT_STYLE;
            
        }

        /// <summary>
        ///A test for DEFAULT_INTEGER_FORMAT
        ///</summary>
        [Test]
        public void DEFAULT_INTEGER_FORMATTest()
        {
            string actual;
            actual = Conversao.DEFAULT_INTEGER_FORMAT;
            
        }

        /// <summary>
        ///A test for DEFAULT_INTEGER_STYLE
        ///</summary>
        [Test]
        public void DEFAULT_INTEGER_STYLETest()
        {
            NumberStyles actual;
            actual = Conversao.DEFAULT_INTEGER_STYLE;
            
        }





        [TestFixture]
        public class OutrosTestes
        {
            [Test]
            public void DoubleSemParametrosDeveriaVirPadrao()
            {
                double teste = 1;
                string esperado = "1,00";
                string actual = Conversao.ToString(teste);
                Assert.AreEqual(esperado, actual);
            }

            [Test]
            public void DoubleComParametro_R_DeveriaVirComDecimaisOpcionais()
            {
                double teste = 1;
                string esperado = "1";

                string stesteF = teste.ToString("F", new CultureInfo("pt-BR"));
                string stesteG = teste.ToString("G", new CultureInfo("pt-BR"));
                string stesteN = teste.ToString("N", new CultureInfo("pt-BR"));
                string stesteC = teste.ToString("C", new CultureInfo("pt-BR"));
                string stesteR = teste.ToString("R", new CultureInfo("pt-BR"));

                string actual = Conversao.ToString(teste, "R", Conversao.DEFAULT_CULTURE_INFO);
                Assert.AreEqual(esperado, actual);
            }

            [Test]
            public void DoubleComApenasParametro_R_DeveriaVirComDecimaisOpcionais()
            {
                double teste = 1;
                string esperado = "1";

                string stesteF = teste.ToString("F");
                string stesteG = teste.ToString("G");
                string stesteN = teste.ToString("N");
                string stesteC = teste.ToString("C");
                string stesteR = teste.ToString("R");

                string actual = Conversao.ToString(teste, "R");
                Assert.AreEqual(esperado, actual);
            }
        }



    }
}
