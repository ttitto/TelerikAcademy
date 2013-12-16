using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02SignOfProduct
{
    /*2. Write a program that shows the sign (+ or -) of the product of three real numbers 
     * without calculating it. Use a sequence of if statements.*/
    class Ex02SignOfProductClass
    {
        static void Main(string[] args)
        {
            int negativeCount = 0;

            Console.Write("first number: ");
            if (double.Parse(Console.ReadLine()) < 0)
            {
                negativeCount++;
            }
            Console.Write("second number: ");
            if (double.Parse(Console.ReadLine()) < 0)
            {
                negativeCount++;
            }
            Console.Write("third number: ");
            if (double.Parse(Console.ReadLine()) < 0)
            {
                negativeCount++;
            }

            if (negativeCount%2==0)
            {
                Console.WriteLine("The sign is +.");
            }
            else Console.WriteLine("The sign is -.");
        }
    }
}
