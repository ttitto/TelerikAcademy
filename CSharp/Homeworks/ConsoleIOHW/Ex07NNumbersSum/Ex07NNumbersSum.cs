using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex07NNumbersSum
{
    /*7. Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum. */
    class Ex07NNumbersSumClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert the number of addends: ");
            uint n = uint.Parse(Console.ReadLine());

            Console.WriteLine("Insert the addends: ");
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += double.Parse(Console.ReadLine());
            }

            Console.WriteLine("The sum is {0}: ", sum);
        }
    }
}
