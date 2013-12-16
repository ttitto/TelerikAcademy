using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkdaysBetweenTwoDates
{/*Write a method that calculates the number of workdays between today and given date, passed as parameter. 
  * Consider that workdays are all days from Monday to Friday except a fixed list 
  * of public holidays specified preliminary as array.*/
    class WorkdaysBetweenTwoDatesClass
    {
        static void Main(string[] args)
        {
            //Fill holidays list with random number of random dates
            List<DateTime> holidays = new List<DateTime>();
            Random rndCount = new Random();
            int holidaysCount = rndCount.Next(30, 80);
            for (int i = 0; i < holidaysCount; i++)
            {
                holidays.Add(RandomDate());
            }
            holidays.Sort();
            //Prints the holidays list on the console
            Console.WriteLine("Holidays list in the next 5 years:");
            foreach (DateTime item in holidays)
            {
                Console.WriteLine("{0,25} {1}", item, item.DayOfWeek);
            }
            //read the end date from the console
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            //how many holidays fall on a Saturday and Sunday
            int holidaysOnWeekend = 0;

            //checks the total holidays count between today and a given end date
            List<DateTime> totalHolidays = new List<DateTime>();
            foreach (DateTime item in holidays)
            {
                if (item <= endDate && item > DateTime.Today)
                {
                    totalHolidays.Add(item);

                    if (item.DayOfWeek == DayOfWeek.Saturday || item.DayOfWeek == DayOfWeek.Sunday)
                    {
                        holidaysOnWeekend++;
                    }
                }
            }
            //checks how many days at all are between today and a given date
            int totalDiff = endDate.Subtract(DateTime.Today).Days;
            /*the total working days in the period is equal the total days between the two dates without
             * the numbers of the holidays in this period + the number of holidays that are falling on a weekend-all the weekend days*/
            int weeks = totalDiff / 7;
            int weekendDays = weeks * 2;
            for (int i = 1; i <= totalDiff%7; i++)
            {
                if (DateTime.Today.AddDays(totalDiff - totalDiff % 7 + i).DayOfWeek == DayOfWeek.Saturday ||
                    DateTime.Today.AddDays(totalDiff - totalDiff % 7 + i).DayOfWeek == DayOfWeek.Sunday)
                {
                    weekendDays++;
                } 
            }
            int workDays = totalDiff - totalHolidays.Count + holidaysOnWeekend - weekendDays;
            Console.WriteLine("There are {0} working days in the period from {1:d} to {2:d}.", workDays, DateTime.Today, endDate);
        }
        //Random generator method for datetime values in the next 5 years
        static Random rnd = new Random();
        static DateTime RandomDate()
        {
            DateTime end = new DateTime(2018, 08, 06);
            int range = (end - DateTime.Today).Days;
            return DateTime.Today.AddDays(rnd.Next(range));
        }
    }
}
