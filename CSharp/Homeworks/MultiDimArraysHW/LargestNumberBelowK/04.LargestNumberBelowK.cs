using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LargestNumberBelowK
{/*Write a program, that reads from the console an array of N integers
  * and an integer K, sorts the array and using the method Array.BinSearch() finds
  * the largest number in the array which is ≤ K.*/
    class LargestNumberBelowK
    {
        static void Main(string[] args)
        {
            Console.Write("Insert the element K: ");
            int K = int.Parse(Console.ReadLine());
            Console.Write("Insert the size N of the array: ");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine("Insert the integer elements of the array.");
            int[] myArr = new int[N];
            for (int i = 0; i < N; i++)
            {
                Console.Write("myArr[{0}]= ", i);
               myArr[i]= int.Parse(Console.ReadLine());
            }
            Array.Sort(myArr);
            int result = Array.BinarySearch(myArr, K);
            Console.WriteLine(result);
            if (result==-1)
            {
                Console.WriteLine("All the numbers are bigger than {0}",K);
            }
            if (result==-(N+1))
            {
                Console.WriteLine("All the numbers are smaller than {0}. The searched number is {1}.",K,myArr[N-1]);
            }
            if (result>(-K) && result<(-1))
            {
                Console.WriteLine("The biggest number that is smaller than {0} is {1}",K,myArr[~result-1]);
            }
            if (result>=0)
            {
                Console.WriteLine("The biggest number that is smaller than {0} is {1}", K, myArr[result - 1]);
            }
        }
    }
}
