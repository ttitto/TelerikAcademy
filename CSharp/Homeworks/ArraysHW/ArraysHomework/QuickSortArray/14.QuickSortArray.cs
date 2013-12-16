using System;

class QuickSortArray
{
    static void Main(string[] args)
    {
        /*Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).*/

        #region ArrayPopulation
        Console.Write("Insert the array length: ");
        int arrLength = int.Parse(Console.ReadLine());

        string[] myArray = new string[arrLength];
        Console.WriteLine("Insert the string elements of the array!: ");
        int a = 0;
        while (a < arrLength)
        {
            myArray[a] = Console.ReadLine();
            a++;
        }
        #endregion
        bool contSorting = false;
        int left ;
        int right;

        while (true)
        {
            for (int i = 0; i < arrLength; i++)
            {
                if (myArray[i].CompareTo(myArray[i + 1]) > 0)//
                {
                    contSorting = true;
                    break;
                }
                else if (i==arrLength-1 )
                {
                    contSorting = false;
                    break;
                }
            }
            if (contSorting == false)
            {
                break;
            }
            #region QuickSort
            left = 0;
            right = myArray.Length - 1;

            string test = myArray[left + (right - left) / 2];
            while (left <= right)
            {
                while (myArray[left].CompareTo(test) < 0)
                {
                    left++;
                }
                while (myArray[right].CompareTo(test) > 0)
                {
                    right--;
                }
                if (left <= right)
                {
                    string tmp = myArray[left];
                    myArray[left] = myArray[right];
                    myArray[right] = tmp;
                    left++;
                    right--;
                }
            }
            #endregion
        }


        Console.WriteLine();
        foreach (string item in myArray)
        {
            Console.Write(item + " ");
        }
    }
}
