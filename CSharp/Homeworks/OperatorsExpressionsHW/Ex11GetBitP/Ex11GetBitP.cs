using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex11GetBitP
{
    /*11. Write an expression that extracts from a given integer i the value of a given bit number b.
     * Example: i=5; b=2  value=1.*/
    class Ex11GetBitPClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert an integer: ");
            int v = int.Parse(Console.ReadLine());
            Console.Write("Insert the bit's position: ");
            int p = int.Parse(Console.ReadLine());
            byte bit = (byte)(((1 << p) & v) >> p);
            Console.WriteLine(bit);
        }
    }
}
