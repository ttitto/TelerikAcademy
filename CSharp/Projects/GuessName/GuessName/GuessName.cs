using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessName
{
    class GuessNameClass
    {

        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string sub = Console.ReadLine();
                if (IsPerson(text, sub))
                {
                    Console.WriteLine("Person");
                    continue;
                }
                if (IsPlace(text,sub))
                {
                    Console.WriteLine("Place");
                    continue;
                }
                if (IsPlace(text,sub)==false && IsPerson(text,sub)==false)
                {
                    Console.WriteLine("Unknown");
                }
            }

        }
        static bool IsPerson(string text, string sub)
        {
           
            return false;
        }
        static bool IsPlace(string text, string sub)
        {
            if(sub.Contains("ия")) return true;
            return false;
        }

    }

}
