using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace NFactorial1To100
{
    /*Write a program to calculate n! for each n in the range [1..100]. Hint: Implement first a method that
     * multiplies a number represented as array of digits by given integer number. */
    class NFactorial1To100Class
    {
        static void Main(string[] args)
        {
            BigInteger prevResult = 1;
            for (int i = 1; i <= 100; i++)
            {
                prevResult = MultiplyArrayWithInt(CreateArrFromInt(prevResult), i);
                Console.WriteLine("{0}!= {1}",i, prevResult);
            }


        }
        private static BigInteger[] CreateArrFromInt(BigInteger number)
        {
            int length = number.ToString().Length;
            BigInteger rest = number;
            BigInteger[] multArr = new BigInteger[length];
            int i = 0;
            while (rest != 0)
            {
                multArr[i] = rest % 10;
                rest = rest / 10;
                i++;
            }
            return multArr;
        }
        private static BigInteger MultiplyArrayWithInt(BigInteger[] arr, int mult)
        {
            BigInteger result = 0;
            BigInteger order = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                result = result + arr[i] * order * mult;
                order *= 10;
            }
            return result;
        }

    }
}
