using System;

namespace deilycode.CLR.VirtualMemberCall
{
    sealed class DerivedClass : BaseClass
    {
        public DerivedClass()
        {
            Console.WriteLine("DerivedClass.ctor()");

            _currentTime = DateTime.Now;
            Greet();
        }

        protected override void Greet()
        {
            Console.WriteLine("Hello from DerivedClass!\nCurrent time is {0}", _currentTime);
        }

        private DateTime? _currentTime;
    }
}
