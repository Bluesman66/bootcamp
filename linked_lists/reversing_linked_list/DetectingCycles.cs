using System;

namespace reversing_linked_list
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

    class LinkedList
    {
        public Node Head { get; set; }
        private Node Tail { get; set; }

        public LinkedList(Node start)
        {
            Head = start;
            Tail = start;
        }

        public void Insert(Node e)
        {
            Tail.Next = e;
            Tail = e;
        }
    }

    class Cycles
    {
        private LinkedList _list;
        public Cycles(LinkedList list)
        {
            _list = list;
        }

        public void Solve()
        {
            Node result = null;
            Node fast, slow;
            Node prev = null;

            slow = _list.Head;
            fast = _list.Head;

            var loop = true;

            while (loop)
            {
                // advance the pointers
                slow = slow.Next;
                if (fast.Next != null)
                {
                    prev = fast.Next;
                    fast = fast.Next.Next;
                }
                else
                {
                    // no cycle
                    loop = false;
                    result = null;
                }

                if ((slow == fast) && loop)
                {
                    result = prev;
                    loop = false;
                }
                else if (slow == null || fast == null)
                {
                    // no cycle
                    result = null;
                    loop = false;
                }
            }

            PrintResult(result);
        }

        public void PrintResult(Node result)
        {
            if (result != null)
            {
                Console.WriteLine("Cycle detected at: " + result.Value);
            }
            else
            {
                Console.WriteLine("No cycle detected.");
            }
        }
    }

    class DetectingCycles
    {
        static void Main(string[] args)
        {
            var c = new Node("C", null);
            var b = new Node("B", c);
            var a = new Node("A", b);
            c.Next = a;

            var list = new LinkedList(a);            

            var cycles = new Cycles(list);
            cycles.Solve();
        }
    }
}
