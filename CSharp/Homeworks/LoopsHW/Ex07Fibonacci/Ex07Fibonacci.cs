using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace Ex07Fibonacci
{
    /*7. Write a program that reads a number N and calculates the sum of the first N members of the sequence of Fibonacci:
     * 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
      Each member of the Fibonacci sequence (except the first two) is a sum of the previous two members.*/
    class Ex07FibonacciClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert the number of fibonacci members: ");
            int n= int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            sb.Append("0, 1, ");
            BigInteger fb1 = 0;
            BigInteger fb2 = 1;
            BigInteger fb3;
            for (int i = 1; i < n-1; i++)
            {
                fb3 = fb1 + fb2;
                sb.Append(fb3);
                //do not add comma after the last number
                if (i != (n-1))
                {
                    sb.Append(", ");
                }
                fb1 = fb2;
                fb2 = fb3;
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
