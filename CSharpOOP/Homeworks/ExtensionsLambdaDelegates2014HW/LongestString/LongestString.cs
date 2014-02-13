using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestString
{
    /*17. Write a program to return the string with maximum length from an array of strings. Use LINQ.*/
    class LongestStringClass
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            string[] strArr = new string[rnd.Next(10, 30)];
            for (int i = 0; i < strArr.Length; i++)
            {
                strArr[i] = new string((char)rnd.Next(0, 255), rnd.Next(2, 20));
            }

            var longest = from str in strArr
                          orderby str.Length descending
                          select str;

            Console.WriteLine(longest.ToList()[0]);

        }
    }
}
