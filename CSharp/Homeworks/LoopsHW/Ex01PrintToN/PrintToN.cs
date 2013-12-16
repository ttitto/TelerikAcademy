using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintToN
{/*1. Write a program that prints all the numbers from 1 to N.*/
    class PrintToNClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert N: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write(" {0}", i+1);
            }
            Console.WriteLine();
        }
    }
}
