using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortStringArrayByLengthOfElements
{/*You are given an array of strings. Write a method that sorts the array by the length of 
  * its elements (the number of characters composing them)*/
    class SortStringArrayByLengthOfElements
    {
        static void Main(string[] args)
        {
            //Array Input
            Console.Write("Insert the length N of the array: ");
            int N=int.Parse(Console.ReadLine());
            Console.WriteLine("Insert the string elements of the array:");
            string[] myArr = new string[N];
            for (int i = 0; i < N; i++)
            {
                Console.Write("myArr[{0}] :",i);
                myArr[i] = Console.ReadLine();
            }
            SortStrArray(myArr);
            //Print the sorted array
            foreach (var item in myArr)
            {
                Console.WriteLine(item);
            }

        }
        private static void SortStrArray(string[] unsortedArray)
        {
            int[] KeyArray = new int[unsortedArray.Length];
            for (int i = 0; i < unsortedArray.Length; i++)
            {
                KeyArray[i] = unsortedArray[i].Length;
            }
            Array.Sort(KeyArray, unsortedArray);
        }
    }
}
