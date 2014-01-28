using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TRES4Numbers
{
    class TRES4NumbersClass
    {
        static void Main(string[] args)
        {

            BigInteger decNum = BigInteger.Parse(Console.ReadLine());
            List<string> nanoNum = new List<string>();
            string[] alfabet = new string[] { "LON+", "VK-", "*ACAD", "^MIM", "ERIK|", "SEY&", "EMY>>", "/TEL", "<<DON" };
            while (decNum > 0)
            {
                nanoNum.Add(alfabet[(int)decNum % 9]);
                decNum /= 9;
            }
            nanoNum.Reverse();
           Console.WriteLine( String.Join("",nanoNum));
        }

    }
}
