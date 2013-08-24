using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    interface ITest
    {
        int Id { get; set; }
    }

    class Test : ITest
    {
        public int Id { get; set; }
    }

    class TestProcessor<T> where T : ITest, new()
    {
        public ITest ProcesS()
        {
            return new T();
        }
    }

    public struct Struct
    {
        int a;
    }

    struct Struct2
    {
        object b;
    }

    class Generics<T> where T : struct
    {
        public T s;
        private Dictionary<string, object> data = new Dictionary<string, object>();

        public T Test()
        {
            return (T) data["test"];
        }
    }
}
