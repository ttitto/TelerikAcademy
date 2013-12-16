using System;
using System.IO;
using System.Linq;

namespace ForbiddenWords
{/*09.We are given a string containing a list of forbidden words and a text containing
  * some of these words. Write a program that replaces the forbidden words with asterisks. Example:

	Microsoft announced its next generation PHP compiler today. It is based on .NET
    Framework 4.0 and is implemented as a dynamic language in CLR.

		Words: "PHP, CLR, Microsoft"
		The expected result:
  ********* announced its next generation *** compiler today. It is based on .NET
  *Framework 4.0 and is implemented as a dynamic language in ***.
*/
    class ForbiddenWordsClass
    {
        static void Main(string[] args)
        {
            //Text input, text can contain new line symbol
            Console.WriteLine("Insert the text. \nUse ENTER, ctrl+Z, ENTER to confirm that input finished!");
            byte[] inputBuffer = new byte[2048];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));
            string myText = Console.In.ReadToEnd();
            //input the list of forbidden words
            Console.WriteLine("Insert the list of forbidden words, separated by ',' ");
            string forbiddenList = Console.ReadLine();
            string[] forbStrings = forbiddenList.Split(',');
            foreach (var item in forbStrings)
            {
                myText = new string(myText.Replace(item, String.Empty.PadRight(item.Length, '*')).ToString().ToArray());
            }
            Console.WriteLine(myText);
        }
    }
}
