using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Globalization;

namespace DecToHexadec
{/*Write a program to convert decimal numbers to their hexadecimal representation.*/

    /*converting negative integer to hex
     You are wanting to do a VERY tricky thing there. The first thing you would do is do the hex division to get
     * the decimal magnitude (48) into hex. Then invert all the bits and make all 1's 0 and 0's 1. This is the same
     * as subtracting each number in hex from F (not inverting the bits). The final step is to add 1 to the new number.
     * So, for -48, you would have a magnitude of 48, which would be 30 in Hex. Next, subtract 30H from FFFFH (because it is a Word)
     * and you get FFCF. Finally add 1 and you get FFD0. Remember if it is more than a word, say a double word, you subtract your result
     * from the word equivalent (Double Word=FFFFFFFFH) (Quad Word=FFFFFFFFFFFFFFFFH) If you want to make sure its right, add your initial
     * Hex value to your final result. You should get 0 with a 1 carryout. Good luck and let me know if you need anything else. Aaron*/
    class DecToHexadecClass
    {
        static char[] HexAlfabet = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        static void Main(string[] args)
        {

            Console.Write("Insert the decimal number: ");
            BigInteger decNum = BigInteger.Parse(Console.ReadLine().ToUpper());
            //Simple resolution
            //string hexNum=Convert.ToString(int.Parse(decNum.toString()), 16).ToUpper();
            //Console.WriteLine(hexNum);
            if (decNum > 0) DecPosIntToHex(decNum);
            if (decNum <= 0) DecNegIntToHex(decNum);
            

        }
        //positive integral conversion
        public static void DecPosIntToHex(BigInteger decNum)
        {
            StringBuilder sb = new StringBuilder();

            while (decNum > 0)
            {
                sb.Append(HexAlfabet[int.Parse((decNum % 16).ToString())]);
                decNum /= 16;
            }
            sb.Append("x0");
            Console.WriteLine(sb.ToString().Reverse().ToArray());
        }
        //negative integral conversion
        public static void DecNegIntToHex(BigInteger decNum)
        {
            StringBuilder sb = new StringBuilder();
            decNum = -decNum;
            //Determine how many words will be enough for this number
            BigInteger wordRange = 65536;
            for (BigInteger i = 65536; i < decNum; i *= 65536)
            {
                wordRange = i * 65536;
            }
            BigInteger a = wordRange - decNum ;
            DecPosIntToHex(a);
        }
    }
}
