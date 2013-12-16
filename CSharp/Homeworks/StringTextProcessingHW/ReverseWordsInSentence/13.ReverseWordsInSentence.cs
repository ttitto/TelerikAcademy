using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ReverseWordsInSentence
{/*13.Write a program that reverses the words in given sentence.
	Example: "C# is not C++, not PHP and not Delphi!" => "Delphi not and PHP, not C++ not is C#!".*/
    class ReverseWordsInSentenceClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert sentence: ");
            string mySentence = Console.ReadLine();

            StringBuilder word = new StringBuilder();
            List<string> sentence = new List<string>();
            char[] punctuation = new char[] {'.',',','!',';',':','?','-'};
            char[] punctuationInSentence=new char[mySentence.Length];
            int wordPosition = 0;
            for (int i = 0; i < mySentence.Length; i++)
            {
                if (punctuation.Contains( mySentence[i]))
                {
                    if (word.ToString()!="")
                    {
                        sentence.Add(" " + word.ToString());
                        word.Clear();
                        wordPosition++;
                    }
                    punctuationInSentence[wordPosition]=mySentence[i];
                    wordPosition++;
                }
                else if (char.IsSeparator(mySentence[i]))
                {
                    sentence.Add(" "+word.ToString());
                    word.Clear();
                    wordPosition++;
                }
                else
                {
                    word.Append(mySentence[i]);
                }
            }
            sentence.Reverse();
            for (int j = 0; j < punctuationInSentence.Length; j++)
            {
                if(punctuationInSentence[j]!='\0') sentence.Insert(j,punctuationInSentence[j].ToString());
            }
            sentence.ForEach(a=>Console.Write(a));
            Console.WriteLine();
        }
    }
}
