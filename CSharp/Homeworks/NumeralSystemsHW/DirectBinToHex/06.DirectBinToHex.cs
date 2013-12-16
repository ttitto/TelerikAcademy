using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DirectBinToHex
{/*Write a program to convert binary numbers to hexadecimal numbers (directly).*/
    class DirectBinToHexClass
    {
        static void Main(string[] args)
        {
            char[] HexAlfabet = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            string[] binArr ={"0000","0001","0010","0011","0100","0101","0110","0111",
                               "1000","1001","1010","1011","1100","1101","1110","1111",};
            Console.Write("Insert the binary represented number: ");

            string binNum = Console.ReadLine();
            //Fill with zeros if not %4==0
            while (binNum.Length%4!=0)
            {
                binNum = 0 + binNum;
            }
            StringBuilder sb=new StringBuilder();
            //Finds the index of the match of each substring of 4 chars in the array with binary representarions
            //and appends the element on the same position from the Hexadecimal alfabet
            for (int start = 0; start < binNum.Length; start+=4)
			{
                sb.Append(HexAlfabet[Array.IndexOf(binArr, binNum.Substring(start, 4))]);
			}
            Console.WriteLine(sb.ToString());
            
        }
    }
}
