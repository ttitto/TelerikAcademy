using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MultiverseCommunication
{
    class MultiverseCommunicationClass
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex rgx = new Regex(@"CHU|TEL|OFT|IVA|EMY|VNB|POQ|ERI|CAD|K-A|IIA|YLO|PLA");
            string[] arr = new string[] { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };

            MatchCollection matches = rgx.Matches(input);
            BigInteger multiplier = 1;
            BigInteger sum = 0;

            for (int i = matches.Count - 1; i >= 0; i--)
            {
                sum += Array.IndexOf(arr, matches[i].ToString()) * multiplier;
                multiplier *= 13;
            }
            Console.WriteLine("{0}", sum);
        }
    }
}


