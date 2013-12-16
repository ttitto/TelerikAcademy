using System;
using System.Numerics;
namespace Ex04FactorielDivision
{
    /*4. Write a program that calculates N!/K! for given N and K (1<K<N).*/
    class Ex04FactorielDivisionClass
    {
        static void Main(string[] args)
        {
            BigInteger n;
            BigInteger k;
            do
            {
                Console.Write("Insert N: ");
                n = BigInteger.Parse(Console.ReadLine());
                Console.Write("Insert K: ");
                k = BigInteger.Parse(Console.ReadLine());
            } while (n <= k);

            for (BigInteger i = n - 1; i >= k + 1; i--)
            {
                n *= i;
            }

            Console.WriteLine("The result is {0}", n);
        }
    }
}
