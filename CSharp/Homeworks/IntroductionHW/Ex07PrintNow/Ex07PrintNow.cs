using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ex07PrintNow
{
    /*Create a console application that prints the current date and time.*/
    class Ex07PrintNowClass
    {
        static void Main(string[] args)
        {
            //Sets the current thread to use the bulgarian formatting for date and time that is set in the regional settings 
            //of the Windows
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("BG-bg");
            //Sets the console output channel to print UTF8 symbols correctly
            Console.OutputEncoding = Encoding.GetEncoding("UTF-8");
            Console.WriteLine(DateTime.Now);
        }
    }
}
