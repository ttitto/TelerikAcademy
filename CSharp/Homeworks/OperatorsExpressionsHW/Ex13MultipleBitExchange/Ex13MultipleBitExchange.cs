using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex14MultipleBitExchange
{
    /*13. Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.*/
    class Ex13MultipleBitExchangeClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert a positive integer: ");
            uint n = uint.Parse(Console.ReadLine());
            //loops through the bit that must be changed an takes their value
            //then calls a method SetBit with the number passed by reference, the position of the bit tobe changed, 
            //and the new value of the bit
            for (int ii = 3, jj = 24; ii < 6; ii++, jj++)
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
