using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AnyNumericSystemConversion
{/*Write a program to convert from any numeral system of given base s to any other numeral system
  * of base d (2 ≤ s, d ≤  16).*/
    class AnyNumericSystemConversionClass
    {
        static char[] HexAlfabet = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        static void Main(string[] args)
        {
            //Input
            Console.Write("Insert S: ");
            byte s = byte.Parse(Console.ReadLine());
            Console.Write("Insert D: ");
            byte d = byte.Parse(Console.ReadLine());
            Console.Write("Insert the number in {0} numeral system: ", s);
            string sNum = Console.ReadLine().ToUpper();
            //check if the input contains only character for the choosen numeral system
            if (!IsValid(s,sNum))
            {
                Console.WriteLine("The input is invalid!");
                return;
            }
            //calls the two methods to convert the input to decimal biginteger and then to convert
            //it to a number in d base
            Console.WriteLine("The number in {0} numeral system is: {1}", d, DecToD(SToDec(sNum.ToCharArray(), s), d));
        }
        /*takes the inserted number as char array, reverses it,
         then multiplies the value of the char corresponding to the position of the char in HexAlfabet to the 
         * s base^(position in number)
         after summing the results for all characters in sNum it returns a biginteger number in decimal numeral system*/
        private static BigInteger SToDec(char[] SNum, byte Sbase)
        {
            Array.Reverse(SNum);
            BigInteger decNum = 0;
            BigInteger multiplier = 1;
            for (int i = 0; i < SNum.Length; i++)
            {
                decNum += Array.IndexOf(HexAlfabet, SNum[i]) * multiplier;
                multiplier *= Sbase;
            }
            return decNum;
        }
        /*Convert a decimal biginteger to a number in d-based numeral system
         the mod is used as a position index to take the char from Hexalfabet
         then the chars are appended by a stringbuilder dNum
         the string is reversed and returned*/
        private static string DecToD(BigInteger decNum, byte DBase)
        {
            StringBuilder dNum = new StringBuilder();
            while (decNum > 0)
            {
                dNum.Append(HexAlfabet[int.Parse((decNum % DBase).ToString())].ToString());
                decNum /= DBase;
            }
            string strDNum = dNum.ToString();
            strDNum = new string(strDNum.Reverse().ToArray());
            return strDNum;
        }
        //defines regular expression masks for the cases where only numbers 0-9 are used
        //and when letter A to... must be used depending on the choosen d base of the numeral system
        private static bool IsValid(byte s, string input)
        {
            Regex regex;
            if (s < 11)
            {
                regex = new Regex(@"^[0-" + HexAlfabet[s].ToString() + @"]*$");
                return regex.IsMatch(input);
            }
            else if (s <= 16)
            {
                regex = new Regex(@"^[A-" + HexAlfabet[s].ToString() + @"0-9]*$");
                return regex.IsMatch(input);
            }
            return false;
        }
    }
}
