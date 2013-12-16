using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03BiggestOfThree
{
    /*3. Write a program that finds the biggest of three integers using nested if statements.*/
    class Ex03BiggestOfThreeClass
    {
        static void Main(string[] args)
        {
            Console.Write("first integer: ");
            int first = int.Parse(Console.ReadLine());
            Console.Write("second integer: ");
            int second = int.Parse(Console.ReadLine());
            Console.Write("third integer: ");
            int third = int.Parse(Console.ReadLine());

            if (first < second)
            {
                if (second < third)
                {
                    Console.WriteLine("The biggest is {0}", third);
                }
                else
                {
                    Console.WriteLine("The biggest is {0}", second);
                }
            }
            else if (first > second)
            {
                if (first > third)
                {
                    Console.WriteLine("The biggest is {0}", first);
                }
                else
                {
                    Console.WriteLine("The biggest is {0}", third);
                }
            }
        }
    }
}
