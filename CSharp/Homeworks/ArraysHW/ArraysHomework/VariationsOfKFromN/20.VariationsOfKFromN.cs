using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VariationsOfKFromN
{
    /*Write a program that reads two numbers N and K and generates all the variations of K
     * elements from the set [1..N]. Example:
	N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}*/
    class VariationsOfKFromN
    {
        static void Main(string[] args)
        {
            Console.Write("Insert the number of the elements: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Insert the number of elements for each variation: ");
            int k = int.Parse(Console.ReadLine());
            //Check if k<n
            if (k > n)
            {
                Console.WriteLine("k>=n. Please restart the program!");
                return;
            }
            //Populate an array with n elements
            int maxRows = (int)Math.Pow(n, k);
            int[,] myArr = new int[maxRows, k];

            for (int col = 0; col < k; col++)
            {
                int curRow = 0;
                FillColumns(myArr, n, k, maxRows, curRow, col);
            }

            //Print result
            for (int r = 0; r < myArr.GetLength(0); r++)
            {
                for (int c = 0; c < myArr.GetLength(1); c++)
                {
                    Console.Write(myArr[r, c] + " ");
                }
                Console.WriteLine();
            }
        }
        static void FillColumns(int[,] arr, int N, int K, int MaxRows, int currentRow, int column)
        {
            int maxRep = (int)Math.Pow(N, K - column - 1);
            int numb = 1;
            for (int row = 0; row <= MaxRows - 1; row++)
            {
                for (int rep = 1; rep <= maxRep; rep++)
                {
                    arr[currentRow, column] = numb;
                    if (currentRow == MaxRows - 1)
                    {
                        break;
                    }
                    else
                    {
                        currentRow++;
                    }
                }
                if (numb == N)
                {
                    numb = 1;
                }
                else
                {
                    numb++;
                }
            }
        }
    }
}
