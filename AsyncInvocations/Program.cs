using System;
using System.Threading;

namespace AsyncInvocations
{
    class MainClass
    {
        public delegate ExternalService.InvocationResult LongRunningMethod(int parameter);

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var service = new ExternalService();

            LongRunningMethod method = service.LongRunningMethod;
            var asyncResult = method.BeginInvoke(12, null, null);
            Console.WriteLine("After BeginInvoke()");
            while (!asyncResult.IsCompleted)
            {
                //Thread.Sleep(1000);
                asyncResult.AsyncWaitHandle.WaitOne();
                Console.WriteLine("Tick");
            }

            Console.WriteLine("Attempting EndInvoke()");
            var result = method.EndInvoke(asyncResult);
            Console.WriteLine("Returned {0}", result.Status);           
        }
    }
}
