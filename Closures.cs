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
            foreach (var i in arrayOfValues)
            {
                ThreadPool.QueueUserWorkItem(state =>
                                                 {
                                                     Console.WriteLine("Thread id {0}, value {1}", Thread.CurrentThread.ManagedThreadId, i);
                                                     Thread.Sleep(1000);
                                                     Console.WriteLine("Thread id {0} again, value {1}", Thread.CurrentThread.ManagedThreadId, i);
                                                 }
                    );

                Thread.Sleep(500);
            }

            Console.WriteLine("Main thread is done.");
        }
    }
}
