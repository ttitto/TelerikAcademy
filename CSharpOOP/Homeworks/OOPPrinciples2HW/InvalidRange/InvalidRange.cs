using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvalidRange
{
    class InvalidRangeClass
    {
        static void Main(string[] args)
        {
            InvalidRangeException<int> ex = new InvalidRangeException<int>("My message: ");
            Console.WriteLine(ex.Message);
            InvalidRangeException<DateTime> exDT = new InvalidRangeException<DateTime>();
            Console.WriteLine(exDT.Message);
        }
    }
}
