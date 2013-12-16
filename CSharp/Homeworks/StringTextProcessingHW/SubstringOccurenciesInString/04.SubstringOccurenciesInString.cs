using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace SubstringOccurenciesInString
{/*04.Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
		Example: The target substring is "in". The text is as follows:
   " We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days."
  The result is: 9.
*/
    class SubstringOccurenciesInStringClass
    {
        static void Main(string[] args)
        {
            string sub = string.Empty;
            string str = string.Empty;
         
            Console.WriteLine("Insert the text:");
            //StringBuilder sb = new StringBuilder();
            //char chr;
            //while (true )
            //{chr=(char)Console.Read();
            //if (chr == ' ')
            //{
            //    break;
            //}
            //else if(chr!='\n')
            //{
            //    sb.Append(chr.ToString());
            //}
            //}
            //str = sb.ToString();
            str = Console.ReadLine();//TO DO-If the text contains a symbol for new line, the text must be inserted correctly
            Console.Write("Insert the substring: ");
            sub = Console.ReadLine().ToLower();

            Regex regex = new Regex(@""+sub+@"",RegexOptions.IgnoreCase);
            MatchCollection subMatches = regex.Matches(str);
            Console.WriteLine("The result is: {0}",subMatches.Count);
        }
    }
}
