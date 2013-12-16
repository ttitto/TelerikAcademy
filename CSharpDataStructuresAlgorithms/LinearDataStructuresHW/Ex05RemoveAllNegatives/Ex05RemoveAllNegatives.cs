using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05RemoveAllNegatives
{
    /*05. Write a program that removes from given sequence all negative numbers.*/
    class Ex05RemoveAllNegativesClass
    {
        static void Main(string[] args)
        {
            string input;
            LinkedList<int> linked = new LinkedList<int>();
            while ((input = Console.ReadLine()) != string.Empty)
            {
                linked.AddLast(int.Parse(input));
            }

            var result = linked.Where(item => item >= 0).Select(item => item);

            //Print on the console
            foreach (var item in result)
            {
                Console.Write("{0} ", item);
            }
        }
    }
}
