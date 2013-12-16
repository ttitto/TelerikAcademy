using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Ex09First100Fibonacci
{
    /*9. Write a program to print the first 100 members of the sequence of Fibonacci: 
     * 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …*/
    class Ex09First100FibonacciClass
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("0, 1, ");
            BigInteger fb1 = 0;
            BigInteger fb2 = 1;
            BigInteger fb3;
            for (int i = 1; i < 99; i++)
            {
                fb3 = fb1 + fb2;
                sb.Append(fb3);
                //do not add comma after the last number
                if (i != 98)
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
