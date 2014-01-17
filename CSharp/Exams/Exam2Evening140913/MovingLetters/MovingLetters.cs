using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MovingLetters
{
    class MovingLettersClass
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //  Stopwatch sw = new Stopwatch();
            //  sw.Start();
            int wordsCnt = words.Count();
            int longest = words.Select(w => w.Length).Max();
            //  Console.WriteLine(sw.ElapsedMilliseconds);
            for (int i = 0; i < wordsCnt; i++)
            {
                words[i] = words[i].PadLeft(longest, '*');
            }
            //  Console.WriteLine(sw.ElapsedMilliseconds);
            StringBuilder lettersStr = new StringBuilder();

            for (int ch = longest - 1; ch >= 0; ch--)
            {
                for (int ii = 0; ii < wordsCnt; ii++)
                {
                    char last = words[ii][ch];
                    if (last != '*')
                    {
                        lettersStr.Append(last);
                    }
                }
            }
            // Console.WriteLine(sw.ElapsedMilliseconds);

            //List<char> letters = lettersStr.ToString().ToList<char>();
            int lettersCnt = lettersStr.Length;
            //Console.WriteLine(sw.ElapsedMilliseconds);
            for (int pos = 0; pos < lettersCnt; pos++)
            {
                char current = lettersStr[pos];
                int targetIndx = (lettersStr[pos].ToString().ToUpper()[0] - 64 + pos) % lettersCnt; // - target position
                if (targetIndx > pos)
                {
                    lettersStr.Remove(pos, 1);
                    lettersStr.Insert(targetIndx, current);
                }
                else
                {
                    lettersStr.Insert(targetIndx, current);
                    lettersStr.Remove(pos + 1, 1);
                }
            }
            // Console.WriteLine(sw.ElapsedMilliseconds);
            Console.WriteLine(String.Join("", lettersStr));
        }
    }
}