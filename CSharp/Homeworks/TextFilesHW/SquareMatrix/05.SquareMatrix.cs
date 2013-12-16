using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace SquareMatrix
{/*Write a program that reads a text file containing a square matrix
  * of numbers and finds in the matrix an area of size 2 x 2 with a maximal 
  * sum of its elements. The first line in the input file contains the size 
  * of matrix N. Each of the next N lines contain N numbers separated by space.
  * The output should be a single number in a separate text file. Example:
4
2 3 3 4
0 2 3 4		=>	17
3 7 1 2
4 3 3 2
*/
    class SquareMatrixClass
    {
        static void Main(string[] args)
        {
            string InputFilePath = @"..\..\MatrixInput.txt";
            string OutputFilePath = @"..\..\MatrixOutput.txt";
            double[,] matrix;
            double result;
            try
            {
                matrix = ReadInputFileToArray(InputFilePath);
                result = FindMaxArea(matrix);
                ExportToFile(OutputFilePath, result);

            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException) Console.WriteLine("An error stopped the matrix to be filled correctly");
                else throw;
            }
        }

        private static double[,] ReadInputFileToArray(string InputFilePath)
        {
            try
            {
                double[,] matrix;
                StreamReader sr = new StreamReader(InputFilePath, Encoding.GetEncoding("UTF-8"));
                using (sr)
                {
                    //Initializes the array with the number of rows and columns of the matrix
                    //from the first line of the Input file
                    int matrixSize = int.Parse(sr.ReadLine());
                    matrix = new double[matrixSize, matrixSize];
                    //reads each row of the matrix inserts each number to an array
                    for (int i = 0; i <= matrixSize - 1; i++)
                    {
                        string line = sr.ReadLine();
                        string[] lineArr = line.Split();
                        //adds each array element to the corresponding column of the matrix
                        for (int col = 0; col < matrixSize; col++)
                        {
                            matrix[i, col] = double.Parse(lineArr[col]);
                        }
                    }
                }
                return matrix;
            }
                //If an error in the try block occurs, returns NULL, that is catched as NullReferenceException in the Main()
            catch (Exception ex)
            {
                Console.WriteLine("A two dimensional array couldn't be returned correctly: " + ex.Message);
                return null;
            }
        }
        static double FindMaxArea(double[,] matrix)
        {
            double max = 0;
            double current = 0;
            try
            {
                //Iterates trough the rows and columns of the matrix to find the max sum of four elements
                for (int row = 0; row < matrix.GetLength(0) -1; row++)
                {
                    for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                    {
                        current = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                        if (current > max) max = current;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is IndexOutOfRangeException)
                {
                    Console.WriteLine("An error during looping through the matrix occured: " + ex.Message);
                }
                else throw;
            }
            return max;
        }
        static void ExportToFile<T>(string path, T result)
        {
            StreamWriter sw;
            try
            {
                //writes the result in a new txt file and prints a message if successfull
                sw = new StreamWriter(path, false, Encoding.GetEncoding("UTF-8"));
                using (sw)
                {
                    sw.WriteLine(result);
                }
                Console.WriteLine("The result was successfully exported.");
                //offers to the user to open the resulting file and to see the result by inserting "Y"
                Console.Write("Press \"Y\" to see the exported result: ");
                if (Console.ReadLine().ToUpper()=="Y")
                {
                    Process.Start(path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured during data export: " + ex.Message);
            }

        }

    }
}
