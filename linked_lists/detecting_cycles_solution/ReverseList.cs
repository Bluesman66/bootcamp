using System;

namespace detecting_cycles_solution
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

    class ReverseLinkedList
    {
        private Node _head = null;
        public ReverseLinkedList(Node input)
        {
            _head = input;
        }

        public void Solve()
        {
            Node prev = null;
            Node curr = _head;
            while (curr != null)
            {
                var tmp = curr.Next;
                curr.Next = prev;  
                prev = curr;
                curr = tmp;

                if (curr == null)
                {
                    _head = prev;
                }
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

    class ReverseList
    {
        static void Main(string[] args)
        {
            var a = new Node("A", null);
            var b = new Node("B", null);
            var c = new Node("C", null);            

            a.Next = b;
            b.Next = c;
            c.Next = null;

            var rList = new ReverseLinkedList(a);
            rList.Solve();
        }
    }
}
