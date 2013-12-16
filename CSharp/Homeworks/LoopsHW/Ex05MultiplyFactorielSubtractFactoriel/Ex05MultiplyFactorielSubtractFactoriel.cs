using System;
using System.Numerics;

namespace Ex05MultiplyFactorielSubtractFactoriel
{
    /*5. Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).*/
    class Ex05MultiplyFactorielSubtractFactorielClass
    {
        static void Main(string[] args)
        {
            BigInteger n;
            BigInteger k;
            BigInteger nFact;
            do
            {
                Console.Write("Insert N: ");
                n = BigInteger.Parse(Console.ReadLine());
                Console.Write("Insert K: ");
                k = BigInteger.Parse(Console.ReadLine());
            } while (n >= k);
            nFact = n;
            BigInteger diff = k - n;
            BigInteger diffFact = diff;
            for (BigInteger i = k-1; i >= 1; i--)
            {
                if (i<n)
                {
                    nFact *= i;
                }
                if (i<diff)
                {
                    diffFact *= i;
                }
                k *= i;
            }

            BigInteger result = nFact * k / diffFact;
            Console.WriteLine("The result is {0}.",result);
        }
    }
}
