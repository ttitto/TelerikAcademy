using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex14MultipleBitExchange
{
    /**14.  Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.*/


    class Ex14MultipleBitExchangeClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert a positive integer: ");
            uint n = uint.Parse(Console.ReadLine());
            Console.Write("Insert the number of bits to be exchanged");
            int k = int.Parse(Console.ReadLine());
            Console.Write("Insert the first start position: ");
            int i = int.Parse(Console.ReadLine());
            Console.Write("Insert the second start position: ");
            int j = int.Parse(Console.ReadLine());

            //loops through the bit that must be changed an takes their value
            //then calls a method SetBit with the number passed by reference, the position of the bit tobe changed, 
            //and the new value of the bit
            for (int ii = i, jj = j; ii < k+i; ii++, jj++)
            {
                int first = (int)((1 << ii) & n) >> ii;
                int second = (int)((1 << jj) & n) >> jj;
                SetBit(ref n, ii, second);
                SetBit(ref n, jj, first);
            }
            Console.WriteLine(n);
        }
        /// <summary>
        /// Changes the bit at given position depending on the value it must take
        /// </summary>
        /// <param name="number">the number after the last bit change</param>
        /// <param name="pos">position of the bit to be changed</param>
        /// <param name="bit">the new value that the bit at position pos should take</param>
        public static void SetBit(ref uint number, int pos, int bit)
        {
            int mask = (1 << pos);
            if (bit == 1) number = (uint)mask | number;
            else if (bit == 0) number = (uint)(~mask & number);
        }
    }
}
