using System;
using System.Text.RegularExpressions;
using System.IO;
namespace ExtractEmail
{/*18.Write a program for extracting all email addresses from given text. 
  * All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.*/
    class ExtractEmailClass
    {
        static void Main(string[] args)
        {
            //Insert a text that can be multiline
            Console.WriteLine("Insert text and push ENTER, ctrl+Z,ENTER");
            byte[] inputBuffer = new byte[2048];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream,Console.InputEncoding,false,inputBuffer.Length));
            string myText = Console.In.ReadToEnd();
            //Declare regular expression to match email format
            Regex email = new Regex(@"\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b", RegexOptions.IgnoreCase);
            //Print on the console all matches
            MatchCollection matches = email.Matches(myText);
            foreach (var item in matches)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
}
