using System;
using System.Timers;

class PrimeNumbersSieveOfEratostenes
{
    /*15. Write a program that finds all prime numbers in the range [1...10 000 000]. 
     * Use the sieve of Eratosthenes algorithm (find it in Wikipedia).*/
    static void Main()
    {
        bool[] myArray = new bool[10000000];

        for (int i = 2; i * i <= myArray.Length; i++)
            if (myArray[i] == false)
                for (int j = i * i; j < myArray.Length; j += i)
                {
                    myArray[j] = true;
                }

        for (int i = 2; i < myArray.Length; i++)
        {
            if (myArray[i] == false)
                Console.Write("{0,7} ", i);
        }
        Console.WriteLine();
    }
}