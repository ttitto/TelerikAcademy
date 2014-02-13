using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringBuilderSubstring
{
    /*1. Implement an extension method Substring(int index, int length) for the class StringBuilder
     * that returns new StringBuilder and has the same functionality as Substring in the class String.*/
    public static class StringBuilderSubstringClass
    {
        /// <summary>
        /// Returns the substring of the current string, contained in a StringBuilder by given starting position and a required length.
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="index">the starting position in the string</param>
        /// <param name="length">the count of the returned characters</param>
        /// <returns>Stringbuilder</returns>
        static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {
            if (index < 0 || length < 0 || length + index > sb.Length)
                throw new IndexOutOfRangeException("Invalid values for index or length!");
            StringBuilder mySB = new StringBuilder();
            for (int i = index; i < index + length; i++)
            {
                mySB.Append(sb[i]);
            }
            return mySB;
        }

        static void Main(string[] args)
        {
            StringBuilder myStringBuilder = new StringBuilder("MyTest StringBuilder Substring Extension Method");
            Console.WriteLine(myStringBuilder.Substring(7, 23).ToString());
            Console.WriteLine(myStringBuilder.Substring(31, 16).ToString());
        }
    }
}
