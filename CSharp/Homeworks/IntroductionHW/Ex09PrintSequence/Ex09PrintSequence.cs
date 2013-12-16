using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex09PrintSequence
{
    /*Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...*/
    class Ex09PrintSequenceClass
    {
        static void Main(string[] args)
        {
            for (int i = 2; i < 12; i++)
            {
                //if i is even number
                if (i % 2 == 0) Console.Write("{0} ", i);
                else Console.Write("-{0} ", i);
            }
            //move cursor to the next row
            Console.WriteLine();
        }
    }
}
