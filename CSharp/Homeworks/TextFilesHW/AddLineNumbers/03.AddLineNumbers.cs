using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AddLineNumbers
{/*Write a program that reads a text file and inserts line numbers in 
  * front of each of its lines. The result should be written to another text file.*/
    class AddLineNumbersClass
    {
        static void Main(string[] args)
        {
            string ReadFilePath = @"..\..\ReadFile.txt";
            string WriteFilePath = @"..\..\WriteFile.txt";
            StreamReader sr;
            StreamWriter sw;
            StreamWriter swFirstLine;
            try
            {
                sr = new StreamReader(ReadFilePath, Encoding.GetEncoding("UTF-8"));
                using (sr)
                {
                    //Initializing a StreamWriter that will delete the content of a file if it already exists
                    swFirstLine = new StreamWriter(WriteFilePath, false, Encoding.GetEncoding("UTF-8"));
                    using (swFirstLine)
                    {
                        //reads and writes with line number the first line
                        swFirstLine.WriteLine(("1: " + sr.ReadLine()));
                    }
                    //Initializing a Streamwriter that will append rows with line numbers into the new file
                    sw = new StreamWriter(WriteFilePath, true, Encoding.GetEncoding("UTF-8"));
                    using (sw)
                    {

                        //reads the second line
                        string line = sr.ReadLine();
                        int i = 2;
                        //loops through all lines, reads their content and
                        //appends to the beginning of each line the next line number
                        while (line != null)
                        {
                            sw.WriteLine(String.Format("{0}: ", i) + line);
                            line = sr.ReadLine();
                            i++;
                        }
                    }
                }
                Console.WriteLine("All lines are numbered in a new file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured! " + ex.Message);
            }
        }
    }
}
