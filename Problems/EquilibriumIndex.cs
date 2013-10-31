using System;
using System.Linq;

namespace algorithms.Problems
{
    public class EquilibriumIndex
    {
        public static void Run()
        {
            var problem = new EquilibriumIndex(new [] { -7, 1, 5, 2, -4, 3, 0 });
            Console.WriteLine(problem.Solve());
        }

        public EquilibriumIndex(Int32[] array)
        {
            _array = array;
        }

        public Int32 Solve()
        {
            if (_array.Length == 0)
                return -1;

            Int64 sum = 0;
            for (var i = 0; i < _array.Length; i++)
                sum += _array[i];

            Int64 leftSum = 0;

            for (var i = 0; i < _array.Length; i++)
            {
                sum -= _array[i];

                if (leftSum == sum)
                    return i;

                leftSum += _array[i];
            }

            return -1;
        }

        private readonly Int32[] _array;
    }
}

