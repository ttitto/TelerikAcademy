using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CountRepetitionsInArray
{
    /*Write a method that counts how many times given number appears in given array.
     * Write a test program to check if the method is working correctly*/
  public  class CountRepetitionsInArrayClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert the size of the array: ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("Insert the number K you are looking for: ");
            double K = double.Parse(Console.ReadLine());

            double[] myArr = new double[N];
            //Populate the array with doubles
            Console.WriteLine("Insert the numbers of the array!");
            for (int i = 0; i < N; i++)
            {
                myArr[i] = double.Parse(Console.ReadLine());
            }
            //Call CountRepetitionsOf Method and print result
            Console.WriteLine("{0} appears {1} times in the array.",K,CountRepetitionsOf(myArr, K));
            
        }
        public static int CountRepetitionsOf(double[] arr, double searched)
        {
            //using System.Linq;
            var KRepetitions = from arrElement in arr
                               where arrElement == searched
                               select arrElement;
            return KRepetitions.Count();
        }

    }
}
