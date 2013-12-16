using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Text.RegularExpressions;

namespace HexadecToDec
{
    class HexadecToDecClass
    {
        static char[] HexAlfabet = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        static void Main(string[] args)
        {
            Console.WriteLine("Insert the hexadecimal number without prefix: ");
            string strHexNum = Console.ReadLine().ToUpper();
            if (!IsValidHex(strHexNum))
            {
                Console.WriteLine("The inserted string is not any Hexadecimal number representation.");
                return;
            }
            char[] hexNum = strHexNum.ToCharArray();
            //int length=strHexNum.Length;
            Array.Reverse(hexNum);
            BigInteger decNum=0;
            BigInteger pow = 1;
            for (int digit = 0; digit < hexNum.Length; digit++)
            {
                decNum += Array.BinarySearch(HexAlfabet, hexNum[digit]) * pow;
                pow *= 16;
            }
            Console.WriteLine(decNum);
        }
        public static bool IsValidHex(string input)
        {
            Regex regex = new Regex(@"^[A-Fa-f0-9]*$");
            return regex.IsMatch(input);
          
        }
    }
}
