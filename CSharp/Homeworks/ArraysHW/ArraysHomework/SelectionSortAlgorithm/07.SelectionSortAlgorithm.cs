using System;
class SelectionSortAlgorithm
{
    static void Main(string[] args)
    {
        //Array input
        Console.Write("Въведете големината на масива:");
        int n = int.Parse(Console.ReadLine());
        int[] myArray = new int[n];
            Console.WriteLine("Въведете елементите на масива:");

        for (int i = 0; i < n; i++)
        {
            myArray[i] = int.Parse(Console.ReadLine());
        }
        //"Selection sort" algorithm
        for (int a = 0; a < myArray.Length - 1; a++)
        {
            int smallestIndex = a;
            for (int j = a + 1; j < myArray.Length; j++)
            {
                if (myArray[smallestIndex]>myArray[j])
                {
                    smallestIndex = j;
                }
            }
            int intermediary = myArray[smallestIndex];
            myArray[smallestIndex] = myArray[a];
            myArray[a] = intermediary;
        }
        foreach (int sorted in myArray)
        {
            Console.Write(sorted+" ");
        }
    }
}
