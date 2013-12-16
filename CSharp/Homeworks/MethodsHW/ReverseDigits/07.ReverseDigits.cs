using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReverseDigits
{
    /*Write a method that reverses the digits of given decimal number. Example: 256  652*/
  public  class ReverseDigitsClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert a decimal number: ");
            Console.WriteLine(ReverseDigits(decimal.Parse(Console.ReadLine())));
        }
        //The method will consider the decimal point as a char in a string and will reverse its position too
        public static decimal ReverseDigits(decimal number)
        {
            string strNumber = number.ToString();
            int length=strNumber.Length;
            string newStrnumber="";
            for (int i = length-1; i >=0; i--)
            {
                newStrnumber = newStrnumber+ strNumber[i];
            }
            return decimal.Parse(newStrnumber);
        }

    }
}
