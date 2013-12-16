using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FillPrintSquareMatrix
{
    /*Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)*/
    class FillPrintSquareMatrix
    {
        int n;
        int[,] matrix;
        static void Main(string[] args)
        {
            //Read the size of the matrix
            Console.Write("Insert the size n for the two dimensions: ");
            int n = int.Parse(Console.ReadLine());
            //Declare and initialize a two-dim array 
            int[,] matrix = new int[n, n];
            //Populate the matrix with the numbers from 1 to n
            int startingNum = 1;
            for (int firstDim = 0; firstDim < n; firstDim++)
            {
                for (int secDim = 0; secDim < n; secDim++)
                {
                    matrix[firstDim, secDim] = startingNum;
                    startingNum++;
                }
            }

            //Calls a method for printing the result for each possibility (a,b,c,d)
            while (true)//Repeat until an error value is inserted
            {
                Console.Write("Insert the desired printing pattern (a,b,c,d)");
                char prPattern = Convert.ToChar(Console.ReadLine().ToLower()[0]);
                PrintMatrix(PrepareForPrinting(prPattern, matrix));
            }

            Console.ReadLine();
        }
        //this method changes the positions of the elements in the array according to a, b, c or d
        private static int[,] PrepareForPrinting(char printingPattern, int[,] TwoDimArr)
        {
            //creates a copy of the values  of the main array
            int[,] modifiedArr = (int[,])TwoDimArr.Clone();
            int N = modifiedArr.GetLength(0);
            switch (printingPattern)
            {
                case 'a':
                    {
                        //transposes the modified array
                        for (int row = 0; row <= N - 2; row++)
                        {
                            for (int col = row + 1; col <= N - 1; col++)
                            {
                                //swap the elements          
                                int t = modifiedArr[row, col];
                                modifiedArr[row, col] = modifiedArr[col, row];
                                modifiedArr[col, row] = t;
                            }
                        }
                        return modifiedArr;
                    }
                case 'b':
                    {
                        /* reverse the positions of the elements in every odd row so that the first is 
                          becomming the last*/
                        for (int row = 0; row < N; row++)
                        {
                            if (row % 2 != 0)
                            {
                                for (int col = 0; col < N / 2; col++)
                                {
                                    if (col != (N - col - 1))
                                    {
                                        modifiedArr[row, col] = modifiedArr[row, col] ^ modifiedArr[row, N - col - 1];
                                        modifiedArr[row, N - col - 1] = modifiedArr[row, N - col - 1] ^ modifiedArr[row, col];
                                        modifiedArr[row, col] = modifiedArr[row, col] ^ modifiedArr[row, N - col - 1];
                                    }
                                }
                            }
                        }
                        //transposes the modified array
                        for (int row = 0; row <= N - 2; row++)
                        {
                            for (int col = row + 1; col <= N - 1; col++)
                            {
                                //swap the elements          
                                int t = modifiedArr[row, col];
                                modifiedArr[row, col] = modifiedArr[col, row];
                                modifiedArr[col, row] = t;
                            }
                        }
                        return modifiedArr;
                    }
                case 'c':
                    {
                        //arranges the elements left of the main diagonal
                        int oneDimArrIndx = 1;
                        for (int row = N - 1; row <= N - 1; row++)
                        {
                            for (int col = 0; col <= N - 1; col++)
                            {
                                modifiedArr[row, col] = oneDimArrIndx;
                                oneDimArrIndx++;
                                if (row == N - 1 && col == N - 1)
                                {
                                    break;
                                }
                                if (row == N - 1)
                                {
                                    row = N - col - 3;
                                    col = -1;
                                }
                                row++;
                            }
                        }
                        //arranges the elements rigths of the main diagonal
                        for (int row = 0; row <= N - 2; row++)
                        {
                            for (int col = 1; col <= N - 1; col++)
                            {
                                modifiedArr[row, col] = oneDimArrIndx;// myOneDimArr[oneDimArrIndx];
                                oneDimArrIndx++;
                                if (col == N - 1 && row == 0)
                                {
                                    row = N - 2;
                                    break;
                                }
                                if (col == N - 1)
                                {
                                    col = N - row - 1;
                                    row = -1;
                                }
                                row++;
                            }
                        }
                        return modifiedArr;
                    }
                case 'd':
                    {
                        int row = 0;
                        int col = 0;
                        int value = 1;
                        for (row = 0; row < N; row++)
                        {
                            modifiedArr[row, col] = value;
                            value++;
                        }
                        row--;
                        for (int steps = N - 1; steps > 0; steps--)
                        {
                            for (int right = 0; right < steps; right++)
                            {
                                modifiedArr[row, col + 1] = value;
                                value++;
                                col++;
                            }
                            for (int up = 0; up < steps; up++)
                            {
                                modifiedArr[row - 1, col] = value;
                                value++;
                                row--;
                            }
                            steps--;
                            for (int left = 0; left < steps; left++)
                            {
                                modifiedArr[row, col - 1] = value;
                                value++;
                                col--;
                            }
                            for (int down = 0; down < steps; down++)
                            {
                                modifiedArr[row + 1, col] = value;
                                value++;
                                row++;
                            }
                        }
                        return modifiedArr;
                    }
                default: Console.WriteLine("Printing pattern {0} is not defined!", printingPattern);
                    break;
            }
            return modifiedArr;
        }
        private static void PrintMatrix(int[,] myMatrix)
        {
            for (int row = 0; row < myMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < myMatrix.GetLength(1); col++)
                {
                    Console.Write("{0,4} ", myMatrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        //private static int[] ConvertToOneDimension(int[,] TwoDimArr)
        //{
        //    //fill one-dimensional array from the values in the two-dimensional
        //    int[] myArr = new int[TwoDimArr.GetLength(0) * TwoDimArr.GetLength(1)];
        //    int pos = 0;
        //    for (int row = 0; row < TwoDimArr.GetLength(0); row++)
        //    {
        //        for (int col = 0; col < TwoDimArr.GetLength(1); col++)
        //        {
        //            myArr[pos] = TwoDimArr[row, col];
        //            pos++;
        //        }
        //    }
        //    return myArr;
        //}

    }
}
