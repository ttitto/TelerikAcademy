using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex08AllNumberToN
{
    /*8. Write a program that reads an integer number n from the console and prints all the numbers 
     * in the interval [1..n], each on a single line.*/
    class Ex08AllNumberToNClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert n: ");
            int n = int.Parse(Console.ReadLine());

            if (n > 1)
            {
                for (int i = 1; i <= n; i++)
                {
                    Console.WriteLine(i);
                }
            }
            else
            {
                for (int i = 1; i >= n; i--)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
