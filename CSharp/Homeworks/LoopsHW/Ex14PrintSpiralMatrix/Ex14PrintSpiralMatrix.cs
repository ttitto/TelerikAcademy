using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex14PrintSpiralMatrix
{
    /**14.  Write a program that reads a positive integer number N (N < 20) from
     * console and outputs in the console the numbers 1 ... N numbers arranged as a spiral.
		Example for N = 4
     * 
     * 1   2  3 4
     * 12 13 14 5
     * 11 16 15 6
     * 10  9  8 7
*/
    class Ex14PrintSpiralMatrixClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert N: ");
            int n = int.Parse(Console.ReadLine());

            int row = 0;
            int col = -1;
            int value = 1;

            int[,] matrix = new int[n, n];

            //draw first row
            for (int i = 0; i < n; i++)
            {
                col++;
                matrix[0, col] = value;
                value++;
            }

            for (int steps = n - 1; steps > 0; steps--)
            {
                //fill down
                int cnt = 0;
                do
                {
                    row++;
                    if (matrix[row, col] != 0)
                    {
                        continue;
                    }
                    matrix[row, col] = value;
                    value++;
                    cnt++;
                } while (cnt<steps);

                //fill left
                cnt = 0;
                do
                {
                    col--;
                    if (matrix[row, col] != 0)
                    {
                        continue;
                    }
                    matrix[row, col] = value;
                    value++;
                    cnt++;
                } while (cnt<steps);

                cnt = 0;
                steps--;
                //fill up
                do
                {
                    row--;
                    if (matrix[row, col] != 0)
                    {
                        continue;
                    }
                    matrix[row, col] = value;
                    value++;
                    cnt++;
                } while (cnt<steps);
                cnt = 0;
                //fill right
                do
                {
                    col++;
                    if (matrix[row,col]!=0)
                    {
                        continue;
                    }
                    matrix[row, col] = value;
                    value++;
                    cnt++;
                } while (cnt<steps);
            }


            PrintMatrix(matrix);
            Console.ReadLine();
        }
        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(" {0,3}", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
