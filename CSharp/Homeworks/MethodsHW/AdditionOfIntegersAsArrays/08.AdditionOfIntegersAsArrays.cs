using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace AdditionOfIntegersAsArrays
{
    /*Write a method that adds two positive integer numbers represented as arrays of digits 
     * (each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
     * Each of the numbers that will be added could have up to 10 000 digits.*/
    class AdditionOfIntegersAsArraysClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert two positive integers: ");
            string number1 = Console.ReadLine();
            string number2 = Console.ReadLine();

            number1 = new string(number1.Reverse().ToArray());
            number2 = new string(number2.Reverse().ToArray());

            Console.WriteLine("The sum is {0}.", AddIntegers(number1.ToArray(), number2.ToArray()));
        }
        private static BigInteger AddIntegers(char[] arr1, char[] arr2)
        {
            uint maxSize;
            uint minSize;
            char[] maxArr;
            if (arr2.Length > arr1.Length)
            {
                maxSize = (uint)arr2.Length;
                minSize = (uint)arr1.Length;
                maxArr = arr2;
            }
            else
            {
                maxSize = (uint)arr1.Length;
                minSize = (uint)arr2.Length;
                maxArr = arr1;
            }
            BigInteger result = 0;
            BigInteger multiple10 = 1;
            for (int i = 0; i < minSize; i++)
            {
                result = result + BigInteger.Parse(arr1[i].ToString()) * multiple10 + BigInteger.Parse(arr2[i].ToString()) * multiple10;
                multiple10 *= 10;
            }
            for (uint j = minSize; j < maxSize; j++)
            {
                result = result + BigInteger.Parse(maxArr[j].ToString()) * multiple10;
                multiple10 *= 10;
            }
            return result;
        }

    }
}
