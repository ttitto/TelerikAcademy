using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03MinMaxConsoleInput
{
    /*3. Write a program that reads from the console a sequence 
     * of N integer numbers and returns the minimal and maximal of them.*/
    class Ex03MinMaxConsoleInputClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert N: ");
            int n = int.Parse(Console.ReadLine());

            int current = 0;
            int min = 0, max = 0;
            for (int i = 0; i < n; i++)
            {
                current = int.Parse(Console.ReadLine());
                if (current<min)
                {
                    min = current;
                }
                if (current>max)
                {
                    max = current;
                }
            }
            Console.WriteLine("The minimal number is {0}.\nThe maximal number is {1}.",min,max);
        }
    }
}
