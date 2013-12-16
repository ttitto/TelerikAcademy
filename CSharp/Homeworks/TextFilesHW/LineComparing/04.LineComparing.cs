using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LineComparing
{/*Write a program that compares two text files line by line and 
  * prints the number of lines that are the same and the number of lines that 
  * are different. Assume the files have equal number of lines.*/
    class LineComparingClass
    {
        static void Main(string[] args)
        {
            string file1Path = @"..\..\MyTxtFile1.txt";
            string file2Path = @"..\..\MyTxtFile2.txt";
            StreamReader sr1;
            StreamReader sr2;
            int different = 0;
            int equal = 0;
            try
            {
                sr1 = new StreamReader(file1Path, Encoding.GetEncoding("UTF-8"));
                sr2 = new StreamReader(file2Path, Encoding.GetEncoding("UTF-8"));
                using (sr1)
                {
                    using (sr2)
                    {
                        
                        while (true)
                        {
                            string line;
                            //reads the firs line of the first file
                            line = sr1.ReadLine();
                            //if the first line of the first line return null then exit from the loop
                            if (line == null) break;
                            //adds 1 to equal everytime the rows are equal or adds 1 to different if they are not
                            if (line.CompareTo(sr2.ReadLine()) == 0) equal++;
                            else different++;
                        }
                    }
                }
                Console.WriteLine("There are {0} equal lines and {1} different lines.", equal, different);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured! " + ex.Message);
            }
        }
    }
}
