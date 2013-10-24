using System;
using System.Threading;

namespace deilycode.AsyncInvocations
{
	sealed class ExternalService
    {
        public class InvocationResult
        {
            public int Status;
        }   
    
        public InvocationResult LongRunningMethod(int parameter)
        {
            Console.WriteLine("I am long-running method");
			Thread.Sleep(5000);
            Console.WriteLine("Finished!");
      
			return new ExternalService.InvocationResult { Status = parameter ^ 2 };
        }    
    }
}

