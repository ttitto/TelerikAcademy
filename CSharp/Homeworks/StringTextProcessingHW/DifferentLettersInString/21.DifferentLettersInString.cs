using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DifferentLettersInString
{/*21.Write a program that reads a string from the console and prints all different letters in
  the string along with information how many times each letter is found. */
    class DifferentLettersInStringClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert a string: ");
            //to ignore the case of the letters, makes the lowercase
            string myStr = Console.ReadLine().ToLower();
            //puts all distinct chars into a list
            List<char> distinctLetters = new List<char>();
            distinctLetters = myStr.Distinct().ToList();
            //for every char check if it is a letter and use matchcollection for each letter to count the occurencies
            char myLetter;
            foreach (var item in distinctLetters)
            {
                myLetter = char.Parse(item.ToString());
                if (Char.IsLetter(myLetter))
                {
                    Regex character = new Regex(myLetter.ToString(), RegexOptions.IgnoreCase);
                    Console.WriteLine("The letter {0} is found {1,3} times.", myLetter, character.Matches(myStr).Count);
                }
            }
        }
    }
}
