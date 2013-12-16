using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IsBiggerThanNeighbors;
namespace IndexOfBiggerThanNeighbors
{
    /*Write a method that returns the index of the first element in array that is bigger than its neighbors,
     * or -1, if there’s no such element.
     * Use the method from the previous exercise.*/
    class IndexOfBiggerThanNeighborsClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert the size of the array: ");
            int N = int.Parse(Console.ReadLine());
            int[] myArr=new int[N];
            Console.WriteLine("Insert the elements of the array!");
            for (int items = 0; items < N; items++)
            {
               myArr[items]=int.Parse(Console.ReadLine());
            }
            Console.WriteLine("The index of the first element that is bigger than its neighbors is: {0}",IndexOfBiggerThanNeighbors(myArr));
        }
        private static int IndexOfBiggerThanNeighbors(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (IsBiggerThanNeighborsClass.IsBiggerThanNeighbors(arr,i))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
