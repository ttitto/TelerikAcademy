using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace ExtractSentencesWithWord
{/*08.Write a program that extracts from a given text all sentences containing given word.
		Example: The word is "in". The text is:
  * 
    We are living in a yellow submarine. We don't have anything else. 
    Inside the submarine is very tight. So we are drinking all the day. 
    We will move out of it in 5 days.

		The expected result is:
    We are living in a yellow submarine.
    We will move out of it in 5 days.

		Consider that the sentences are separated by "." and the words – by non-letter symbols.*/
    class ExtractSentencesWithWordClass
    {
        static void Main(string[] args)
        {
            //Input the text, working even if there is a new line symbol
            Console.WriteLine("Insert the text and use the following command one after the other:\n ENTER, ctrl+Z, ENTER ");
            byte[] inputBuffer = new byte[2048];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));
            string myText = Console.In.ReadToEnd();
            //searched substring input
            Console.Write("Insert the string to be looked for: ");
            string match = Console.ReadLine();
            //splits the text to sentences and lookes in each sentence for the substring with no word characters on both sides
            string[] sentences = myText.Split('.');
            Regex rgx = new Regex(@"\W" + match + @"\W", RegexOptions.IgnoreCase);
            foreach (var item in sentences)
            {
                if (rgx.IsMatch(item)) Console.WriteLine(item.Trim() + ".");
            }
        }
    }
}
