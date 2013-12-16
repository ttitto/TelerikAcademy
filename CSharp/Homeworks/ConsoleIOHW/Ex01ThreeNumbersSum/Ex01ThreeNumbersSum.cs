using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex01ThreeNumbersSum
{
    /*1. Write a program that reads 3 integer numbers from the console and prints their sum.*/
    class Ex01ThreeNumbersSumClass
    {
        static void Main(string[] args)
        {
            Console.Write("first integer: ");
            int first = int.Parse(Console.ReadLine());
            Console.Write("second integer: ");
            int second= int.Parse(Console.ReadLine());
            Console.Write("third integer: ");
            int third= int.Parse(Console.ReadLine());

            Console.WriteLine("sum: {0}",first+second+third);
        }
    }
}
