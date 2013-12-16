using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Dictionary
{/*14.A dictionary is stored as a sequence of text lines containing words and their explanations. 
  Write a program that enters a word and translates it by using the dictionary. Sample dictionary:
    .NET – platform for applications from Microsoft
    CLR – managed execution environment for .NET
    namespace – hierarchical organization of classes
*/
    class DictionaryClass
    {
        static void Main(string[] args)
        {
            //The dictionary is in an extern txt-file. the key and the value are separated with " - "
            string dictPath = @"..\\..\\Dict.txt";
            //Declaring a Dictionary
            IDictionary<string, string> myDict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            //Filling the dicrionary with the definitions of the text file
            using (StreamReader sr = new StreamReader(dictPath, Encoding.GetEncoding("UTF-8")))
            {
                Regex key = new Regex(@".*(?=\s.{1}\s)",RegexOptions.IgnoreCase);
                Regex val = new Regex(@"(?<=\s.{1}\s).*", RegexOptions.IgnoreCase);
                string line = sr.ReadLine();
                while (line != null)
                {
                    myDict.Add(key.Match(line).ToString(), val.Match(line).ToString());
                    line = sr.ReadLine();
                }
            }
            string myval;
            Console.Write("Insert the word to be translated: ");
            myDict.TryGetValue(Console.ReadLine(),out myval);
            Console.WriteLine(" - {0}",myval);
        }
    }
}
