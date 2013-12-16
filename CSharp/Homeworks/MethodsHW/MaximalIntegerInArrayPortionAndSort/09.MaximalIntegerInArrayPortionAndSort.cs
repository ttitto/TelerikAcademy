using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximalIntegerInArrayPortionAndSort
{
    /*Write a method that returns the maximal element in a portion of array of integers starting at given index.
     * Using it write another method that sorts an array in ascending / descending order.*/
    class MaximalIntegerInArrayPortionAndSort
    {
        static void Main(string[] args)
        {
            Console.Write("Insert the size of the array: ");
            int N = int.Parse(Console.ReadLine());
            int[] myArr = new int[N];
            Console.WriteLine("Insert the elements of the array!");
            for (int items = 0; items < N; items++)
            {
                myArr[items] = int.Parse(Console.ReadLine());
            }
            Console.Write("Choose the sorting direction (asc or desc): ");
            string sortingDirection = Console.ReadLine();
            SortArray(myArr, sortingDirection);
            //print sorted array
            foreach (var item in myArr)
            {
                Console.Write(item + " ");
            }
            Console.ReadLine();
        }
        private static int FindMax(int[] arr, int startIndex)
        {
            int length = arr.Length;
            int[] partArr = new int[length - startIndex];
            arr.CopyTo(partArr, startIndex);
            return partArr.Max();
        }
        private static void SortArray(int[] arr, string direction)
        {
            switch (direction)
            {
                case "desc":
                    int[] descArr = new int[arr.Length];
                    for (int i = 0; i < descArr.Length; i++)
                    {
                        descArr[i] = FindMax(arr, 0);
                        arr[Array.IndexOf(arr, descArr[i])] = int.MinValue;
                    }
                    descArr.CopyTo(arr, 0);
                    break;
                case "asc":
                    int[] ascArr = new int[arr.Length];
                    for (int i =ascArr.Length-1 ; i >=0 ; i--)
                    {
                        ascArr[i] = FindMax(arr, 0);
                        arr[Array.IndexOf(arr, ascArr[i])] = int.MinValue;
                    }
                    ascArr.CopyTo(arr, 0);
                    break;


                default: Console.WriteLine("Direction is not recognized! Please write \"desc\" or \"asc\"!");
                    return;
            }
        }
    }
}
