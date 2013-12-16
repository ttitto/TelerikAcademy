using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReverseDigits;
namespace MultiTaskProgram
{
    /*Write a program that can solve these tasks:
Reverses the digits of a number
Calculates the average of a sequence of integers
Solves a linear equation a * x + b = 0
		Create appropriate methods.
		Provide a simple text-based menu for the user to choose which task to solve.
		Validate the input data:
The decimal number should be non-negative
The sequence should not be empty
a should not be equal to 0
*/
    class MultiTaskProgramClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("To reverse the digits of a non-negative decimal number: choose 1");
            Console.WriteLine("To calculate the average of a sequence of integers: choose 2");
            Console.WriteLine("To solve a linear equation: choose 3");
            string task = Console.ReadLine();
            switch (task)
            {
                #region Reverse Decimal
                case "1":
                    Console.Write("Insert a decimal number: ");
                    decimal decNum;
                    while (true)
                    {
                        decNum = decimal.Parse(Console.ReadLine());
                        if (ValidateDecimal(decNum))
                        {
                            break;
                        }
                        else Console.Write("Decimal number is not valid. Insert new number: ");
                    }
                    Console.WriteLine(ReverseDigitsClass.ReverseDigits(decNum));
                    break;
                #endregion
                #region Calculate Average
                case "2":
                    Console.Write("Insert the count of the integers: ");
                    int numCount = int.Parse(Console.ReadLine());
                    List<long> numList = new List<long>();
                    Console.WriteLine("Insert the integers: ");
                    while (numCount > 0)
                    {
                        long number;
                        if (long.TryParse(Console.ReadLine(), out number))
                        {
                            numList.Add(number);
                        }

                        numCount--;
                    }

                    if (ValidateSequence(numList))
                    {
                        Console.WriteLine("The average of the inserted integers is equal to: {0,2:N}", Average(numList.ToArray()));
                    }
                    else Console.WriteLine("The sequence is empty!");
                    break;
                #endregion
                case "3":
                    Console.WriteLine("a*x+b=0");
                    Console.Write("Insert the member a: ");
                    double a = double.Parse(Console.ReadLine());
                    while (!ValidateA(a))
                    {
                        Console.WriteLine("a can not be zero. Repeat input!");
                        a = double.Parse(Console.ReadLine());
                    }
                    Console.Write("Insert the member b: ");
                    double b = double.Parse(Console.ReadLine());
                    double result = -b / a;
                    Console.WriteLine("The result is {0,2:N}",result);
                    break;
                default:
                    break;
            }

        }
        private static bool ValidateDecimal(decimal num)
        {
            if (num >= 0m)
            {
                return true;
            }
            else return false;
        }
        private static double Average(params long[] nums)
        {
            return nums.Average();
        }
        private static bool ValidateSequence(List<long> seq)
        {
            if (seq.Count < 1)
            {
                return false;
            }
            else return true;
        }
        private static bool ValidateA(double memberA)
        {
            if (memberA != 00)
            {
                return true;
            }
            else return false;
        }
    }
}
