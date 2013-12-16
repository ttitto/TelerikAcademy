using System;
class SequenceOfGivenSum
{
    static void Main(string[] args)
    {
        Console.Write("Insert the sum you are looking for:");
        int wantedSum = int.Parse(Console.ReadLine());
        Console.Write("Insert the array length: ");
        int arrLength = int.Parse(Console.ReadLine());

        int[] myArray = new int[arrLength];
        int a = 0;
        while (a < arrLength)
        {
            myArray[a] = int.Parse(Console.ReadLine());
            a++;
        }
        //Looping through all possible sums
        int currentSum = 0;
        int startpoint;
        for (startpoint = 0; startpoint <= arrLength - 1; startpoint++)
        {
            for (int seqlength = 2; seqlength <= arrLength - startpoint; seqlength++)
            {
                int addCounter = 0;
                while (addCounter < seqlength)
                {
                    currentSum = myArray[startpoint + addCounter]+currentSum;
                    addCounter++;
                }
                //if the wanted sum is found, its elements are printed
                if (currentSum==wantedSum)
                {
                    int statiStartPoint = startpoint;
                    Console.WriteLine("The wanted Sum {0} is calculated in the sequence:",wantedSum);
                    //Prints only the first sequence, that matches the criterion
                    for (startpoint=statiStartPoint; startpoint < statiStartPoint+seqlength; startpoint++)
                    {
                        Console.Write(myArray[startpoint]+ " ");
                    }
                    break;
                }
                currentSum = 0;
            }
        }
    }
}
