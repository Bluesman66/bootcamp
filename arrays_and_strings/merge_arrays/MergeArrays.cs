using System;
using System.Collections.Generic;

namespace merge_arrays
{
    class MergeArrays
    {
        public void Merge(int[] arr1, int[] arr2)
        {
            var p1 = 0;
            var p2 = 0;

            var result = new List<int>();

            while (p1 < arr1.Length && p2 < arr2.Length)
            {
                if (arr1[p1] < arr2[p2])
                {
                    result.Add(arr1[p1]);
                    p1++;
                }
                else if (arr1[p1] >= arr2[p2])
                {
                    result.Add(arr2[p2]);
                    p2++;
                }
            }

            if (p1 < arr1.Length)
            {
                while (p1 < arr1.Length)
                {
                    result.Add(arr1[p1]);
                    p1++;
                }
            }

            if (p2 < arr2.Length)
            {
                while (p2 < arr2.Length)
                {
                    result.Add(arr2[p2]);
                    p2++;
                }
            }

            PrintResult(result);
        }

        private void PrintResult(IEnumerable<int> result)
        {
            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var first = new int[] { 1, 3, 4 };
            var second = new int[] { 2, 5, 6 };

            var mergeArrays = new MergeArrays();
            mergeArrays.Merge(first, second);
        }
    }
}
