using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingLetters
{
    class MovingLettersClass
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().ToUpper().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int wordsCnt = words.Count();
            int longest = words.Select(w => w.Length).Max();
            for (int i = 0; i < wordsCnt; i++)
            {
                words[i] = words[i].PadLeft(longest, '*');
            }

            string letters = string.Empty;

            for (int ch = longest - 1; ch >= 0; ch--)
            {
                for (int ii = 0; ii < wordsCnt; ii++)
                {
                    char last = words[ii][ch];
                    if (last != '*')
                    {
                        letters += last;
                    }
                }
            }

            //Console.WriteLine(letters);


        }
    }
}
