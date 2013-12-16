using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12SetBitP
{
    /*12. We are given integer number n, value v (v=0 or 1) and a position p. Write a sequence of operators 
     * that modifies n to hold the value v at the position p from the binary representation of n.
	Example: n = 5 (00000101), p=3, v=1  13 (00001101)
	n = 5 (00000101), p=2, v=0  1 (00000001)*/
    class Ex12SetBitPClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert an integer: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Insert the bit's position: ");
            int p = int.Parse(Console.ReadLine());
            Console.Write("Insert the new value for the bit (1 or 0): ");
            byte v = byte.Parse(Console.ReadLine());
            if (v == 1) n = (1 << p) | n;
            else if ((v == 0)) n = ~(1 << p) & n;
            else Console.WriteLine("Bit can be 1 or 0 only!");
            Console.WriteLine("New value: {0}", n);
        }
    }
}
