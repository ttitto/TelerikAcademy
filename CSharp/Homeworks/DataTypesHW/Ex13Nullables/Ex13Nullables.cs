using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex13Nullables
{
    /*13. Create a program that assigns null values to an integer and to double variables. 
     * Try to print them on the console, try to add some values or the null literal to them and see the result.*/
    class Ex13NullablesClass
    {
        static void Main(string[] args)
        {
            int? myInt = null;
            double? myDouble = null;

            Console.WriteLine(myInt);
            Console.WriteLine(myDouble);
            myInt = 45;
            myDouble = 56.25;
            Console.WriteLine(myInt);
            Console.WriteLine(myDouble);
        }
    }
}
