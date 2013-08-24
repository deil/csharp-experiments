using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public struct MyStruct
    {
        public MyStruct(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        private int a;
        private int b;
    }

    public struct MyStruct2 : IEquatable<MyStruct2>
    {
        public MyStruct2(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public bool Equals(MyStruct2 other)
        {
            return a == other.a && b == other.b;
        }

        private int a;
        private int b;
    }

    public class ValueTypeEquals
    {
        public static void Test()
        {
            var start = DateTime.Now;

            var s11 = new MyStruct(1, 2);
            var s12 = new MyStruct(1, 2);
            var r = false;

            for (var i = 0; i < 10000000; i++)
            {
                r &= s11.Equals(s12);
            }

            Console.WriteLine(DateTime.Now - start);

            start = DateTime.Now;

            var s21 = new MyStruct2(1, 2);
            var s22 = new MyStruct2(1, 2);


            for (var i = 0; i < 10000000; i++)
            {
                r &= s21.Equals(s22);
            }

            Console.WriteLine(DateTime.Now - start);
        }
    }
}
