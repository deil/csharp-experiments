using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Test;
using Test.BoxingUnboxing;

namespace @volatile
{
    public class Program
    {
        volatile int foo;

        public delegate void WriteToConsole(string format, params object[] args);

        public void WriteLineCallback(IAsyncResult iar)
        {
            Console.WriteLine("In WriteLineCallback");
            Console.WriteLine(iar.AsyncState);
        }

        public static void T(string format, params object [] args)
        {
            Console.WriteLine("T");
            var writer = new WriteToConsole(Console.WriteLine);
            var iar = writer.BeginInvoke(format, args, new Program().WriteLineCallback, 5);
            Thread.Sleep(1000);
            Console.WriteLine("Before EndInvoke()");
            writer.EndInvoke(iar);
            Console.WriteLine("After EndInvoke()");
        }

        public static void Main()
        {
            ValueTypeEquals.Test();
            return;
        }
    }
}
