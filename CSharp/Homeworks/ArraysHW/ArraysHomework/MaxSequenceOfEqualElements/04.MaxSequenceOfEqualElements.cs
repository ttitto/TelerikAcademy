using System;

    class MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            //Паралелно с въвеждането на елементите на масива се попълва втори масив с броя на текущите повторения до момента.
            //След едновременно сортиране на двата масива се извежда броят повторения и елементът, който е най-често срещан
            //Ако елементите, които се срещат най-често са повече от един, се отпечатват всичките
            Console.Write("Insert the number of the members in the array!");
            int membersCount = int.Parse(Console.ReadLine());
            dynamic[] valArray = new dynamic[membersCount];
            int[] repetitions = new int[membersCount];
            int i = 0;
            int maxCount = 0;
            Console.WriteLine("Insert the members of the array!");
            while (i <= membersCount - 1)
            {
                valArray[i] = Console.ReadLine();
                if (i>0 && valArray[i]==valArray[i-1])
                {
                    repetitions[i] = repetitions[i - 1] + 1 ;
                }
                else
                {
                    repetitions[i] = 1;
                }
                i++;
            }
            Array.Sort(repetitions, valArray);
            maxCount = repetitions[membersCount - 1];
            for ( i = membersCount-1; i >=0 ; i--)
            {
                if (repetitions[i]==maxCount)
                {
                    Console.WriteLine("Maximal count: {0}  Array element: {1}", repetitions[i], valArray[i]);
                }
            }
        }
    }
