using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetMaxInt
{
    /*Write a method GetMax() with two parameters that returns the bigger of two integers. Write a program that 
     * reads 3 integers from the console and prints the biggest of them using the method GetMax().*/
    class GetMaxInt
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert three integers: ");
            Console.WriteLine("The maximal number is: "+ GetMax(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
        }
        private static int GetMax(int num1, int num2)
        {
            if (num1 > num2)
            {
                return num1;
            }
            return num2;
        }
        private static int GetMax(params int[] arr)
        {
            return arr.Max();
        }
    }
}
