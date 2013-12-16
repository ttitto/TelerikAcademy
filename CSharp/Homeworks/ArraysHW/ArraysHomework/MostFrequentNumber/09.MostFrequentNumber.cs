using System;
class MostFrequentNumber
{
    static void Main(string[] args)
    {
        Console.Write("Insert the array length: ");
        int arrLength = int.Parse(Console.ReadLine());

        int[] myArray = new int[arrLength];
        int a = 0;
        while (a < arrLength)
        {
            myArray[a] = int.Parse(Console.ReadLine());
            a++;
        }
        Array.Sort(myArray);

            int currentMember=0;
            int currentCount=0;
            int maxMember=0;
            int maxCount=0;

        for (int i = 0; i < arrLength; i++)
        {
            if (i==0)
            {
                currentMember = myArray[i];
                maxMember = currentMember;
                currentCount = 1;
            }
            else
            {
                if (myArray[i]==myArray[i-1])
                {
                    currentCount++;
                }
                if (myArray[i]!=myArray[i-1])
                {
                    currentMember = myArray[i];
                    currentCount = 1;
                }
                if (currentCount>maxCount)
                {
                    maxCount = currentCount;
                    maxMember = currentMember;
                }
            }
        }
        Console.WriteLine("Most frequent number: {0} ({1})times",maxMember,maxCount);
    }
}
