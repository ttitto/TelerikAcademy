using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02PrintToNNotDivisible
{/*2. Write a program that prints all the numbers from 1 to N,
  * that are not divisible by 3 and 7 at the same time.*/
    class Ex02PrintToNNotDivisibleClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert N: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                if ((i + 1) % 3 != 0 || (i + 1) % 7 != 0)
                {
                    Console.Write(" {0}", i + 1);                    
                }
            }
            Console.WriteLine();
        }
    }
}
