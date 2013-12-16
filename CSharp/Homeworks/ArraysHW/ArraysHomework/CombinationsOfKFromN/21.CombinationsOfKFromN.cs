
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



class CombinationsOfKFromN
{
    /*21. Write a program that reads two numbers N and K and generates all the combinations of 
     * K distinct elements from the set [1..N]. Example:
	N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}*/
    class VariationsOfKFromN
    {
        static void Main(string[] args)
        {
            #region User Input
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
            #endregion
            //Populate an array with n elements
            int maxRows = (int)Math.Pow(n, k);
            int[,] myArr = new int[maxRows, k];

            for (int col = 0; col < k; col++)
            {
                int curRow = 0;
                FillColumns(myArr, n, k, maxRows, curRow, col);
            }


            #region Print result
            int[] variations = new int[myArr.GetLength(1)];
            List<int[]> sortedVariations = new List<int[]>();

            for (int r = 0; r < myArr.GetLength(0); r++)
            {
                for (int c = 0; c < myArr.GetLength(1); c++)
                {

                    variations[c] = myArr[r, c];
                }
                Array.Sort(variations);
                bool IsRepetitive = false;
                for (int cnt = 0; cnt < variations.Length - 1; cnt++)
                {
                    if (variations[cnt] == variations[cnt + 1])
                    {
                        IsRepetitive = true;
                        break;
                    }
                }
                if (IsRepetitive == false)
                {
                    //insert array into a list

                    sortedVariations.Add(variations.Clone() as int[]);
                    IsRepetitive = false;
                }
            }
            //remove repetitive arrays from the list
            List<int[]> combinations = sortedVariations.Where((a, i) => !sortedVariations.Take(i).Where(a1 => a.SequenceEqual(a1)).Any()).ToList();

            //print result
            for (int a = 0; a < combinations.Count; a++)
            {
                for (int arrItems = 0; arrItems < variations.Length; arrItems++)
                {
                    Console.Write(combinations[a][arrItems] + " ");
                }
                Console.WriteLine();
            }


            #endregion
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
