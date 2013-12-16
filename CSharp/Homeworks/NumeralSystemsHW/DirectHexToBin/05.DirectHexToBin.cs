using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DirectHexToBin
{/*Write a program to convert hexadecimal numbers to binary numbers (directly).*/
    class DirectHexToBinClass
    {
        static void Main(string[] args)
        {
            char[] HexAlfabet = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            string[] binArr ={"0000","0001","0010","0011","0100","0101","0110","0111",
                               "1000","1001","1010","1011","1100","1101","1110","1111",};

            Console.Write("Insert the HEX number without prefixes: ");
            string hexNum = Console.ReadLine().ToUpper();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hexNum.Length; i++)
            {
                int indx = Array.BinarySearch(HexAlfabet, hexNum[i]);
                sb.Append(binArr[indx]);
            }
            Console.WriteLine("The binary representation of the number is {0} .", sb.ToString());
        }
    }
}
