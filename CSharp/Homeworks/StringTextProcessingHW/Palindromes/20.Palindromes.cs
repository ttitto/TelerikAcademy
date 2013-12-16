using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Palindromes
{/*20.Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".*/
    class PalindromesClass
    {
        static void Main(string[] args)
        {
            //Insert a text that can be multiline
            Console.WriteLine("Insert text and push ENTER, ctrl+Z,ENTER");
            byte[] inputBuffer = new byte[2048];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));
            string myText = Console.In.ReadToEnd();
            //Declare regular expression to match palindromes format. Works only with whole words palindromes
            //the palindrome wouldn't be recognized: "A man, a plan, a canal, Panama"
            Regex palindrome = new Regex(@"\b\w*\b", RegexOptions.IgnoreCase);
            MatchCollection matches = palindrome.Matches(myText);
            //Checks if the match is palindrome and prints it on the console
            foreach (var item in matches)
            {
                string match = item.ToString();
                string reversed = new string(match.Reverse().ToArray());
                if (match==reversed && match.Count()>1)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }
}
