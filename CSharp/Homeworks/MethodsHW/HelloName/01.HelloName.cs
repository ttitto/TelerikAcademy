using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloName
{
    /*Write a method that asks the user for his name and prints “Hello, <name>” (for example, “Hello, Peter!”). 
     * Write a program to test this method.*/
    class HelloNameClass
    {
        static void Main(string[] args)
        {
            PrintHelloName();

        }
        private static void PrintHelloName()
        {
            Console.Write("Please, insert your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hello, {0}!", name);
        }

    }
}
