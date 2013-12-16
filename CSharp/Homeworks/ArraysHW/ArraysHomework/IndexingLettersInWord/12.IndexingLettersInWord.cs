using System;
class IndexingLettersInWord
{
    static void Main(string[] args)
    {
        char[] myArray = new char[26];
        for (int i = 0; i < myArray.Length; i++)
        {
            myArray[i] = (char)(i + 65);
        }
        foreach (char item in myArray)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        Console.WriteLine("Print the required word using only the above characters:");
        string word = Console.ReadLine().ToUpper();
        uint wordLength = (uint)word.Length;
        foreach (char item in word)
        {
            Console.Write("{0,3}", item);
        }
        Console.WriteLine();
        for (int a = 0; a < wordLength; a++)
        {
            // int test =Array.BinarySearch(myArray, word[a]);
            //binary search algorithm for every char in the word
            uint low = 0;
            uint high = (uint)myArray.Length;
            uint test = 0;
            while (low <= high)
            {
                test = (low + high) / 2;
                if (myArray[test] > word[a])
                {
                    high = test - 1;
                    continue;
                }
                else if (myArray[test] < word[a])
                {
                    low = test + 1;
                    continue;
                }
                else
                {
                }  
                Console.Write("{0,3}", test);
                break;
            }
            
        }

        Console.WriteLine();
    }
}
