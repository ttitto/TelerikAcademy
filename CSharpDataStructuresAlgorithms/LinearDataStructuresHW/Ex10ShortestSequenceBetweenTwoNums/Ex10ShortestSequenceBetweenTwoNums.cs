using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex10ShortestSequenceBetweenTwoNums
{
    /*10. * We are given numbers N and M and the following operations:
N = N+1
N = N+2
N = N*2
Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M. Hint: use a queue.
Example: N = 5, M = 16
Sequence: 5  7  8  16*/
    class Ex10ShortestSequenceBetweenTwoNumsClass
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(m);
            while (m/2>=n)
            {
                m = m / 2;
                queue.Enqueue(m);
            }
            while (m-2>=n)
            {
                m = m - 2;
                queue.Enqueue(m);
            }
            while (m-1>=n)
            {
                m = m - 1;
                queue.Enqueue(m);
            }

            foreach (var item in queue)
            {
                Console.Write("{0} ",item);
            }

        }
    }
}
