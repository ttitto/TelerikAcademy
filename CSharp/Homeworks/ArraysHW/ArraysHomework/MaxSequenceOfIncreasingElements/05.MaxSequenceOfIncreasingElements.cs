using System;
using System.Collections.Generic;
class MaxSequenceOfIncreasingElements
{
    static void Main(string[] args)
    {
        List<int> maxList = new List<int>();
        List<int> currentList = new List<int>();
        Console.Write("Insert the number of the members in the array!");
        int membersCount = int.Parse(Console.ReadLine());
        int[] myArray = new int[membersCount];
        int i = 0;
        Console.WriteLine("Insert the members of the array!");
        while (i <= membersCount - 1)
        {
            myArray[i] = int.Parse((Console.ReadLine()));
            //always inserts the first element
            if (i == 0)
            {
                currentList.Add(myArray[i]);
            }
            if (i > 0 && myArray[i] > myArray[i - 1])
            {
                if (currentList.Count==0)
                {
                    currentList.Add(myArray[i-1]);
                }
                currentList.Add(myArray[i]);
            }
            else if (i > 0)
            {
                if (currentList.Count > maxList.Count)
                {
                    maxList.Clear();
                    maxList.AddRange(currentList);
                    currentList.Clear();
                }
            }
            i++;
        }
        foreach (int listItem in maxList)
        {
            Console.Write(listItem + "  ");
        }
    }

}
