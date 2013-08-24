using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public class StaticLock1
    {
        public static int a = InitA();
        public static int c = InitC();
        public static int d;

        static int InitA()
        {
            Console.WriteLine("StaticLock1.InitA()");
            return StaticLock2.b;
        }

        static int InitC()
        {
            Console.WriteLine("StaticLock1.InitC()");
            return 15;
        }
    }

    public class StaticLock2
    {
        public static int b = InitB();

        static StaticLock2()
        {
            Console.WriteLine("StaticLock2.ctor()");
            b = StaticLock1.d;
        }

        static int InitB()
        {
            Console.WriteLine("StaticLock2.InitB()");
            return StaticLock1.c;
        }
    }
}
