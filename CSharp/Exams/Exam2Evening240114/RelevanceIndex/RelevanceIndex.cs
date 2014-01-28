using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RelevanceIndex
{
    class RelevanceIndexClass
    {
        //static void Main(string[] args)
        //{
        //    string word = Console.ReadLine();
        //    int n = int.Parse(Console.ReadLine());
        //    string[] paragraphs = new string[n];
        //    int[] counts = new int[n];
        //    Regex rg = new Regex(@"\b" + word + @"\b");
        //    for (int i = 0; i < n; i++)
        //    {
        //        paragraphs[i] = (Console.ReadLine().Trim());
        //        counts[i] = rg.Matches(paragraphs[i]).Count;
        //    }

        //    Array.Sort(counts, paragraphs);
        //    Regex withoutPunct = new Regex(@"[^\.\,\(\)\;\!\?\-]");

        //    for (int i = n - 1; i >= 0; i--)
        //    {
        //        var arr = withoutPunct.Matches(paragraphs[i]).OfType<Match>().Select(m => m.Groups[0].Value.ToString()).ToArray();
        //        Console.WriteLine(rg.Replace(string.Join("", arr), word.ToUpper()));

        //    }
        //}
        static void Main()
        {
            string word = Console.ReadLine();
            Regex rg = new Regex(@"\b" + word + @"\b", RegexOptions.IgnoreCase);
            int n = int.Parse(Console.ReadLine());
            string[] paragraphs = new string[n];
            int[] counts = new int[n];
            for (int i = 0; i < n; i++)
            {
                paragraphs[i] = Console.ReadLine().Split(new char[] { ' ', ',', '.', '?', ')', '(', '!', '-', ';' }, StringSplitOptions.RemoveEmptyEntries).Aggregate((a, j) => a + ' ' + j);
                paragraphs[i] = rg.Replace(paragraphs[i], word.ToUpper());

                counts[i] = rg.Matches(paragraphs[i]).Count;
            }

            Array.Sort(counts, paragraphs);
            for (int i = paragraphs.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(paragraphs[i]);
            }
        }
    }
}
