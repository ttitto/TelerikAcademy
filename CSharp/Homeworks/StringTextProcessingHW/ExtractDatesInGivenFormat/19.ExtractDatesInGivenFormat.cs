using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace ExtractDatesInGivenFormat
{/*19.Write a program that extracts from a given text all
  * dates that match the format DD.MM.YYYY. Display them in the standard date format for Canada.*/
    class ExtractDatesInGivenFormatClass
    {
        static void Main(string[] args)
        {
            //Insert a text that can be multiline
            Console.WriteLine("Insert text and push ENTER, ctrl+Z,ENTER");
            byte[] inputBuffer = new byte[2048];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));
            string myText = Console.In.ReadToEnd();
            //Declare regular expression to match email format
            Regex dates = new Regex(@"\b[0-9]{2}\.[0-9]{2}\.[\d]{4}\b", RegexOptions.IgnoreCase);
            //Print on the console all matches
            MatchCollection matches = dates.Matches(myText);
            foreach (var item in matches)
            {
               Console.WriteLine( DateTime.ParseExact(item.ToString(), "dd.MM.yyyy", CultureInfo.GetCultureInfo("bg-BG")).ToString("D",CultureInfo.GetCultureInfo("fr-CA")));
            }
        }
    }
}
