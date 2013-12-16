using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Ex01SumAverageOfIntsInList
{
    class Ex01SumAverageOfIntsInListClass
    {
        static void Main(string[] args)
        {
            /*01. Write a program that reads from the console a sequence of positive integer numbers. The sequence ends when 
             * empty line is entered. Calculate and print the sum and average of the elements of the sequence. Keep the 
             * sequence in List<int>.*/
            List<int> list = new List<int>();
            string input = string.Empty;
            while ((input=Console.ReadLine())!=string.Empty)
            {
                list.Add(int.Parse(input));
            }
            BigInteger sum = list.Sum();
            double average = list.Average();
            Console.WriteLine("sum: {0}\naverage: {1:0.000}",sum, average);
        }
    }
}
