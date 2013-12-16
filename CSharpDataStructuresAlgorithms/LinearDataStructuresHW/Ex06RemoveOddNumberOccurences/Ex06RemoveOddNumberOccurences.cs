using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex06RemoveOddNumberOccurences
{
    /*06. Write a program that removes from given sequence all numbers that occur odd number of times.
     * Example: {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5}*/
    class Ex06RemoveOddNumberOccurencesClass
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<string> list = new List<string>();

            while ((input = Console.ReadLine()) != string.Empty)
            {
                list.Add(input);
            }

            Dictionary<string, int> pairs = new Dictionary<string, int>();
            for (int i = 0; i < list.Count(); i++)
            {
                //if element is in the dictionary, increase occurence
                if (pairs.ContainsKey(list[i]))
                {
                    pairs[list[i]]++;
                }
                //else add element to the dictionary with occurence=1
                else
                {
                    pairs.Add(list[i], 1);
                }
            }
            var oddOccurencies = pairs.Where(kv => (kv.Value % 2) == 1).Select(kv => kv.Key);

            foreach (var item in list)
            {
                if (!oddOccurencies.Contains(item))
                {
                    Console.Write("{0} ", item);
                }
            }
        }
    }
}
