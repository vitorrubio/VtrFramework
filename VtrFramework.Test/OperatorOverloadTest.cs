using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtrFramework.Test
{

    [TestFixture]
    public class AllTypecastsOperatorOverloadTest
    {
        [TestFixture]
        public class ImplicitInt32OperatorOverloadTest
        {
            [Test]
            public void EqualsOperatorTest()
            {
                Foo f1 = new Foo(1);
                int i1 = 1;
                int i2 = 2;

                Console.WriteLine("f1 == i1");
                Assert.IsTrue(f1 == i1);
                Console.WriteLine("i1 == f1");
                Assert.IsTrue(i1 == f1);

                Console.WriteLine("f1 == 1");
                Assert.IsTrue(f1 == 1);
                Console.WriteLine("1 == f1");
                Assert.IsTrue(1 == f1);


                Console.WriteLine("f1 == i2");
                Assert.IsFalse(f1 == i2);
                Console.WriteLine("i2 == f1");
                Assert.IsFalse(i2 == f1);

                Console.WriteLine("f1 == 2");
                Assert.IsFalse(f1 == 2);
                Console.WriteLine("2 == f1");
                Assert.IsFalse(2 == f1);
            }


            [Test]
            public void UnequalsOperatorTest()
            {
                Foo f1 = new Foo(1);
                int i1 = 1;
                int i2 = 2;

                Console.WriteLine("f1 != i1");
                Assert.IsFalse(f1 != i1);
                Console.WriteLine("i1 != f1");
                Assert.IsFalse(i1 != f1);

                Console.WriteLine("f1 != 1");
                Assert.IsFalse(f1 != 1);
                Console.WriteLine("1 != f1");
                Assert.IsFalse(1 != f1);


                Console.WriteLine("f1 != i2");
                Assert.IsTrue(f1 != i2);
                Console.WriteLine("i2 != f1");
                Assert.IsTrue(i2 != f1);

                Console.WriteLine("f1 != 2");
                Assert.IsTrue(f1 != 2);
                Console.WriteLine("2 != f1");
                Assert.IsTrue(2 != f1);
            }
        }


        [TestFixture]
        public class ImplicitUInt32OperatorOverloadTest
        {
            [Test]
            public void EqualsOperatorTest()
            {
                Foo f1 = new Foo(1);
                UInt32 i1 = 1;
                UInt32 i2 = 2;

                Console.WriteLine("f1 == i1");
                Assert.IsTrue(f1 == i1);
                Console.WriteLine("i1 == f1");
                Assert.IsTrue(i1 == f1);

                Console.WriteLine("f1 == 1");
                Assert.IsTrue(f1 == 1);
                Console.WriteLine("1 == f1");
                Assert.IsTrue(1 == f1);


                Console.WriteLine("f1 == i2");
                Assert.IsFalse(f1 == i2);
                Console.WriteLine("i2 == f1");
                Assert.IsFalse(i2 == f1);

                Console.WriteLine("f1 == 2");
                Assert.IsFalse(f1 == 2);
                Console.WriteLine("2 == f1");
                Assert.IsFalse(2 == f1);
            }


            [Test]
            public void UnequalsOperatorTest()
            {
                Foo f1 = new Foo(1);
                UInt32 i1 = 1;
                UInt32 i2 = 2;

                Console.WriteLine("f1 != i1");
                Assert.IsFalse(f1 != i1);
                Console.WriteLine("i1 != f1");
                Assert.IsFalse(i1 != f1);

                Console.WriteLine("f1 != 1");
                Assert.IsFalse(f1 != 1);
                Console.WriteLine("1 != f1");
                Assert.IsFalse(1 != f1);


                Console.WriteLine("f1 != i2");
                Assert.IsTrue(f1 != i2);
                Console.WriteLine("i2 != f1");
                Assert.IsTrue(i2 != f1);

                Console.WriteLine("f1 != 2");
                Assert.IsTrue(f1 != 2);
                Console.WriteLine("2 != f1");
                Assert.IsTrue(2 != f1);
            }
        }

        [TestFixture]
        public class ImplicitInt16OperatorOverloadTest
        {
            [Test]
            public void EqualsOperatorTest()
            {
                Foo f1 = new Foo(1);
                Int16 i1 = 1;
                Int16 i2 = 2;

                Console.WriteLine("f1 == i1");
                Assert.IsTrue(f1 == i1);
                Console.WriteLine("i1 == f1");
                Assert.IsTrue(i1 == f1);

                Console.WriteLine("f1 == 1");
                Assert.IsTrue(f1 == 1);
                Console.WriteLine("1 == f1");
                Assert.IsTrue(1 == f1);


                Console.WriteLine("f1 == i2");
                Assert.IsFalse(f1 == i2);
                Console.WriteLine("i2 == f1");
                Assert.IsFalse(i2 == f1);

                Console.WriteLine("f1 == 2");
                Assert.IsFalse(f1 == 2);
                Console.WriteLine("2 == f1");
                Assert.IsFalse(2 == f1);
            }


            [Test]
            public void UnequalsOperatorTest()
            {
                Foo f1 = new Foo(1);
                Int16 i1 = 1;
                Int16 i2 = 2;

                Console.WriteLine("f1 != i1");
                Assert.IsFalse(f1 != i1);
                Console.WriteLine("i1 != f1");
                Assert.IsFalse(i1 != f1);

                Console.WriteLine("f1 != 1");
                Assert.IsFalse(f1 != 1);
                Console.WriteLine("1 != f1");
                Assert.IsFalse(1 != f1);


                Console.WriteLine("f1 != i2");
                Assert.IsTrue(f1 != i2);
                Console.WriteLine("i2 != f1");
                Assert.IsTrue(i2 != f1);

                Console.WriteLine("f1 != 2");
                Assert.IsTrue(f1 != 2);
                Console.WriteLine("2 != f1");
                Assert.IsTrue(2 != f1);
            }
        }

        [TestFixture]
        public class ImplicitUInt16OperatorOverloadTest
        {
            [Test]
            public void EqualsOperatorTest()
            {
                Foo f1 = new Foo(1);
                UInt16 i1 = 1;
                UInt16 i2 = 2;

                Console.WriteLine("f1 == i1");
                Assert.IsTrue(f1 == i1);
                Console.WriteLine("i1 == f1");
                Assert.IsTrue(i1 == f1);

                Console.WriteLine("f1 == 1");
                Assert.IsTrue(f1 == 1);
                Console.WriteLine("1 == f1");
                Assert.IsTrue(1 == f1);


                Console.WriteLine("f1 == i2");
                Assert.IsFalse(f1 == i2);
                Console.WriteLine("i2 == f1");
                Assert.IsFalse(i2 == f1);

                Console.WriteLine("f1 == 2");
                Assert.IsFalse(f1 == 2);
                Console.WriteLine("2 == f1");
                Assert.IsFalse(2 == f1);
            }


            [Test]
            public void UnequalsOperatorTest()
            {
                Foo f1 = new Foo(1);
                UInt16 i1 = 1;
                UInt16 i2 = 2;

                Console.WriteLine("f1 != i1");
                Assert.IsFalse(f1 != i1);
                Console.WriteLine("i1 != f1");
                Assert.IsFalse(i1 != f1);

                Console.WriteLine("f1 != 1");
                Assert.IsFalse(f1 != 1);
                Console.WriteLine("1 != f1");
                Assert.IsFalse(1 != f1);


                Console.WriteLine("f1 != i2");
                Assert.IsTrue(f1 != i2);
                Console.WriteLine("i2 != f1");
                Assert.IsTrue(i2 != f1);

                Console.WriteLine("f1 != 2");
                Assert.IsTrue(f1 != 2);
                Console.WriteLine("2 != f1");
                Assert.IsTrue(2 != f1);
            }
        }


        [TestFixture]
        public class ImplicitInt64OperatorOverloadTest
        {
            [Test]
            public void EqualsOperatorTest()
            {
                Foo f1 = new Foo(1);
                Int64 i1 = 1;
                Int64 i2 = 2;

                Console.WriteLine("f1 == i1");
                Assert.IsTrue(f1 == i1);
                Console.WriteLine("i1 == f1");
                Assert.IsTrue(i1 == f1);

                Console.WriteLine("f1 == 1");
                Assert.IsTrue(f1 == 1);
                Console.WriteLine("1 == f1");
                Assert.IsTrue(1 == f1);


                Console.WriteLine("f1 == i2");
                Assert.IsFalse(f1 == i2);
                Console.WriteLine("i2 == f1");
                Assert.IsFalse(i2 == f1);

                Console.WriteLine("f1 == 2");
                Assert.IsFalse(f1 == 2);
                Console.WriteLine("2 == f1");
                Assert.IsFalse(2 == f1);
            }


            [Test]
            public void UnequalsOperatorTest()
            {
                Foo f1 = new Foo(1);
                Int64 i1 = 1;
                Int64 i2 = 2;

                Console.WriteLine("f1 != i1");
                Assert.IsFalse(f1 != i1);
                Console.WriteLine("i1 != f1");
                Assert.IsFalse(i1 != f1);

                Console.WriteLine("f1 != 1");
                Assert.IsFalse(f1 != 1);
                Console.WriteLine("1 != f1");
                Assert.IsFalse(1 != f1);


                Console.WriteLine("f1 != i2");
                Assert.IsTrue(f1 != i2);
                Console.WriteLine("i2 != f1");
                Assert.IsTrue(i2 != f1);

                Console.WriteLine("f1 != 2");
                Assert.IsTrue(f1 != 2);
                Console.WriteLine("2 != f1");
                Assert.IsTrue(2 != f1);
            }
        }



        [TestFixture]
        public class ImplicitUInt64OperatorOverloadTest
        {
            [Test]
            public void EqualsOperatorTest()
            {
                Foo f1 = new Foo(1);
                UInt64 i1 = 1;
                UInt64 i2 = 2;

                Console.WriteLine("f1 == i1");
                Assert.IsTrue(f1 == i1);
                Console.WriteLine("i1 == f1");
                Assert.IsTrue(i1 == f1);

                Console.WriteLine("f1 == 1");
                Assert.IsTrue(f1 == 1);
                Console.WriteLine("1 == f1");
                Assert.IsTrue(1 == f1);


                Console.WriteLine("f1 == i2");
                Assert.IsFalse(f1 == i2);
                Console.WriteLine("i2 == f1");
                Assert.IsFalse(i2 == f1);

                Console.WriteLine("f1 == 2");
                Assert.IsFalse(f1 == 2);
                Console.WriteLine("2 == f1");
                Assert.IsFalse(2 == f1);
            }


            [Test]
            public void UnequalsOperatorTest()
            {
                Foo f1 = new Foo(1);
                UInt64 i1 = 1;
                UInt64 i2 = 2;

                Console.WriteLine("f1 != i1");
                Assert.IsFalse(f1 != i1);
                Console.WriteLine("i1 != f1");
                Assert.IsFalse(i1 != f1);

                Console.WriteLine("f1 != 1");
                Assert.IsFalse(f1 != 1);
                Console.WriteLine("1 != f1");
                Assert.IsFalse(1 != f1);


                Console.WriteLine("f1 != i2");
                Assert.IsTrue(f1 != i2);
                Console.WriteLine("i2 != f1");
                Assert.IsTrue(i2 != f1);

                Console.WriteLine("f1 != 2");
                Assert.IsTrue(f1 != 2);
                Console.WriteLine("2 != f1");
                Assert.IsTrue(2 != f1);
            }
        }


        [TestFixture]
        public class ImplicitbyteOperatorOverloadTest
        {
            [Test]
            public void EqualsOperatorTest()
            {
                Foo f1 = new Foo(1);
                byte i1 = 1;
                byte i2 = 2;

                Console.WriteLine("f1 == i1");
                Assert.IsTrue(f1 == i1);
                Console.WriteLine("i1 == f1");
                Assert.IsTrue(i1 == f1);

                Console.WriteLine("f1 == 1");
                Assert.IsTrue(f1 == 1);
                Console.WriteLine("1 == f1");
                Assert.IsTrue(1 == f1);


                Console.WriteLine("f1 == i2");
                Assert.IsFalse(f1 == i2);
                Console.WriteLine("i2 == f1");
                Assert.IsFalse(i2 == f1);

                Console.WriteLine("f1 == 2");
                Assert.IsFalse(f1 == 2);
                Console.WriteLine("2 == f1");
                Assert.IsFalse(2 == f1);
            }


            [Test]
            public void UnequalsOperatorTest()
            {
                Foo f1 = new Foo(1);
                byte i1 = 1;
                byte i2 = 2;

                Console.WriteLine("f1 != i1");
                Assert.IsFalse(f1 != i1);
                Console.WriteLine("i1 != f1");
                Assert.IsFalse(i1 != f1);

                Console.WriteLine("f1 != 1");
                Assert.IsFalse(f1 != 1);
                Console.WriteLine("1 != f1");
                Assert.IsFalse(1 != f1);


                Console.WriteLine("f1 != i2");
                Assert.IsTrue(f1 != i2);
                Console.WriteLine("i2 != f1");
                Assert.IsTrue(i2 != f1);

                Console.WriteLine("f1 != 2");
                Assert.IsTrue(f1 != 2);
                Console.WriteLine("2 != f1");
                Assert.IsTrue(2 != f1);
            }
        }


        [TestFixture]
        public class ImplicitsbyteOperatorOverloadTest
        {
            [Test]
            public void EqualsOperatorTest()
            {
                Foo f1 = new Foo(1);
                sbyte i1 = 1;
                sbyte i2 = 2;

                Console.WriteLine("f1 == i1");
                Assert.IsTrue(f1 == i1);
                Console.WriteLine("i1 == f1");
                Assert.IsTrue(i1 == f1);

                Console.WriteLine("f1 == 1");
                Assert.IsTrue(f1 == 1);
                Console.WriteLine("1 == f1");
                Assert.IsTrue(1 == f1);


                Console.WriteLine("f1 == i2");
                Assert.IsFalse(f1 == i2);
                Console.WriteLine("i2 == f1");
                Assert.IsFalse(i2 == f1);

                Console.WriteLine("f1 == 2");
                Assert.IsFalse(f1 == 2);
                Console.WriteLine("2 == f1");
                Assert.IsFalse(2 == f1);
            }


            [Test]
            public void UnequalsOperatorTest()
            {
                Foo f1 = new Foo(1);
                sbyte i1 = 1;
                sbyte i2 = 2;

                Console.WriteLine("f1 != i1");
                Assert.IsFalse(f1 != i1);
                Console.WriteLine("i1 != f1");
                Assert.IsFalse(i1 != f1);

                Console.WriteLine("f1 != 1");
                Assert.IsFalse(f1 != 1);
                Console.WriteLine("1 != f1");
                Assert.IsFalse(1 != f1);


                Console.WriteLine("f1 != i2");
                Assert.IsTrue(f1 != i2);
                Console.WriteLine("i2 != f1");
                Assert.IsTrue(i2 != f1);

                Console.WriteLine("f1 != 2");
                Assert.IsTrue(f1 != 2);
                Console.WriteLine("2 != f1");
                Assert.IsTrue(2 != f1);
            }
        }



        [TestFixture]
        public class ImplicitdecimalOperatorOverloadTest
        {
            [Test]
            public void EqualsOperatorTest()
            {
                Foo f1 = new Foo(1);
                decimal i1 = 1;
                decimal i2 = 2;

                Console.WriteLine("f1 == i1");
                Assert.IsTrue(f1 == i1);
                Console.WriteLine("i1 == f1");
                Assert.IsTrue(i1 == f1);

                Console.WriteLine("f1 == 1");
                Assert.IsTrue(f1 == 1);
                Console.WriteLine("1 == f1");
                Assert.IsTrue(1 == f1);


                Console.WriteLine("f1 == i2");
                Assert.IsFalse(f1 == i2);
                Console.WriteLine("i2 == f1");
                Assert.IsFalse(i2 == f1);

                Console.WriteLine("f1 == 2");
                Assert.IsFalse(f1 == 2);
                Console.WriteLine("2 == f1");
                Assert.IsFalse(2 == f1);
            }


            [Test]
            public void UnequalsOperatorTest()
            {
                Foo f1 = new Foo(1);
                decimal i1 = 1;
                decimal i2 = 2;

                Console.WriteLine("f1 != i1");
                Assert.IsFalse(f1 != i1);
                Console.WriteLine("i1 != f1");
                Assert.IsFalse(i1 != f1);

                Console.WriteLine("f1 != 1");
                Assert.IsFalse(f1 != 1);
                Console.WriteLine("1 != f1");
                Assert.IsFalse(1 != f1);


                Console.WriteLine("f1 != i2");
                Assert.IsTrue(f1 != i2);
                Console.WriteLine("i2 != f1");
                Assert.IsTrue(i2 != f1);

                Console.WriteLine("f1 != 2");
                Assert.IsTrue(f1 != 2);
                Console.WriteLine("2 != f1");
                Assert.IsTrue(2 != f1);
            }
        }



        [TestFixture]
        public class ImplicitfloatOperatorOverloadTest
        {
            [Test]
            public void EqualsOperatorTest()
            {
                Foo f1 = new Foo(1);
                float i1 = 1;
                float i2 = 2;

                Console.WriteLine("f1 == i1");
                Assert.IsTrue(f1 == i1);
                Console.WriteLine("i1 == f1");
                Assert.IsTrue(i1 == f1);

                Console.WriteLine("f1 == 1");
                Assert.IsTrue(f1 == 1);
                Console.WriteLine("1 == f1");
                Assert.IsTrue(1 == f1);


                Console.WriteLine("f1 == i2");
                Assert.IsFalse(f1 == i2);
                Console.WriteLine("i2 == f1");
                Assert.IsFalse(i2 == f1);

                Console.WriteLine("f1 == 2");
                Assert.IsFalse(f1 == 2);
                Console.WriteLine("2 == f1");
                Assert.IsFalse(2 == f1);
            }


            [Test]
            public void UnequalsOperatorTest()
            {
                Foo f1 = new Foo(1);
                float i1 = 1;
                float i2 = 2;

                Console.WriteLine("f1 != i1");
                Assert.IsFalse(f1 != i1);
                Console.WriteLine("i1 != f1");
                Assert.IsFalse(i1 != f1);

                Console.WriteLine("f1 != 1");
                Assert.IsFalse(f1 != 1);
                Console.WriteLine("1 != f1");
                Assert.IsFalse(1 != f1);


                Console.WriteLine("f1 != i2");
                Assert.IsTrue(f1 != i2);
                Console.WriteLine("i2 != f1");
                Assert.IsTrue(i2 != f1);

                Console.WriteLine("f1 != 2");
                Assert.IsTrue(f1 != 2);
                Console.WriteLine("2 != f1");
                Assert.IsTrue(2 != f1);
            }
        }


        [TestFixture]
        public class ImplicitdoubleOperatorOverloadTest
        {
            [Test]
            public void EqualsOperatorTest()
            {
                Foo f1 = new Foo(1);
                double i1 = 1;
                double i2 = 2;

                Console.WriteLine("f1 == i1");
                Assert.IsTrue(f1 == i1);
                Console.WriteLine("i1 == f1");
                Assert.IsTrue(i1 == f1);

                Console.WriteLine("f1 == 1");
                Assert.IsTrue(f1 == 1);
                Console.WriteLine("1 == f1");
                Assert.IsTrue(1 == f1);


                Console.WriteLine("f1 == i2");
                Assert.IsFalse(f1 == i2);
                Console.WriteLine("i2 == f1");
                Assert.IsFalse(i2 == f1);

                Console.WriteLine("f1 == 2");
                Assert.IsFalse(f1 == 2);
                Console.WriteLine("2 == f1");
                Assert.IsFalse(2 == f1);
            }


            [Test]
            public void UnequalsOperatorTest()
            {
                Foo f1 = new Foo(1);
                double i1 = 1;
                double i2 = 2;

                Console.WriteLine("f1 != i1");
                Assert.IsFalse(f1 != i1);
                Console.WriteLine("i1 != f1");
                Assert.IsFalse(i1 != f1);

                Console.WriteLine("f1 != 1");
                Assert.IsFalse(f1 != 1);
                Console.WriteLine("1 != f1");
                Assert.IsFalse(1 != f1);


                Console.WriteLine("f1 != i2");
                Assert.IsTrue(f1 != i2);
                Console.WriteLine("i2 != f1");
                Assert.IsTrue(i2 != f1);

                Console.WriteLine("f1 != 2");
                Assert.IsTrue(f1 != 2);
                Console.WriteLine("2 != f1");
                Assert.IsTrue(2 != f1);
            }
        }



        [Test]
        public void InitializeTest()
        {
            Foo myfoo = 100;
            Assert.IsTrue(100 == myfoo);
        }

        [Test]
        public void LongToDoubleTest()
        {
            long firstLong = long.MaxValue - 2;
            long secondLong = firstLong - 1;

            double firstDouble = firstLong;
            double secondDouble = secondLong;

            // Prints False as expected
            Console.WriteLine(firstLong == secondLong);
            Assert.IsFalse(firstLong == secondLong);

            // Prints True!
            Console.WriteLine(firstDouble == secondDouble);
            Assert.IsFalse(firstDouble == secondDouble);
        }

    }





    public class Foo
    {

        //https://msdn.microsoft.com/en-us/library/z5z9kes2.aspx
        //https://msdn.microsoft.com/en-us/library/aa288476(v=vs.71).aspx
        //https://msdn.microsoft.com/en-us/library/ms173105.aspx
        //http://stackoverflow.com/questions/390108/net-implicit-conversion-guidelines
        //https://msdn.microsoft.com/en-us/library/85w54y0a.aspx
        //https://msdn.microsoft.com/en-us/library/ms229033.aspx
        //https://msdn.microsoft.com/en-us/library/ms173147.aspx
        //https://msdn.microsoft.com/en-us/library/aa664464(v=vs.71)
        //https://msdn.microsoft.com/en-us/library/aa288467(v=vs.71).aspx
        //https://msdn.microsoft.com/en-us/library/ms229032.aspx


        private Int32 _value = 0;

        public Foo(Int32 v)
        {
            this._value = v;
        }

        public virtual Int32 Value { get { return _value; } }

        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj))
                return true;

            if (obj == null)
                return false;

            if (obj is Foo)
                return this._value.Equals( (obj as Foo).Value );

            return this._value.Equals(obj);

        }

        public override string ToString()
        {
            return this._value.ToString();
        }



        public static implicit operator Foo(Int32 i)
        {
            Console.WriteLine("A cast Int32 -> Foo ocurred");
            return new Foo((Int32)i);
        }

        public static implicit operator Int32(Foo f)
        {
            Console.WriteLine("A cast Foo -> Int32 ocurred");
            return f != null ? (Int32)f.Value : (Int32)0;
        }


        public static bool operator == (Foo x, Foo y)
        {
            Console.WriteLine("A Foo == Foo ocurred");
            if (((object)x == null) && ((object)y == null))
            {
                return true;
            }

            if (((object)x == null) || ((object)y == null))
            {
                return false;
            }

            return x.Equals(y);

        }


        public static bool operator !=(Foo x, Foo y)
        {
            Console.WriteLine("A Foo != Foo ocurred");
            return !(x == y);
        }




        #region uint64


        public static bool operator ==(UInt64 x, Foo y)
        {
            Console.WriteLine("A Uint64 == Foo ocurred");

            if (((object)x == null) && ((object)y == null))
            {
                return true;
            }

            if (((object)x == null) || ((object)y == null))
            {
                return false;
            }

            return x.Equals(y.Value);

        }


        public static bool operator !=(UInt64 x, Foo y)
        {
            Console.WriteLine("A Uint64 != Foo ocurred");
            return !(x == y);
        }




        public static bool operator ==(Foo x, UInt64 y)
        {
            Console.WriteLine("A Foo == UInt64 ocurred");

            if (((object)x == null) && ((object)y == null))
            {
                return true;
            }

            if (((object)x == null) || ((object)y == null))
            {
                return false;
            }

            return x.Value.Equals(y);

        }


        public static bool operator !=(Foo x, UInt64 y)
        {
            Console.WriteLine("A Foo != Uint64 ocurred");
            return !(x == y);
        }


        #endregion

        #region int64


        public static bool operator ==(Int64 x, Foo y)
        {
            Console.WriteLine("A Int64 == Foo ocurred");

            if (((object)x == null) && ((object)y == null))
            {
                return true;
            }

            if (((object)x == null) || ((object)y == null))
            {
                return false;
            }

            return x.Equals(y.Value);

        }


        public static bool operator !=(Int64 x, Foo y)
        {
            Console.WriteLine("A Int64 != Foo ocurred");
            return !(x == y);
        }




        public static bool operator ==(Foo x, Int64 y)
        {
            Console.WriteLine("A Foo == Int64 ocurred");

            if (((object)x == null) && ((object)y == null))
            {
                return true;
            }

            if (((object)x == null) || ((object)y == null))
            {
                return false;
            }

            return x.Value.Equals(y);

        }


        public static bool operator !=(Foo x, Int64 y)
        {
            Console.WriteLine("A Foo != Int64 ocurred");
            return !(x == y);
        }


        #endregion

        #region uint32


        public static bool operator ==(UInt32 x, Foo y)
        {
            Console.WriteLine("A UInt32 == Foo ocurred");

            if (((object)x == null) && ((object)y == null))
            {
                return true;
            }

            if (((object)x == null) || ((object)y == null))
            {
                return false;
            }

            return x.Equals(y.Value);

        }


        public static bool operator !=(UInt32 x, Foo y)
        {
            Console.WriteLine("A UInt32 != Foo ocurred");
            return !(x == y);
        }




        public static bool operator ==(Foo x, UInt32 y)
        {
            Console.WriteLine("A Foo == UInt32 ocurred");

            if (((object)x == null) && ((object)y == null))
            {
                return true;
            }

            if (((object)x == null) || ((object)y == null))
            {
                return false;
            }

            return x.Value.Equals(y);

        }


        public static bool operator !=(Foo x, UInt32 y)
        {
            Console.WriteLine("A Foo != UInt32 ocurred");
            return !(x == y);
        }


        #endregion

        #region int32


        public static bool operator ==(Int32 x, Foo y)
        {
            Console.WriteLine("A Int32 == Foo ocurred");

            if (((object)x == null) && ((object)y == null))
            {
                return true;
            }

            if (((object)x == null) || ((object)y == null))
            {
                return false;
            }

            return x.Equals(y.Value);

        }


        public static bool operator !=(Int32 x, Foo y)
        {
            Console.WriteLine("A Int32 != Foo ocurred");
            return !(x == y);
        }




        public static bool operator ==(Foo x, Int32 y)
        {
            Console.WriteLine("A Foo == Int32 ocurred");

            if (((object)x == null) && ((object)y == null))
            {
                return true;
            }

            if (((object)x == null) || ((object)y == null))
            {
                return false;
            }

            return x.Value.Equals(y);

        }


        public static bool operator !=(Foo x, Int32 y)
        {
            Console.WriteLine("A Foo != Int32 ocurred");
            return !(x == y);
        }


        #endregion

        #region uint16


        public static bool operator ==(UInt16 x, Foo y)
        {
            Console.WriteLine("A UInt16 == Foo ocurred");

            if (((object)x == null) && ((object)y == null))
            {
                return true;
            }

            if (((object)x == null) || ((object)y == null))
            {
                return false;
            }

            return x.Equals(y.Value);

        }


        public static bool operator !=(UInt16 x, Foo y)
        {
            Console.WriteLine("A UInt16 != Foo ocurred");
            return !(x == y);
        }




        public static bool operator ==(Foo x, UInt16 y)
        {
            Console.WriteLine("A Foo == UInt16 ocurred");

            if (((object)x == null) && ((object)y == null))
            {
                return true;
            }

            if (((object)x == null) || ((object)y == null))
            {
                return false;
            }

            return x.Value.Equals(y);

        }


        public static bool operator !=(Foo x, UInt16 y)
        {
            Console.WriteLine("A Foo != UInt16 ocurred");
            return !(x == y);
        }


        #endregion

        #region Int16


        public static bool operator ==(Int16 x, Foo y)
        {
            Console.WriteLine("A Int16 == Foo ocurred");

            if (((object)x == null) && ((object)y == null))
            {
                return true;
            }

            if (((object)x == null) || ((object)y == null))
            {
                return false;
            }

            return x.Equals(y.Value);

        }


        public static bool operator !=(Int16 x, Foo y)
        {
            Console.WriteLine("A Int16 != Foo ocurred");
            return !(x == y);
        }




        public static bool operator ==(Foo x, Int16 y)
        {
            Console.WriteLine("A Foo == Int16 ocurred");

            if (((object)x == null) && ((object)y == null))
            {
                return true;
            }

            if (((object)x == null) || ((object)y == null))
            {
                return false;
            }

            return x.Value.Equals(y);

        }


        public static bool operator !=(Foo x, Int16 y)
        {
            Console.WriteLine("A Foo != Int16 ocurred");
            return !(x == y);
        }


        #endregion

        #region SByte


        public static bool operator ==(SByte x, Foo y)
        {
            Console.WriteLine("A SByte == Foo ocurred");

            if (((object)x == null) && ((object)y == null))
            {
                return true;
            }

            if (((object)x == null) || ((object)y == null))
            {
                return false;
            }

            return x.Equals(y.Value);

        }


        public static bool operator !=(SByte x, Foo y)
        {
            Console.WriteLine("A SByte != Foo ocurred");
            return !(x == y);
        }




        public static bool operator ==(Foo x, SByte y)
        {
            Console.WriteLine("A Foo == SByte ocurred");

            if (((object)x == null) && ((object)y == null))
            {
                return true;
            }

            if (((object)x == null) || ((object)y == null))
            {
                return false;
            }

            return x.Value.Equals(y);

        }


        public static bool operator !=(Foo x, SByte y)
        {
            Console.WriteLine("A Foo != SByte ocurred");
            return !(x == y);
        }


        #endregion

        #region Byte


        public static bool operator ==(Byte x, Foo y)
        {
            Console.WriteLine("A Byte == Foo ocurred");

            if (((object)x == null) && ((object)y == null))
            {
                return true;
            }

            if (((object)x == null) || ((object)y == null))
            {
                return false;
            }

            return x.Equals(y.Value);

        }


        public static bool operator !=(Byte x, Foo y)
        {
            Console.WriteLine("A Byte != Foo ocurred");
            return !(x == y);
        }




        public static bool operator ==(Foo x, Byte y)
        {
            Console.WriteLine("A Foo == Byte ocurred");

            if (((object)x == null) && ((object)y == null))
            {
                return true;
            }

            if (((object)x == null) || ((object)y == null))
            {
                return false;
            }

            return x.Value.Equals(y);

        }


        public static bool operator !=(Foo x, Byte y)
        {
            Console.WriteLine("A Foo != Byte ocurred");
            return !(x == y);
        }


        #endregion


    }
}
