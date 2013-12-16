using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace DateAndTime6H30Later
{/*17.Write a program that reads a date and time given in the format: day.month.year hour:minute:second 
  * and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.
*/
    class DateAndTime6H30LaterClass
    {
        static void Main(string[] args)
        {
            DateTime firstDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy HH:mm:ss", CultureInfo.GetCultureInfo("bg-BG"));
            TimeSpan datetimeDiff = new TimeSpan(6, 30, 0);
            Console.WriteLine((firstDate + datetimeDiff).ToString("dd.MM.yyyy HH:mm:ss, dddd", CultureInfo.GetCultureInfo("bg-BG")));
        }
    }
}
