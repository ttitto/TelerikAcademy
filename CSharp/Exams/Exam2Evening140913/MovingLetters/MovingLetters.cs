using System;
using System.Collections.Generic;
using System.Linq;

namespace MovingLetters
{
    class MovingLettersClass
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int wordsCnt = words.Count();
            int longest = words.Select(w => w.Length).Max();

            string lettersStr = string.Empty;

            for (int ch = longest - 1; ch >= 0; ch--)
            {
                for (int ii = 0; ii < wordsCnt; ii++)
                {
                    try
                    {
                        char last = words[ii].Last();
                        words[ii] = words[ii].Remove(words[ii].Length - 1);
                        lettersStr += last;
                    }
                    catch (Exception)
                    {
                    }

                }
            }
            List<char> letters = lettersStr.ToList<char>();
            int lettersCnt = letters.Count();

            for (int pos = 0; pos < lettersCnt; pos++)
            {
                char current = letters[pos];
                int targetIndx = (letters[pos].ToString().ToUpper()[0] - 64 + pos) % lettersCnt; // - target position
                if (targetIndx > pos)
                {
                    letters.RemoveAt(pos);
                    letters.Insert(targetIndx, current);
                }
                else
                {
                    letters.Insert(targetIndx, current);
                    letters.RemoveAt(pos + 1);
                }
            }
            Console.WriteLine(String.Join("", letters));
        }
    }
}
