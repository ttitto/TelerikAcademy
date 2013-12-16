using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DayOfWeek
{/*Write a program that prints to the console which day of the week is today. Use System.DateTime.*/
    class DayOfWeekClass
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Today;
            Console.WriteLine(today.DayOfWeek);
        }
    }
}
