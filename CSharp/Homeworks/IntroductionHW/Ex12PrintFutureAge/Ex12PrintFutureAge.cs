using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12PrintFutureAge
{
    /** Write a program to read your age from the console and print how old you will be after 10 years.*/
    class Ex12PrintFutureAgeClass
    {
        static void Main(string[] args)
        {
            Console.Write("Print your current age:");
            int age;
            //try to convert the input to an integer, if success assign the number to the variable age,
            //add 10 to age and print it
            if (int.TryParse(Console.ReadLine(), out age)) Console.WriteLine("Your age in 10 years will be {0}",age+10);
            //if the number can not be converted to a number then print warning
            else Console.WriteLine("Invalid input!");
        }
    }
}
