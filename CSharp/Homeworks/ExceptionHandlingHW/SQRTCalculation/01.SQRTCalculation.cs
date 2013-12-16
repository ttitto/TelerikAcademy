using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQRTCalculation
{/*1. Write a program that reads an integer number and calculates and prints its square root. 
  * If the number is invalid or negative, print "Invalid number". In all cases finally print "Good bye".
  * Use try-catch-finally.*/
    class SQRTCalculationClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert integer number: ");
            try
            {
                long number = long.Parse(Console.ReadLine());
                if (number<=0)
                {
                    throw new ArgumentException();
                }
                Console.WriteLine("The SQRT of {0} is {1:N3}", number, Math.Sqrt((double)number));
            }
            catch (Exception ex )
            {
                if (ex is ArgumentException || ex is FormatException || ex is OverflowException)
                {
                    Console.WriteLine("Invalid number");
                }
            }
            finally
            {
                Console.WriteLine("Good bye!");
            }
        }
    }
}
