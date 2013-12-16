using System;

class InitializationArrays
{
    static void Main(string[] args)
    {
        int[] firstArray=new int[20];
        int i = 0;

        while (i < +19)
        {
            firstArray[i] = i * 5;
            Console.WriteLine(firstArray[i]);
            i++;
        }
    }
}
