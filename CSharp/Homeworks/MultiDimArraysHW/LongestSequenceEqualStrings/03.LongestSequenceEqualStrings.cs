using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestSequenceEqualStrings
{
    class LongestSequenceEqualStrings
    {


        static void Main(string[] args)
        {
            int[] maxValues = new int[3] { 0, 0, 0 };
            //Insert values for the size of the matrix
            Console.Write("Insert the size N of the matrix: ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("Insert the size M of the matrix: ");
            int M = int.Parse(Console.ReadLine());
            //Declare and initialize the matrix NxM
            string[,] myArr = new string[N, M];
            //Populate the matrix with strings
            Console.WriteLine("Insert the string elements!");
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < M; col++)
                {
                    Console.Write("myArr[{0},{1}]= ", row, col);
                    myArr[row, col] = Console.ReadLine();
                }
            }
            //Declare a list of arrays to hold all the array with repetitions count and cell address for all cells
            List<int[]> myMaxArrays = new List<int[]>();
            //Loop trough all elements
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < M; col++)
                {
                    //check how many times each element repeats in each direction
                    //the data for every direction is returned with array[number repetitions, row of the element, col of the element]
                    //if the number of the repetitions is 2 or more, the array is added to a list of arrays
                    int[] arr = toEast(myArr, row, col).Clone() as int[];
                    if (arr[0] > 1) myMaxArrays.Add(arr);
                    arr = toSouth(myArr, row, col).Clone() as int[];
                    if (arr[0] > 1) myMaxArrays.Add(arr);
                    arr = toSouthEast(myArr, row, col).Clone() as int[];
                    if (arr[0] > 1) myMaxArrays.Add(arr);
                    arr = toNorthEast(myArr, row, col).Clone() as int[];
                    if (arr[0] > 1) myMaxArrays.Add(arr);
                }
            }
            //myMaxArrays.Sort();
            var sorted =
                from arr in myMaxArrays
                orderby arr[0] descending
                select arr;
            var filtered = from arr in sorted
                           where arr[0] == sorted.First()[0]
                           select arr;
           //Console.Write( sorted.First()[0]);
            foreach (var item in filtered)
            {
                Console.WriteLine("The string \"{0}\" has been repeated {1} times.", myArr[item[1], item[2]], item[0]);
            }
        }

        private static int[] toEast(string[,] checkedArr, int startRow, int startCol)
        {
            int n = checkedArr.GetLength(0);
            int m = checkedArr.GetLength(1);
            int[] currentMaxArr = new int[] { 0, 0, 0 };
            if (startCol > m - 2)
            {
                return currentMaxArr;
            }
            int currentCount = 1;
            int maxCol = 0;


            for (int col = startCol; col < m - 1; col++)
            {
                if (checkedArr[startRow, col] != checkedArr[startRow, col + 1])
                {
                    break;
                }
                else
                {
                    currentCount++;
                    maxCol = col;
                }
            }
            if (currentCount > currentMaxArr[0] && currentCount > 1)
            {
                currentMaxArr[0] = currentCount;
                currentMaxArr[1] = startRow;
                currentMaxArr[2] = maxCol;
            }

            return currentMaxArr;
        }
        private static int[] toSouth(string[,] checkedArr, int startRow, int startCol)
        {
            int n = checkedArr.GetLength(0);
            int m = checkedArr.GetLength(1);
            int[] currentMaxArr = new int[] { 0, 0, 0 };
            if (startRow > n - 2)
            {
                return currentMaxArr;
            }
            int currentCount = 1;
            int maxRow = 0;

            for (int row = startRow; row < n - 1; row++)
            {
                if (checkedArr[row, startCol] != checkedArr[row + 1, startCol])
                {
                    break;
                }
                else
                {
                    currentCount++;
                    maxRow = row;
                }
            }
            if (currentCount > currentMaxArr[0] && currentCount > 1)
            {
                currentMaxArr[0] = currentCount;
                currentMaxArr[1] = maxRow;
                currentMaxArr[2] = startCol;
            }
            return currentMaxArr;
        }
        private static int[] toSouthEast(string[,] checkedArr, int startRow, int startCol)
        {
            int n = checkedArr.GetLength(0);
            int m = checkedArr.GetLength(1);
            int[] currentMaxArr = new int[] { 0, 0, 0 };
            if (startRow > n - 2 || startCol > m - 2)
            {
                return currentMaxArr;
            }
            int currentCount = 1;
            int maxRow = 0;
            int maxCol = 0;
            for (int row = startRow, col = startCol; row < n - 1; row++, col++)
            {
                if (checkedArr[row, col] != checkedArr[row + 1, col + 1])
                {
                    break;
                }
                else
                {
                    currentCount++;
                    maxRow = row;
                    maxCol = col;
                }
            }
            if (currentCount > currentMaxArr[0] && currentCount > 1)
            {
                currentMaxArr[0] = currentCount;
                currentMaxArr[1] = maxRow;
                currentMaxArr[2] = maxCol;
            }
            return currentMaxArr;
        }
        private static int[] toNorthEast(string[,] checkedArr, int startRow, int startCol)
        {
            int n = checkedArr.GetLength(0);
            int m = checkedArr.GetLength(1);
            int[] currentMaxArr = new int[] { 0, 0, 0 };
            if (startRow < 1 || startCol > m - 2)
            {
                return currentMaxArr;
            }
            int currentCount = 1;
            int maxRow = 0;
            int maxCol = 0;
            for (int row = startRow, col = startCol; row > 0; row--, col++)
            {
                if (checkedArr[row, col] != checkedArr[row - 1, col + 1])
                {
                    break;
                }
                else
                {
                    currentCount++;
                    maxRow = row;
                    maxCol = col;
                }
            }
            if (currentCount > currentMaxArr[0] && currentCount > 1)
            {
                currentMaxArr[0] = currentCount;
                currentMaxArr[1] = maxRow;
                currentMaxArr[2] = maxCol;
            }
            return currentMaxArr;
        }
    }
}
