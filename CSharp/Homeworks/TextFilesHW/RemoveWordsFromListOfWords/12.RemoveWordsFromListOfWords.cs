using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace RemoveWordsFromListOfWords
{/*Write a program that removes from a text file all words listed in given
  * another text file. Handle all possible exceptions in your methods.*/
   public class RemoveWordsFromListOfWordsClass
    {
        static void Main(string[] args)
        {
            string inputFile = @"..\..\InputFile.txt";
            string outputFile = @"..\..\OutputFile.txt";
            string backupFile = @"..\..\BackupFile.txt";
            string listFile = @"..\..\ListFile.txt";
            RemoveOutput(outputFile);
            try
            {
                using (StreamReader sr = new StreamReader(inputFile))
                {
                    using (StreamWriter sw = new StreamWriter(outputFile, true))
                    {
                        for (string line; (line = sr.ReadLine()) != null; )
                        {
                            List<string> targetWords = TakeWords(listFile);
                            for (int wordsInList = 0; wordsInList < targetWords.Count(); wordsInList++)
                            {
                                line = CorrectedLine(line, targetWords[wordsInList]);
                            }
                            sw.WriteLine(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occured in the Main method. "+ex.Message);
            }
            ReplaceFiles(outputFile, inputFile, backupFile);

        }
        //removes the output file, if it exists
      public  static void RemoveOutput(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occured during file manipulation. " + ex.Message);
            }
        }
        //removes the found word in the read line if matches a reg. expression and returns the changed string
        static string CorrectedLine(string targetText, string targetWord)
        {
            try
            {
                string corrLine;
                corrLine = Regex.Replace(targetText, @"\b" + targetWord + @"\b", "", RegexOptions.IgnoreCase);
                return corrLine;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occured during word removing. Check your list of words file! "+ex.Message);
            }
            return null;
        }
        //Generates a backup copy of the starting file and replaces it with the changed one
        static void ReplaceFiles(string sourcePath, string destPath, string backupPath)
        {
            try
            {
                File.Replace(sourcePath, destPath, backupPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occured while trying to replace files! "+ex.Message);
            }
        }
        //reads the list of words from a file and fills a List of strings
      public  static List<string> TakeWords(string listFile)
        {
            try
            {
                List<string> words = new List<string>();
                using (StreamReader sr = new StreamReader(listFile))
                {
                    for (string line; (line = sr.ReadLine()) != null; ) words.Add(line);
                }
                return words;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occured while trying to read from the ListFile.txt. "+ex.Message);
            }
            return null;
        }
    }
}
