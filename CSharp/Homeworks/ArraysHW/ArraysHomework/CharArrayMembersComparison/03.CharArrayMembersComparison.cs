using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class CharArrayMembersComparison
{
    static void Main(string[] args)
    {
        //Members insertion
        //Reads only the first char for every ReadLine string to avoid throwing exceptions
        int shortestLength = 0;

        Console.Write("Insert the number of the members in the first array!");
        int arr1Lenght = int.Parse(Console.ReadLine());
        char[] firstArray = new char[arr1Lenght];

        Console.Write("Insert the number of the members in the second array!");
        int arr2Lenght = int.Parse(Console.ReadLine());
        char[] secondArray = new char[arr2Lenght];

        shortestLength = arr1Lenght <= arr2Lenght ? arr1Lenght : arr2Lenght;

        int i = 0;
        Console.WriteLine("Insert the members of the first array! The program will consider only the first char of every line!");
        while (i <= arr1Lenght - 1)
        {
            firstArray[i] = Convert.ToChar(Console.ReadLine()[0]);
            i++;
        }
        Console.WriteLine("Insert the members of the second array! The program will consider only the first char of every line!");
        i = 0;
        while (i <= arr2Lenght - 1)
        {
            secondArray[i] = Convert.ToChar(Console.ReadLine()[0]);
            i++;
        }
        //Members comparison
        Console.WriteLine("{0,-15} | {1,-15} | {2,-6}", "firstArray", "secondArray", "Equal?");
        i = 0;
        while (i <= shortestLength - 1)
        {
            Console.WriteLine("{0,-15} | {1,-15} | {2,-6}", firstArray[i], secondArray[i], (firstArray[i] == secondArray[i]));
            if (firstArray[i] > secondArray[i])
            {
                Console.WriteLine("The secondArray is lexicographically earlier.");
                break;
            }
            else if (firstArray[i] < secondArray[i])
            {
                Console.WriteLine("The firstArray is lexicographically earlier.");
                break;
            }
            if (i == shortestLength - 1 && arr1Lenght < arr2Lenght)
            {
                Console.WriteLine("The first array is lexicographically earlier.");
            }
            else if (i == shortestLength - 1 && arr1Lenght > arr2Lenght)
            {
                Console.WriteLine("The secondArray is lexicographically earlier.");
                break;
            }
            else if (i == shortestLength - 1)
            {
                Console.WriteLine("Both arrays are lexicographically equal.");
            }
            i++;
        }

    }
}
