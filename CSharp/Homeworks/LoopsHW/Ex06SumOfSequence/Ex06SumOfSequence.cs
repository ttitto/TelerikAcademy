using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace Ex06SumOfSequence
{
    /*6. Write a program that, for a given two integer numbers N and X,
     * calculates the sumS = 1 + 1!/X + 2!/X2 + … + N!/XN*/
    class Ex06SumOfSequenceClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert N: ");
            BigInteger n = BigInteger.Parse(Console.ReadLine());
            Console.Write("Insert X: ");
            BigInteger x = BigInteger.Parse(Console.ReadLine());

            BigInteger nFact = 1;
            BigInteger XPowN = 1;
            decimal sum = 1;
            for (BigInteger i = 1; i <= n; i++)
            {
                nFact *= i;
                XPowN *= x;

                sum += ((decimal)nFact / (decimal)XPowN);
            }
            Console.WriteLine("the result is {0:0.000}",sum);
        }
    }
}
