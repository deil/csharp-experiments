using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Test
{
    public class Closures
    {
        public class ValueRef
        {
            public ValueRef(int val)
            {
                Val = val;
            }

            public readonly int Val;
        }

        public static void Test()
        {
            var arrayOfValues = new[] {1, 2, 3, 4};
            var actions = new List<Action>();
            foreach (var i in arrayOfValues)
            {
                var j = i;
                actions.Add(() => Console.WriteLine(j));
            }

            actions.ForEach(a => a());

            Console.WriteLine("Main thread is done.");
        }
    }
}
