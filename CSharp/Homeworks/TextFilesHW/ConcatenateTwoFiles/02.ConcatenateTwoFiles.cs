using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConcatenateTwoFiles
{/*Write a program that concatenates two text files into another text file.*/
    class ConcatenateTwoFilesClass
    {
        static void Main(string[] args)
        {
            string txtFile1Path = @"..\..\myTxtFile1.txt";
            string txtFile2Path = @"..\..\myTxtFile2.txt";
            string txtFile3Path = @"..\..\myTxtFile3.txt";
            StreamReader srFile1, srFile2;
            StreamWriter sw;

            try
            {
                //Creates two Streamreaders, concatenates their results, then writes the result with StreamWriter
                srFile1=new StreamReader(txtFile1Path,Encoding.GetEncoding("UTF-8"));
                srFile2=new StreamReader(txtFile2Path,Encoding.GetEncoding("UTF-8"));
                sw=new StreamWriter(txtFile3Path,false,Encoding.GetEncoding("UTF-8"));
                using (srFile1)
                {
                    using (srFile2)
                    {
                        using (sw)
                        {
                            sw.Write(srFile1.ReadToEnd()+srFile2.ReadToEnd());
                        }
                    }
                }
                Console.WriteLine("File concatenation succeeded.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured! "+ex.Message);
            }
        }
    }
}
