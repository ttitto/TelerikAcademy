using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StrangeLandNumbers
{
    class StrangeLandNumbersClass
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex rgx = new Regex(@"f|bIN|oBJEC|mNTRAVL|lPVKNQ|pNWE|hT");
            string[] arr = new string[] { "f", "bIN", "oBJEC", "mNTRAVL", "lPVKNQ", "pNWE", "hT" };

            MatchCollection matches = rgx.Matches(input);
            BigInteger multiplier = 1;
            BigInteger sum = 0;

            for (int i = matches.Count - 1; i >= 0; i--)
            {
                sum += Array.IndexOf(arr, matches[i].ToString()) * multiplier;
                multiplier *= 7;
            }

            Console.WriteLine("{0}", sum);
        }
    }
}
