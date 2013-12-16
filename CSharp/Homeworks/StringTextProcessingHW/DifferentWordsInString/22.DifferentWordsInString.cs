using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DifferentWordsInString
{/*22.Write a program that reads a string from the console and lists all different 
  words in the string along with information how many times each word is found*/
    class DifferentWordsInStringClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert a string: ");
            string myStr = Console.ReadLine();
            //Inserts all words into a Matchcollection
            Regex word = new Regex(@"\b\w+\b");
            MatchCollection words = word.Matches(myStr);
            //creates a list with all the distinct matches
            List<string> distinctWords = words.OfType<Match>().Select(m => m.Value).ToList().Distinct(StringComparer.CurrentCultureIgnoreCase).ToList();
            //prints to the consolw the distinct words and their repetitions
            distinctWords.ForEach(m => Console.WriteLine("The word \"{0}\" repeats {1,3} times.",m,Regex.Matches(myStr, @"\b"+m+@"\b").Count)); 
            
        }
    }
}
