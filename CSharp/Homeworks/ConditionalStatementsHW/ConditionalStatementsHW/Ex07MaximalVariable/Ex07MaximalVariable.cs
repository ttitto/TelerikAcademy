using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex07MaximalVariable
{
    /*7. Write a program that finds the greatest of given 5 variables.*/
    class Ex07MaximalVariableClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert five variables!");
            int[] variables = new int[5];
            for (int i = 0; i < variables.Length; i++)
            {
                variables[i] = int.Parse(Console.ReadLine());
            }

            int max = int.MinValue;
            for (int i = 0; i < variables.Length; i++)
            {
                if (variables[i] > max)
                {
                    max = variables[i];
                }
            }
            Console.WriteLine("the greatest is: {0}", max);


        }
    }
}
