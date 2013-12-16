using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DeleteOddLines
{/*Write a program that deletes from given text file all odd lines.
  * The result should be in the same file.*/
    class DeleteOddLinesClass
    {
        /*The program reads all line and writes each even line to a new file
         Then the new file replaces the original input file
         A backup copy of the original input file is saved*/
        static void Main(string[] args)
        {
            string inputFile = @"..\..\InputFile.txt";
            string outputFile= @"..\..\OutputFile.txt";
            string backupFile= @"..\..\BackupFile.txt";
            StreamReader sr;
            StreamWriter sw;
            try
            {

                sr = new StreamReader(inputFile);
                using (sr)
                {
                   sw = new StreamWriter(outputFile, false);
                   using (sw)
                   {
                       for (string line; (line = sr.ReadLine()) != null; )
                       {
                           sw.WriteLine(sr.ReadLine());
                       }
                   }
                }
                File.Replace(outputFile, inputFile, backupFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured during operation. "+ex.Message);
            }
        }
    }
}
