using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04LongestSubsequenceOfEqual
{
    /*04. Write a method that finds the longest subsequence of equal numbers in given List<int> and returns the result as new 
     * List<int>. Write a program to test whether the method works correctly.*/
    class Ex04LongestSubsequenceOfEqualClass
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<int> list = new List<int>();
            while ((input = Console.ReadLine()) != string.Empty)
            {
                list.Add(int.Parse(input));
            }
            GetLongestEqualSubsequence(list).ForEach(item => Console.Write("{0} ", item));
        }
        /// <summary>
        /// Compares each element in the list with the previous. If they are both equal, adds the element to a temporary list
        /// if the temporary list gets longer than the final list it is copied to the final list
        /// </summary>
        /// <param name="list"></param>
        /// <returns>List with the elements of the longuest sequence</returns>
        static List<int> GetLongestEqualSubsequence(List<int> list)
        {
            List<int> tempList = new List<int>();
            List<int> finalList = new List<int>();
            int maxLength = 0;
            int currentLength = 0;

            for (int ii = 1; ii < list.Count(); ii++)
            {
                if (list[ii] == list[ii - 1])
                {
                    tempList.Add(list[ii]);
                    currentLength++;
                }
                else
                {
                    tempList.Clear();
                    tempList.Add(list[ii]);
                    currentLength = 0;
                }
                if (currentLength >= maxLength)
                {
                    maxLength = currentLength;
                    finalList = tempList.ToList();
                }
            }

            return finalList;
        }
    }
}
