using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinToDec
{ /*Write a program to convert binary numbers to their decimal representation.*/
    /*The program calculates only for positive decimal numbers*/
    class BinToDecClass
    {  
        static void Main(string[] args)
        {
            Console.Write("Insert the binary number: ");
            string binNum = Console.ReadLine();
            binNum = new string(binNum.Reverse().ToArray());
            int pow = 1;
            long decNum=0;
            for (int i = 0; i < binNum.Length; i++)
            {
                decNum += int.Parse(binNum[i].ToString()) * pow;
                pow *= 2;
            }
            Console.WriteLine("The decimal representation is {0}",decNum);
        }
    }
}
