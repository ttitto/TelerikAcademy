using System;
class BinarySearch
{
    static void Main(string[] args)
    {
        Console.Write("Insert the element which index you are looking for:");
        int wantedElement = int.Parse(Console.ReadLine());
        Console.Write("Insert the array length: ");
        int arrLength = int.Parse(Console.ReadLine());
        int[] myArray = new int[arrLength];
        Console.WriteLine("Insert the elements of the array: ");
        int a = 0;
        while (a < arrLength)
        {
            myArray[a] = int.Parse(Console.ReadLine());
            a++;
        }
        Array.Sort(myArray);
        //binary search algorithm
        uint low = 0;
        uint high = (uint)myArray.Length - 1;

        while (low <= high)
        {
            uint test = (low + high) / 2;
            if (myArray[test] > wantedElement)
            {
                high = test - 1;
                continue;
            }
            else if (myArray[test] < wantedElement)
            {
                low = test + 1;
                continue;
            }
            else
            {
            }
            Console.WriteLine("The wanted element {0} is on position {1} of the array after it has been sorted.", wantedElement, low);
            break;
        }
    }
}
