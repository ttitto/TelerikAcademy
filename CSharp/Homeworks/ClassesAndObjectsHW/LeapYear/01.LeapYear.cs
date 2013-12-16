using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeapYear
{/*Write a program that reads a year from the console and checks whether 
  * it is a leap. Use DateTime.*/
    //http://support.microsoft.com/kb/214019
    class LeapYearClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert the year: ");
            DateTime myDate =  DateTime.Parse("01.01." + Console.ReadLine());
            if (DateTime.IsLeapYear(myDate.Year))
            {
                Console.WriteLine("The year {0} is leap.",myDate.Year);
            }
            else Console.WriteLine("The year {0} is not leap.", myDate.Year);
        }
    }
}
