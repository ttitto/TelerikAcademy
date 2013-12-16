using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex05BiggestNumber
{
    /*5. Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements.*/
    class Ex05BiggestNumberClass
    {
        static void Main(string[] args)
        {
            Console.Write("First number: ");
            double first = double.Parse(Console.ReadLine());
            Console.Write("Second number: ");
            double second = double.Parse(Console.ReadLine());

            Console.WriteLine("The bigger number is {0}", (first > second) ? first : second);

        }
    }
}
