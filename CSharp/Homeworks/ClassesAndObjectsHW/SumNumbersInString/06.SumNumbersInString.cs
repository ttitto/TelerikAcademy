using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SumNumbersInString
{/*You are given a sequence of positive integer values written into a string, separated by spaces. 
  * Write a function that reads these values from given string and calculates their sum. 
  * Example:string = "43 68 9 23 318"  result = 461*/
    class SumNumbersInStringClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert a string with positive integers, separated by spaces: ");
            string myStr=Console.ReadLine();
            int sum = 0;
           string[] myArr= myStr.Split(' ');
           foreach (var item in myArr)
           {
               sum += int.Parse(item);
           }
           Console.WriteLine("The sum of the numbers is: {0}",sum);
        }
    }
}
