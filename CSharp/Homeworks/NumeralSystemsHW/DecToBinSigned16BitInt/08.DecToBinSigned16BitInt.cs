using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DecToBin;

namespace DecToBinSigned16BitInt
{/*Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).*/
    class DecToBinSigned16BitIntClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert decimal integer of type short: ");
            short N = short.Parse(Console.ReadLine());
            if (N < -32768 || N > 32767)
            {
                Console.WriteLine("Decimal number is bigger that a short can handle!");
                return;
            }

            if (N < 0)
            {
                Console.Write("Signed magnitude code: ");
                DecToBinClass.PrintArray(DecToBinClass.BinIntegralNegativeSignedMagnitude(N, 16));
                Console.Write("One's complement code: ");
                DecToBinClass.PrintArray(DecToBinClass.BinIntegralNegativeOneComplement(N, 16));
                Console.Write("Two's complement code: ");
                DecToBinClass.PrintArray(DecToBinClass.BinIntegralNegativeTwoComplement(N, 16));
            }
            else if (N>0)
            {
                DecToBinClass.PrintArray(DecToBinClass.BinIntegralPositive(N, 16));   
            }
            else Console.WriteLine("0000000000000000");

        }
    }
}
