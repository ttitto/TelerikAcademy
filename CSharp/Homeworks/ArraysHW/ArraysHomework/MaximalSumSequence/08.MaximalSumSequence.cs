using System;
class MaximalSumSequence
{
    static void Main(string[] args)
    {
        int currentSum = 0;
        int maxSum = int.MinValue;
        int maxSeqLength = 0;
        int maxStartPoint = 0;
        Console.Write("Insert the array length: ");
        int arrLength = int.Parse(Console.ReadLine());

        int[] myArray = new int[arrLength];
        int a = 0;
        while (a < arrLength)
        {
            myArray[a] = int.Parse(Console.ReadLine());
            a++;
        }
        for (int startpoint = 0; startpoint <= arrLength - 1; startpoint++)
        {
            for (int seqLength = 2; seqLength <= arrLength - startpoint; seqLength++)
            {
                int addCounter = 0;
                while (addCounter < seqLength)
                {
                    currentSum = myArray[startpoint + addCounter] + currentSum;
                    addCounter++;
                }
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxStartPoint = startpoint;
                    maxSeqLength = seqLength;
                }
                currentSum = 0;
            }
        }
        Console.WriteLine("maxSum:{0}", maxSum);
        for (int i = maxStartPoint; i < maxStartPoint + maxSeqLength; i++)
        {
            Console.Write("{0}, ", myArray[i]);
        }
            Console.WriteLine();

    }
}
