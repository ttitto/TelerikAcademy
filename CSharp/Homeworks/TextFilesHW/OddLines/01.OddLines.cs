using System;
using System.Text;
using System.IO;

namespace OddLines
{/*Write a program that reads a text file and prints on the console its odd lines.*/
    class OddLinesClass
    {
        static void Main(string[] args)
        {
            const string InputFile = @"..\..\MyTxtFile.txt";
            StreamReader sr;
            try
            {
                sr = new StreamReader(InputFile, Encoding.GetEncoding("UTF-8"));
                using (sr)
                {
                    string line = sr.ReadLine();//Reads the first line of the text files
                    while (line != null)
                    {
                        //assigns to line every second line of the file and prints line in the next iteration
                        Console.WriteLine(line);
                        sr.ReadLine();
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occured! "+ex.Message);
            }
        }
    }
}
