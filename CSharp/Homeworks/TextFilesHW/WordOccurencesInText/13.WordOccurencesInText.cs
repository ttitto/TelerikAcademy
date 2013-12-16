using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RemoveWordsFromListOfWords;
using System.Text.RegularExpressions;
using System.IO;

namespace WordOccurencesInText
{/*Write a program that reads a list of words from a file words.txt and
  * finds how many times each of the words is contained in another file test.txt. 
  * The result should be written in the file result.txt and the words should be 
  * sorted by the number of their occurrences in descending order. 
  * Handle all possible exceptions in your methods.*/
    class WordOccurencesInTextClass
    {
        static void Main(string[] args)
        {
            string wordsFile = @"..\..\words.txt";
            string testFile = @"..\..\test.txt";
            string resultFile = @"..\..\result.txt";

            //insert the words to be tested in an array using a method from the previous exercise
            string[] myWords = RemoveWordsFromListOfWordsClass.TakeWords(wordsFile).ToArray();
            //an int array that will save on the same position of each word the number of matches in the text
            int[] myKeys = new int[myWords.Length];

            try
            {
                //start reading the test.txt
                //I prefer reading line per line to prevent errors with bigger files 
                for (int i = 0; i < myWords.Length; i++)
                {
                    using (StreamReader sr = new StreamReader(testFile))
                    {
                        int occCount = 0;
                        for (string line; (line = sr.ReadLine()) != null; )
                        {
                            occCount += MatchesCount(line, myWords[i]);
                        }
                        myKeys[i] = occCount;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occured while reading lines from the file." + ex.Message);
            }
            try
            {
                //sort the array with the words according the corresponding numbers in the myKeys array
                Array.Sort(myKeys, myWords);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occured while sorting the arrays with words and occurencies." + ex.Message);
            }
            //clear the result file if it already exists
            RemoveWordsFromListOfWordsClass.RemoveOutput(resultFile);
            //create the result.txt file
            FileWrite(resultFile, myWords, myKeys);

        }
        //Returns the count of regex Matches per line
        static int MatchesCount(string input, string word)
        {
            try
            {
                Regex regex = new Regex(@"\b" + word + @"\b", RegexOptions.IgnoreCase);
                MatchCollection matches = regex.Matches(input);
                return matches.Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occured while looking out for matches. " + ex.Message);
                throw;
            }

        }
        //writes the values from the myWords and myKeys arrays to the result.txt file
        static void FileWrite(string path, string[] words, int[] keys)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    for (int i = words.Length - 1; i >= 0; i--)
                    {
                        sw.WriteLine(string.Format("{0,-5} {1}", keys[i], words[i]));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception occured while writing in the results to the file." + ex.Message);
            }
        }
    }
}
