using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DecToBin;

namespace DecToBinFloat
{/** Write a program that shows the internal binary representation of given 32-bit 
  * signed floating-point number in IEEE 754 format (the C# type float). 
  * Example: -27,25  sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.*/
    class DecToBinFloatClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert the floating point decimal number: ");
            float N = float.Parse(Console.ReadLine());
            if (N==00)
            {
                Console.WriteLine("Sign: {0}, Exponent: {1}, Mantissa: {2}", "0", "00000000", "00000000000000000000000");
                return;
            }
            byte[] BinFloatArr = new byte[32];
            DecToBinClass.BinFloat(N, 32).CopyTo(BinFloatArr, 0);
            StringBuilder sb = new StringBuilder();
            foreach (var item in BinFloatArr)
            {
                sb.Append(item);
            }

            Console.WriteLine("Sign: {0}, Exponent: {1}, Mantissa: {2}", sb.ToString().Substring(0, 1), sb.ToString().Substring(1, 8), sb.ToString().Substring(9, 23));
        }
    }
}
