using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03SortedIntSequence
{
    /*03. Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an 
     * increasing order.*/
    class Ex03SortedIntSequenceClass
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<int> list = new List<int>();
            while ((input = Console.ReadLine()) != string.Empty)
            {
                list.Add(int.Parse(input));
            }
            list.Sort();
            list.ForEach(item => Console.Write("{0} ", item));
        }
    }
}
