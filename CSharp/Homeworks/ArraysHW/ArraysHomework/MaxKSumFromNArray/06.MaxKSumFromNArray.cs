using System;
class MaxKSumFromNArray
{
    static void Main(string[] args)
    {
        int k = 0;
        int n = 0;
        while (true)
        {
            Console.Write("Въведете големината на масива:");
            n = int.Parse(Console.ReadLine());
            Console.Write("Въведете броят на елементите, участващи в максималната сума:");
            k = int.Parse(Console.ReadLine());
            if ( k <= n)
            {
                break;
            }

        }

        int[] arrayN = new int[n];
        int maxSum = 0;
        int currentSum=0;
        int startIndx = 0;
        Console.WriteLine("Въведете елементите на масива: ");

        for (int i = 0; i < n; i++)
        {
            Console.Write("елемент{0}: ",i);
            arrayN[i] = int.Parse(Console.ReadLine());
            if (k-1<=i)
            {
                for (int a = i-k+1; a < i+1; a++)
                {
                    currentSum+=arrayN[a];
                }
            }
            if (currentSum>=maxSum)
            {
                maxSum = currentSum;
                startIndx = i - k + 1;
            }
            currentSum = 0;
        }
        Console.WriteLine("Максималната сума от {0} броя елемента е {1} и е съставена от следните елементи: ",k,maxSum);
        for (int i = startIndx; i < startIndx+k; i++)
        {
            Console.Write(arrayN[i]+" ");
        }
        Console.WriteLine();
    }
}
