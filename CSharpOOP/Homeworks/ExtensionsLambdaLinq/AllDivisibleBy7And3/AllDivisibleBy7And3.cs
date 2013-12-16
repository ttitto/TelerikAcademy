using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllDivisibleBy7And3
{
    /*6. Write a program that prints from given array of integers all numbers that are divisible by 7 and 3.
     * Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.*/
    public class AllDivisibleBy7And3Class
    {
        static void Main(string[] args)
        {
            int[] myArr = new int[10] { 3, 8, 21, 54, 49, 69, -42, 64, 42, 46 };
            PrintUsingExtensions(myArr);
            Console.WriteLine();
            PrintUsingLinq(myArr);
        }
       
        public static void PrintUsingExtensions(int[] myArr)
        {
            var result = myArr.Where(num => (num % 3 == 0 && num % 7 == 0));
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
        public static void PrintUsingLinq(int[] myArr)
        {
            var result = from num in myArr
                         where (num % 3 == 0 && num % 7 == 0)
                         select num;
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
