using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace RemoveWordsWithSpecificPrefix
{
    class RemoveWordsWithSpecificPrefixClass
    {/*Write a program that deletes from a text file all words that start with the 
      * prefix "test". Words contain only the symbols 0...9, a...z, A…Z, _.*/
        static void Main(string[] args)
        {
            string inputFile = @"..\..\InputFile.txt";
            string outputFile = @"..\..\OutputFile.txt";
            string backupFile = @"..\..\BackupFile.txt";
            Console.Write("Insert the prefix: ");
            string prefix = Console.ReadLine();
            try
            {
                using (StreamReader sr = new StreamReader(inputFile, Encoding.GetEncoding("UTF-8")))
                {
                    //if the output file exists, it will be deleted, so that we can use sw with append=true
                    if (File.Exists(outputFile)) File.Delete(outputFile);
                    using (StreamWriter sw = new StreamWriter(outputFile, true, Encoding.GetEncoding("UTF-8")))
                    {
                        for (string line; (line = sr.ReadLine()) != null; )
                        {
                            //With regular expression
                            //words that starts with prefix and afterthat contain only number, latin  and _
                            //will be replaced with empty string
                            //If we have prefix and other symbols, only the prefix will be replaced ex. test. will be .
                            sw.WriteLine(Regex.Replace(line, @"\b" + prefix + @"[0-9a-zA-Z_-_]*", "", RegexOptions.IgnoreCase), true);
                        }
                    }
                }
                //The output file will be replaced
                File.Replace(outputFile, inputFile, backupFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured during execution of your program: " + ex.Message);

            }
        }
    }
}
