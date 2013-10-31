using System;

namespace algorithms.Problems
{
    public sealed class ArrayAndRain
    {
        public static void Run()
        {
            var array = new [] { 2, 5, 1, 2, 3, 4, 7, 7, 6 };
            Console.WriteLine(String.Join(", ", array));

            var solver = new ArrayAndRain(array);
            Console.WriteLine(solver.Solve());
        }

        public ArrayAndRain(Int32[] array)
        {
            _array = array;
        }

        public Int32 Solve()
        {

            return 0;
        }

        private readonly Int32[] _array;
    }
}

