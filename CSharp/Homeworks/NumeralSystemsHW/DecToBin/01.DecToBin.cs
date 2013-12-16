using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DecToBin
{
    /*Write a program to convert decimal numbers to their binary representation.*/
    //http://www.codeproject.com/Questions/484209/Convertplusfloatplustoplusbinary
    //http://en.wikipedia.org/wiki/IEEE_floating_point
    //http://forums.academy.telerik.com/26719
    //http://www.tfinley.net/notes/cps104/floating.html
    //http://www.alonintheworld.com/2012/01/word-about-floating-point-numbers-2.html

    public class DecToBinClass
    {
        static int typeSize = 0;
        static void Main(string[] args)
        {
            Console.Write("Insert the DEC number: ");
            dynamic N = Console.ReadLine();
            string strN = N.ToString();
            if (N[0] == '-')
            {
                Console.WriteLine(@"Insert one of the following numeric types: 
System.SByte, System.Int16, System.Int32, System.Int64
System.Single,System.Double, System.Decimal");
            }
            else
            {
                Console.WriteLine(@"Insert one of the following numeric types: 
System.Byte,System.UInt16,System.UInt32,System.UInt64,
System.Single,System.Double, System.Decimal");
            }

            if (CanBeNumeric(N)) N = Convert.ChangeType(N, SetType());
            else Console.WriteLine("Input can not be converted to a number!");

            if (strN.Contains('.') == false)//the input is integral number
            {

                byte[] binNum = new byte[typeSize];
                if (N > 0)
                {
                    Console.Write("The representation of {1} {0} in the memory is: ", N, N.GetType());
                    PrintArray(BinIntegralPositive(N, typeSize));
                }
                else if (N < 0)
                {

                    Console.WriteLine("The signed magnitude representation of  {1} {0} in the memory is: ", N, N.GetType());
                    PrintArray(BinIntegralNegativeSignedMagnitude(N, typeSize));
                    Console.WriteLine("The One's complement representation of  {1} {0} in the memory is: ", N, N.GetType());
                    PrintArray(BinIntegralNegativeOneComplement(N, typeSize));
                    Console.WriteLine("The Two's complement representation of  {1} {0} in the memory is: ", N, N.GetType());
                    PrintArray(BinIntegralNegativeTwoComplement(N, typeSize));
                }
                else if (N == 0)
                {

                    Console.Write("The representation of {0} in the memory is: ", N);
                    PrintArray(binNum);
                }
            }
            else//the input contains a decimal point
            {
                if (typeSize == 32)
                {
                    PrintArray(BinFloat(N, typeSize));
                }
            }

            Console.ReadLine();
        }

        //This method checks if the inserted string can be converted to a number
        public static bool CanBeNumeric(string input)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(input);
        }
        /*This method takes the user input for the type of the number and assigns
          to a variable the count of the bits for this type*/
        public static Type SetType()
        {
            Type choosenType = Type.GetType(Console.ReadLine());

            switch (choosenType.ToString())
            {
                case "System.SByte":
                case "System.Byte": typeSize = 8; break;
                case "System.Int16":
                case "System.UInt16": typeSize = 16; break;
                case "System.Single":
                case "System.Int32":
                case "System.UInt32": typeSize = 32; break;
                case "System.Double":
                case "System.Int64":
                case "System.UInt64": typeSize = 64; break;
                case "System.Decimal": typeSize = 128; break;

                default: Console.WriteLine("Type is not recognized!");
                    break;
            }

            return choosenType;
        }
        //This method print the elements of an array as string using Stringbuilder
        public static void PrintArray(byte[] binNum)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in binNum)
            {
                sb.Append(item);
            }
            Console.WriteLine(sb.ToString());
        }
        /*this method returns an array with the bits of a positive integral number
         * as they are represented in the computer memory*/
        public static byte[] BinIntegralPositive(dynamic decNum, int arrSize)
        {
            byte[] binNum = new byte[arrSize];
            int i = 1;
            while (decNum > 0)
            {
                binNum[arrSize - i] = (byte)(decNum % 2);
                decNum = decNum / 2;
                i++;
            }

            return binNum;
        }
        /*This method returns an array with the bits of a negative integral number
         as it would be represented in the memory in signed magnitude code*/
        public static byte[] BinIntegralNegativeSignedMagnitude(dynamic decNum, int arrSize)
        {
            byte[] binNum = new byte[arrSize];
            decNum = -decNum;
            int i = 1;
            while (decNum > 0)
            {
                binNum[arrSize - i] = (byte)(decNum % 2);
                decNum = decNum / 2;
                i++;
            }
            binNum[0] = 1;

            return binNum;
        }
        /*This method returns an array with the bits of a negative integral number
         as it would be represented in the memory in One's complement code*/
        public static byte[] BinIntegralNegativeOneComplement(dynamic decNum, int arrSize)
        {
            byte[] binNum = new byte[arrSize];
            decNum = -decNum;
            int i = 1;
            while (decNum > 0)
            {
                binNum[arrSize - i] = (byte)(decNum % 2);
                decNum = decNum / 2;
                i++;
            }
            for (int a = 0; a < arrSize; a++)
            {
                if (binNum[a] == 0)
                {
                    binNum[a] = 1;
                }
                else binNum[a] = 0;
            }

            return binNum;
        }
        /*This method returns an array with the bits of a negative integral number
         as it would be represented in the memory in Two's complement code*/
        public static byte[] BinIntegralNegativeTwoComplement(dynamic decNum, int arrSize)
        {
            byte[] binNum = new byte[arrSize];
            decNum = (-decNum) - 1;
            int i = 1;
            while (decNum > 0)
            {
                binNum[arrSize - i] = (byte)(decNum % 2);
                decNum = decNum / 2;
                i++;
            }
            for (int a = 0; a < arrSize; a++)
            {
                if (binNum[a] == 0)
                {
                    binNum[a] = 1;
                }
                else binNum[a] = 0;
            }

            return binNum;
        }
        /*This method returns an array with the bits of a floating point number*/
        public static byte[] BinFloat(dynamic decNum, int arrSize)
        {
            byte[] binNum = new byte[arrSize];
            //if the float is negative, the most significant bit is 1
            if (decNum < 0)
            {
                decNum = -decNum;
                binNum[0] = 1;
            }
            //find the exponent part in a binary exponential representation
            byte[] leftPart = BinIntegralPositive((short)decNum, 128);
            int firstOne = Array.IndexOf(leftPart, (byte)1);
            Array.Copy(BinIntegralPositive(254 - firstOne, 8), 0, binNum, 1, 8);
            //find the mantissa
            Array.Copy(leftPart, (firstOne + 1), binNum, 9, (127 - firstOne));
            float rightPart = decNum - (int)decNum;
            List<byte> rightBinPart = new List<byte>();
            while (rightPart > 0)
            {
                rightBinPart.Add((byte)(rightPart * 2));
                rightPart *= 2;
                if ((byte)rightPart==1)
                {
                    rightPart -= 1;
                }
            }
            Array.Copy(rightBinPart.ToArray(), 0, binNum, (9 + 127 - firstOne), rightBinPart.Count);
            return binNum;
        }

    }
}
