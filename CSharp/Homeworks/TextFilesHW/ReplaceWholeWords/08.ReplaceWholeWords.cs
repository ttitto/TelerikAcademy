using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace ReplaceWholeWords
{/*Modify the solution of the previous problem to replace only whole words (not substrings).*/
    class ReplaceWholeWordsClass
    {
        static void Main(string[] args)
        {

            /*-To avoid problems with workstation memory
                     we will read line per line the txt-file
              -used is the Replace method of a string instance
              -first the changed text will be written in a new file 
             -Files can be replaced with File.Replace() method if needed to replace the text in the same file*/
            string line = String.Empty;
            string inputFile = @"..\..\InputFile.txt";
            string outputFile = @"..\..\OutputFile.txt";
            //The user can input the strings he would like to change
            Console.WriteLine("Insert the substring that must be replaced: ");
            string replaced = Console.ReadLine().ToLower();
            Console.WriteLine("Insert the substring that will be added: ");
            string replacing = Console.ReadLine().ToLower();
            StreamReader sr;
            StreamWriter sw;
            try
            {
                sr = new StreamReader(inputFile, Encoding.GetEncoding("UTF-8"));
                //the output file will be deleted, if it already exists
                if (File.Exists(outputFile))
                {
                    File.Delete(outputFile);
                }
                sw = new StreamWriter(outputFile, true, Encoding.GetEncoding("UTF-8"));
                using (sr)
                {
                    using (sw)
                    {
                        line = sr.ReadLine().ToLower();
                        while (line != null)
                        {
                            //replacing the strings and writing the result in a new txt-file

                            sw.WriteLine(Regex.Replace(line,@"\b" + replaced + @"\b", replacing));
                            line = sr.ReadLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured while replacing. " + ex.Message);
            }

        }
    }
}
