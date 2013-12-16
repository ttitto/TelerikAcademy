using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlyOneFromConsecutiveLetters
{/*23.Write a program that reads a string from the console and replaces all series of consecutive
  * identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".*/
    class OnlyOneFromConsecutiveLettersClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert a string: ");
            string myStr = Console.ReadLine();

            for (int i = 0; i < myStr.Length; i++)
            {
                if (!char.IsLetter(myStr[i])) continue;
                else
                {
                    if (i > 0)
                    {
                        if (myStr[i] != myStr[i - 1])
                        {
                            Console.Write(myStr[i]);
                            continue;
                        }
                    }
                    else Console.Write(myStr[i]);
                }
            }
            Console.WriteLine();
        }
    }
}
