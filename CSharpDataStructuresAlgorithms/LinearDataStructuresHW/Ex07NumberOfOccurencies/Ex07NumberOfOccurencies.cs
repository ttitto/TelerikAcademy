using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex07NumberOfOccurencies
{
    /*07. Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of 
     * them occurs.
Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
2  2 times
3  4 times
4  3 times
*/
    class Ex07NumberOfOccurenciesClass
    {
        static void Main(string[] args)
        {
            string input;
            List<int> numbers = new List<int>();
            int[] occurencies = new int[1001];
            while ((input = Console.ReadLine()) != string.Empty)
            {
                numbers.Add(int.Parse(input));
            }

            for (int ii = 0; ii < numbers.Count(); ii++)
            {
                occurencies[numbers[ii]]++;
            }

            for (int j = 0; j < occurencies.Count(); j++)
            {
                if (occurencies[j] != 0)
                {
                    Console.WriteLine("{0} -> {1} times", j, occurencies[j]);
                }
            }
        }
    }
}
