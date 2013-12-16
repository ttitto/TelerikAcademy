using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumbersInLimitedRange
{/*Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end]. 
  * If an invalid number or non-number text is entered, the method should throw an exception. 
  * Using this method write a program that enters 10 numbers:
			a1, a2, … a10, such that 1 < a1 < … < a10 < 100*/
    class NumbersInLimitedRangeClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert the lower bound of the range: ");
            int start = int.Parse(Console.ReadLine());
            Console.Write("Insert the higher bound of the range: ");
            int end = int.Parse(Console.ReadLine());
            for (int i = 0; i < 10; i++)
            {
                ReadNumber(start,end);
            }
        }
        static int ReadNumber(int start, int end)
        {
            int num=0;
            try
            {
                num = int.Parse(Console.ReadLine());
                if (num>end || num<start)
                {
                    throw new ArgumentException( String.Format( "Insert a valid number in the range [{0},{1}]",start, end));
                }
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is FormatException)
                {
                    Console.WriteLine("Invalid number has been inserted." + ex.Message);
                }
                else throw;
            }
            return num;
        }
    }
}
