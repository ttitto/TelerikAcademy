using System;
using System.Threading;
using System.Globalization;

namespace DistanceBetweenDates
{/*16.Write a program that reads two dates in the format: day.month.year and calculates the number of days between them. Example:
    Enter the first date: 27.02.2006
    Enter the second date: 3.03.2004
    Distance: 4 days*/
    class DistanceBetweenDatesClass
    {
        static void Main(string[] args)
        {
            try
            {
                DateTime firstDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.GetCultureInfo("bg-BG"));
                DateTime secondDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.GetCultureInfo("bg-BG"));
                int dateDiff = Math.Abs((secondDate - firstDate).Days);
                Console.WriteLine("Distance: {0} days", dateDiff);

            }
            catch (FormatException)
            {
                Console.WriteLine("String in format \"d.MM.yyyy\" expected");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured: " + ex.Message);
            }
        }
    }
}
