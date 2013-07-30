using System;
using System.Threading;

namespace AsyncInvocations
{
    public class ExternalService
    {
        public class InvocationResult
        {
            public int Status;
        }   
    
        public ExternalService()
        {
        }
    
        public InvocationResult LongRunningMethod(int parameter)
        {
            Console.WriteLine("I am long-running method");
            Thread.Sleep(10000);
            Console.WriteLine("Finished!");
      
            return new ExternalService.InvocationResult { Status = parameter ^ 2 };
        }    
    }
}

