using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberDifferentFormats
{/*11.Write a program that reads a number and prints it as a decimal number,
  * hexadecimal number, percentage and in scientific notation. Format the output aligned right in 15 symbols.*/
    class NumberDifferentFormatsClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert a number: ");
            long num = long.Parse(Console.ReadLine());
            Console.WriteLine("decimal number: {0,15:D}",num);
            Console.WriteLine("hexadecimal number: {0,15:X}", num);
            Console.WriteLine("percentage number: {0,15:P}", num);
            Console.WriteLine("scientific notation: {0,15:E}", num);

        }
    }
}
