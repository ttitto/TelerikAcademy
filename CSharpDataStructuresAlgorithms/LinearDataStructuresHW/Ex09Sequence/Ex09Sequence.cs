using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex09Sequence
{
    /*09. We are given the following sequence:
S1 = N;
S2 = S1 + 1;
S3 = 2*S1 + 1;
S4 = S1 + 2;
S5 = S2 + 1;
S6 = 2*S2 + 1;
S7 = S2 + 2;
...
Using the Queue<T> class write a program to print its first 50 members for given N.
Example: N=2  2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...*/
    class Ex09SequenceClass
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(n);
            for (int i = 0; i < 50; i++)
            {
                Console.Write("{0} ", queue.Peek());
                queue.Enqueue(queue.Peek() + 1);
                queue.Enqueue(queue.Peek() * 2 + 1);
                queue.Enqueue(queue.Dequeue() + 2);
            }
        }
    }
}
