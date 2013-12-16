using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04SortThreeRealNumbers
{
    /*4. Sort 3 real values in descending order using nested if statements.*/
    class Ex04SortThreeRealNumbersClass
    {
        static void Main(string[] args)
        {
            Console.Write("first integer: ");
            double first = double.Parse(Console.ReadLine());
            Console.Write("second integer: ");
            double second = double.Parse(Console.ReadLine());
            Console.Write("third integer: ");
            double third = double.Parse(Console.ReadLine());

            if (first<second)
            {
                //swap
                first += second;
                second = first-second;
                first = first-second;
            }
            if (second<third)
            {
                //swap
                third += second;
                second = third-second;
                third = third-second;
            }
            if (first < second)
            {
                //swap
                first += second;
                second = first - second;
                first = first - second;
            }
            Console.WriteLine("{0}>{1}>{2}",first, second, third);
        }
    }
}
