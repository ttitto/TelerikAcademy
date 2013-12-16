using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12PrintMatrix
{
    /*12. Write a program that reads from the console a positive integer number N (N < 20) and 
     * outputs a matrix like the following:
	N = 3			N = 4
     * 1 2 3
     * 2 3 4
     * 3 4 5
     */

    class Ex12PrintMatrixClass
    {
        static void Main(string[] args)
        {
            Console.Write("insert N: ");
            uint n = uint.Parse(Console.ReadLine());

            for (int row = 0; row < n; row++)
            {
                for (int col = 1 + row; col <= n + row; col++)
                {
                    Console.Write(" {0,2}",col);
                }
                Console.WriteLine();
            }
        }
    }
}
