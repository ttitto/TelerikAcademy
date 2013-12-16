using System;

namespace StringToUnicodeLitterals
{/*10.Write a program that converts a string to a sequence of C# Unicode character 
  * literals. Use format strings. Sample input:
    Hi!
		Expected output:
    \u0048\u0069\u0021
*/
    class StringToUnicodeLitteralsClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert the string: ");
            string myStr = Console.ReadLine();
            for (int i = 0; i < myStr.Length; i++)
            {
                Console.Write("\\u{0:X4}", (int)(myStr[i]));
            }
            Console.WriteLine();
        }
    }
}
