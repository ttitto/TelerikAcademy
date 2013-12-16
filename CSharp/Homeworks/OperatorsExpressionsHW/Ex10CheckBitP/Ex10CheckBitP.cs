
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex10CheckBitP
{
    /*10. Write a boolean expression that returns if the bit at position p (counting from 0)
     * in a given integer number v has value of 1. Example: v=5; p=1  false.*/
    class Ex10CheckBitPClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert an integer: ");
            int v = int.Parse(Console.ReadLine());
            Console.Write("Insert the bit's position: ");
            int p = int.Parse(Console.ReadLine());
            bool isOne = ((1 << p) & v) >> p == 1;
            Console.WriteLine("the bit is 1: {0}",isOne);

        }
    }
}
