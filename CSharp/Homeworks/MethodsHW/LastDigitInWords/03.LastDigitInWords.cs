using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LastDigitInWords
{
    /*Write a method that returns the last digit of given integer as an English word. 
     * Examples: 512  "two", 1024  "four", 12309  "nine".*/
    class LastDigitInWords
    {
        static void Main(string[] args)
        {
            Console.Write("Insert an integer: ");
            Console.WriteLine("The last digit is {0}.",AssignWordForLastDigit(int.Parse(Console.ReadLine())));
        }
        private static string AssignWordForLastDigit(int number)
        {
            int lastDigit= (number%10);
            switch (lastDigit)
            {
                case 0:
                    return "zero";
                    case 1:
                    return "one";
                    case 2:
                    return "two";
                    case 3:
                    return "three";
                    case 4:
                    return "four";
                    case 5:
                    return "five";
                    case 6:
                    return "six";
                    case 7:
                    return "seven";
                    case 8:
                    return "eigth";
                    case 9:
                    return "nine";
                default :
                    return "";
            }
      
        }

    }
}
