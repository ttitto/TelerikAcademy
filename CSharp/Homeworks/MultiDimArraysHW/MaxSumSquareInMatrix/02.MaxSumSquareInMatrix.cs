using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaxSumSquareInMatrix
{/*Write a program that reads a rectangular matrix of size N x M and 
  * finds in it the square 3 x 3 that has maximal sum of its elements.*/
    class MaxSumSquareInMatrix
    {
        static void Main(string[] args)
        {
            double maxSum = 0.0;
            int[] maxIndx=new int [2];
            //reads the numbers N,M and square size SS
            Console.Write("Insert the first size of the matrix: ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("Insert the second size of the matrix: ");
            int M = int.Parse(Console.ReadLine());
            Console.Write("Insert the size of the square: ");
            int SS = int.Parse(Console.ReadLine());
            Console.WriteLine();
            //Matrix declaration
            double[,] myArr = new double[N, M];
            #region Manual Input
            ////reads the elements of the matrix
            //Console.WriteLine("Insert the elements of the matrix by rows:");
            //for (int row = 0; row < N; row++)
            //{
            //    for (int col = 0; col < M; col++)
            //    {
            //        Console.Write("myArr[{0},{1}]=", row, col);
            //        myArr[row, col] = double.Parse(Console.ReadLine());
            //    }
            //}
            #endregion
            #region Random Input
            Random random = new Random();
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < M; col++)
                {
                    myArr[row, col] = random.Next(1, 150);
                }
            }
            #endregion
            //Looping through the elements of the matrix
            for (int row = 0; row <= N - SS; row++)
            {
                for (int col = 0; col <= M - SS; col++)
                {
                    double currSum=0;
                    //Looping through the elements of the square
                    for (int i = row; i < row + SS; i++)
                    {
                        for (int j = col; j < col + SS; j++)
                        {
                            //adding the element to a current sum

                            currSum += myArr[i, j];
                        }
                    }
                    //checking if the current sum is bigger than the maximal for the moment
                    if (currSum>maxSum)
                    {
                        maxSum = currSum;
                        maxIndx[0] = row;
                        maxIndx[1] = col;
                    }
                }
            }
            //print the matrix
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < M; col++)
                {
                    Console.Write("{0,4} ",myArr[row,col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            //print the square and the resulting sum
            for (int sqRow = maxIndx[0]; sqRow < maxIndx[0]+SS; sqRow++)
            {
                for (int sqCol = maxIndx[1]; sqCol < maxIndx[1]+SS; sqCol++)
                {
                    Console.Write("{0,4} ",myArr[sqRow, sqCol]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("The maximal sum is {0}: ",maxSum);
        }
    }
}
