using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex08TypeDependentAction
{
    /*8. Write a program that, depending on the user's choice inputs int, double or string variable. 
     * If the variable is integer or double, increases it with 1. If the variable is string, appends "*" at its end. 
     * The program must show the value of that variable as a console output. Use switch statement.*/
    class Ex08TypeDependentActionClass
    {
        static void Main(string[] args)
        {
            //repeats input until it is valid non-negative integer
            uint choice;
            do
            {
                Console.WriteLine("Choose type: ");
                Console.WriteLine("0. int");
                Console.WriteLine("1. double");
                Console.WriteLine("2. string");

            } while (!uint.TryParse(Console.ReadLine(), out  choice) || choice > 2);

            Console.Write("Insert value: ");

            switch (choice)
            {
                case 0:
                    //adds one to your input and prints the new integer
                    Console.WriteLine(int.Parse(Console.ReadLine()) + 1);
                    break;
                case 1:
                    Console.WriteLine(double.Parse(Console.ReadLine()) + 1);
                    break;
                case 2:
                    Console.WriteLine(Console.ReadLine() + "*");
                    break;
                default:
                    break;
            }
        }
    }
}
