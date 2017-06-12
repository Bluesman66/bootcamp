using System;
using System.Collections.Generic;

namespace reverse_sentence
{
    class ReverseSentence
    {
        private string _input;

        public ReverseSentence(string input)
        {
            this._input = input;
        }

        public void Reverse()
        {
            var tmp = new List<char>();
            for (int i = _input.Length - 1; i >= 0; i--)
            {
                tmp.Add(_input[i]);
            }
            PrintResult(tmp);
        }

        private void PrintResult(IEnumerable<char> list)
        {
            foreach (var item in list)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var sentense = new ReverseSentence("The fox jumps over the fence");
            sentense.Reverse();
        }
    }
}