using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex08GreatestCommonDivider
{
    /*8. Write a program that calculates the greatest common divisor (GCD) 
     * of given two numbers. Use the Euclidean algorithm (find it in Internet).*/

    /*Euclid's original version - the subtraction version:
     function gcd(a, b)
    while a ≠ b
        if a > b
           a := a − b
        else
           b := b − a
    return a
     */
    class Ex08GreatestCommonDividerClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert first number: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Insert second number: ");
            int b = int.Parse(Console.ReadLine());

            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }
            Console.WriteLine("The GCD is {0}", a);
        }
    }
}
