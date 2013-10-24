using System;

namespace deilycode.CLR.VirtualMemberCall
{
    class BaseClass
    {
        public BaseClass()
        {
            Greet();
        }

        protected virtual void Greet()
        {
            Console.WriteLine("Greet from BaseClass!");
        }
    }
}
