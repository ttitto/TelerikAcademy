using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsBiggerThanNeighbors
{
    /*Write a method that checks if the element at given position in
     * given array of integers is bigger than its two neighbors (when such exist).*/
  public  class IsBiggerThanNeighborsClass
    {
        static void Main(string[] args)
        {
        }
      //The Method below is used in Exercise 6
        public static bool IsBiggerThanNeighbors(int[] arr, int position)
        {
            //returns true if the Element at a given position has two neighbors and they are both smaller than the Element at arr[position]
            int arrLength = arr.Length;
            if (position > arrLength - 2 || position < 1)
            {
                return false;
            }
            if (arr[position] > arr[position - 1] && arr[position] > arr[position + 1])
            {
                return true;
            }
            return false;
        }
    }
}
