using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XMLTextNoTagsExtract
{/*Write a program that extracts from given XML file all the text without the tags.*/
    class XMLTextNoTagsExtractClass
    {
        static void Main(string[] args)
        {
            string xml = @"..\..\xmlFile.txt";
            string outputFile = @"..\..\outputFile.txt";
            StreamReader sr;
            StreamWriter sw;
            bool IsTag = true;
            try
            {
                sr = new StreamReader(xml);
                using (sr)
                {
                    sw = new StreamWriter(outputFile, false);
                    using (sw)
                    {
                        //creates nes stringbuilder to hold the text outside the tags
                        StringBuilder sb = new StringBuilder();
                        //loops through the lines of the xml file
                        for (string line; (line = sr.ReadLine()) != null; )
                        {
                            //initializes a variable to hold the previous character
                            string last=String.Empty;
                            foreach (var item in line.ToList())
                            {    
                                if (item.ToString() == "<")
                                {
                                    //if new tag starts and the char before was not a closing tag then 
                                    //insert a new line character to separate the words
                                    if (IsTag==false && last!=">") sb.AppendLine();
                                    IsTag = true;
                                    last=  item.ToString();
                                    continue;
                                }
                                //if a tag ends change bool variable and continue
                                if (item.ToString() == ">")
                                {
                                    IsTag = false;
                                    last=  item.ToString();
                                    continue;
                                }
                                //if the bool variable is false then append the character to a stringbuilder
                                if (IsTag == false)
                                {
                                    sb.Append(item);
                                }
                                last=  item.ToString();
                            }
                        }
                        //prints the stringbuilder to a new txt file
                        sw.WriteLine(sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured during execution. " + ex.Message);
            }
        }
    }
}
