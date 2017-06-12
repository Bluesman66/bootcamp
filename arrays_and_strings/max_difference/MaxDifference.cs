using System;
using System.Collections.Generic;

namespace max_difference
{
    class MaxDifference
    {
        private int[] _arr;
        private int _maxDiff, _maxPos;
        private int _minValue, _minPos;
        private Stack<int> _buySel;

        public MaxDifference(params int[] input)
        {
            _buySel = new Stack<int>();
            _arr = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                _arr[i] = input[i];
            }
        }

        private void Solve()
        {
            _maxDiff = 0;
            _maxPos = 0;
            _minValue = _arr[0];
            _minPos = 0;
            int diff, newMax, newMin;

            for (int i = 0; i < _arr.Length; i++)
            {
                newMin = Min(_minValue, _arr[i]);
                if (newMin < _minValue)
                {
                    _minValue = newMin;
                    _minPos = i;
                }
                
                diff = _arr[i] - _minValue;
                
                newMax = Max(diff, _maxDiff);
                if (newMax > _maxDiff)
                {
                    _maxDiff = newMax;
                    _maxPos = i;
                    // store buy/sell price
                    _buySel.Push(_maxPos);
                    _buySel.Push(_minPos);    
                }
            }   

            PrintResult();             
        }

        private int Min(int a, int b)
        {
            if (a < b)
            {
                return a;
            }
            else if (a >= b)
            {
                return b;
            }             
            return -1;
        }

        private int Max(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else if (a <= b)
            {
                return b;
            }
            return -1;
        }

        public void PrintResult()
        {
            Console.WriteLine($"Max Difference: {_maxDiff}");
            Console.WriteLine($"Min Position: {_buySel.Pop()}");
            Console.WriteLine($"Max Position: {_buySel.Pop()}");
        }

        static void Main(string[] args)
        {
            var maxDiff = new MaxDifference(-1, 5, 0, 1, 2, -3);
            maxDiff.Solve();
        }
    }
}