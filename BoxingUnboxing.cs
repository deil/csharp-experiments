using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.BoxingUnboxing
{
    public interface ITestInterface
    {
        int SomeInt { get; set; }
    }

    public struct TestStruct : ITestInterface
    {
        public int MyInt { get; set; }

        public int SomeInt
        {
            get { return MyInt; }
            set { MyInt = value; }
        }

        public static void Test()
        {
            var originalStruct = new TestStruct {SomeInt = 5};

            var structAsInterface = (ITestInterface) originalStruct;
            structAsInterface.SomeInt = 6;
            Console.WriteLine(structAsInterface.SomeInt == originalStruct.SomeInt); // false

            var anotherStruct = (TestStruct) structAsInterface;
            anotherStruct.SomeInt = 7;
            Console.WriteLine(anotherStruct.SomeInt == structAsInterface.SomeInt); // false
        }
    }
}
