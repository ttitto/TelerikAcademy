using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex10BonusScore
{
    /*10. Write a program that applies bonus scores to given scores in the range [1..9]. The program reads a digit as an input.
     * If the digit is between 1 and 3, the program multiplies it by 10; if it is between 4 and 6, multiplies it by 100;
     * if it is between 7 and 9, multiplies it by 1000. If it is zero or if the value is not a digit, the program must report an error.
		Use a switch statement and at the end print the calculated new value in the console.*/
    class Ex10BonusScoreClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert a number: ");
            int n;
            bool isNumber = int.TryParse(Console.ReadLine(), out n);

            switch (n)
            {
                case 1:
                case 2:
                case 3:
                    Console.WriteLine(n *= 10);
                    break;
                case 4:
                case 5:
                case 6:
                    Console.WriteLine(n *= 100);
                    break;
                case 7:
                case 8:
                case 9:
                    Console.WriteLine(n *= 1000);
                    break;
                default:
                    if (isNumber == false || n.ToString().Length > 1 || n == 0)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    break;

            }
        }
    }
}
