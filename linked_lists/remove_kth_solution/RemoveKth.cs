using System;

namespace remove_kth_solution
{
    class Node
    {
        public string Value { get; set; }
        public Node Next { get; set; }

        public Node(string value, Node next)
        {
            Value = value;
            Next = next;
        }
    }

    class KthSolver
    {
        private Node _head = null;

        public KthSolver(Node input)
        {
            _head = input;
        }

        public void Solve(int k)
        {
            var p1 = _head;
            var p2 = _head;

            while (k > 0)
            {
                p2 = p2.Next;
                k--;
            }

            while (p2 != null)
            {
                p1 = p1.Next;
                p2 = p2.Next;
            }

            // p1 contains kth to last element
            // remove p1
            var tmp = p1.Next;
            if (tmp == null)
            {
                p1.Value = null;
                p1.Next = null;
            }
            else
            {
                p1.Value = tmp.Value;
                p1.Next = tmp.Next;
            }

            PrintResult();
        }

        public void PrintResult()
        {
            var curr = _head;
            while (curr != null)
            {
                Console.Write(curr.Value + " ");
                curr = curr.Next;   
            }   
            Console.WriteLine();
        }
    }

    class RemoveKth
    {
        static void Main(string[] args)
        {
            var a = new Node("A", null);
            var b = new Node("B", null);
            var c = new Node("C", null);
            var d = new Node("D", null);
            var e = new Node("E", null);

            a.Next = b;
            b.Next = c;
            c.Next = d;
            d.Next = e;
            e.Next = null;

            var obj = new KthSolver(a);
            obj.Solve(2);
        }
    }
}
