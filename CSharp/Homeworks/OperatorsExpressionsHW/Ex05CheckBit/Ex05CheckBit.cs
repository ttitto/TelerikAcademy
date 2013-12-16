using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05CheckBit
{
    /*5. Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.*/
    class Ex05CheckBitClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert an integer: ");
            int myInt = int.Parse(Console.ReadLine());
            bool isOne = ((1 << 2) & myInt)>>2 == 1;
            Console.WriteLine("The third bit is 1: {0}",isOne);
        }
    }
}
