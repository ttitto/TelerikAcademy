using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReverseString
{/*02.Write a program that reads a string, reverses it and prints the result at the console.
Example: "sample"  "elpmas".*/
    class ReverseStringClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert the string to be reversed: ");
            string myStr = Console.ReadLine();
            myStr = new string(myStr.Reverse().ToArray());
            Console.WriteLine("The reversed string is: {0}", myStr);
        }
    }
}
