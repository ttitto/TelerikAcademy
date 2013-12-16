using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ListOfStrings
{
    class ListOfStringsClass
    {/*Write a program that reads a text file containing a list of strings,
      * sorts them and saves them to another text file. Example:
	Ivan			George
	Peter			Ivan
	Maria			Maria
	George			Peter
*/
        static void Main(string[] args)
        {
            try
            {
                string inputFile = @"..\..\InputFile.txt";
                string outputFile = @"..\..\OutputFile.txt";
                List<string> myStr = ReadFile(inputFile);
                myStr.Sort();
                WriteFile(outputFile, myStr);
                Console.WriteLine("Reading, sorting and exporting of the list of strings was successfull");
            }
            catch (Exception ex)
            {
                Console.WriteLine("A error occured during execution of the program. "+ex.Message);
            }
        }
        //the method reads each row and add it as an element in a List
        //the list of strings is returned
        static List<string> ReadFile(string path)
        {
            List<string> myStr = new List<string>();
            StreamReader sr;
            try
            {
                sr = new StreamReader(path, Encoding.GetEncoding("UTF-8"));
                using (sr)
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        myStr.Add(line);
                        line = sr.ReadLine();
                    }
                }
                return myStr;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error occured while reading from the file. " + ex.Message);
            }
            return null;
        }
        /*The method writes the sorted strings to a new txt file*/
        static void WriteFile(string path, List<string> myList)
        {
            StreamWriter sw;
            
            try
            {
                sw = new StreamWriter(path, false, Encoding.GetEncoding("UTF-8"));
                using (sw)
                {
                    foreach (var item in myList)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured while writing to a file. " + ex.Message);
            }
        }
    }
}
