using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class Parent
    {
        public int a { get; set; }
    }

    class Child : Parent
    {
        public int a { get; set; }
    }

    class IsAsTest
    {
        public static T? Cast<T>(object value) where T : struct
        {
            return value as T?;
        }
    }
}
