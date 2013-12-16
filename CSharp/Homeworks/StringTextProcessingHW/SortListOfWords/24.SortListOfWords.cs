using System;

namespace SortListOfWords
{/*24.Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.*/
    class SortListOfWordsClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert a list of words, separated by spaces: ");
            string myStr = Console.ReadLine();

         string[] myArr =myStr.Split(' ');
            Array.Sort(myArr);

           foreach (var item in myArr )
           {
               Console.WriteLine(item);
           }
        }
    }
}
