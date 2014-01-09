using System;
using System.Collections.Generic;
using System.Numerics;

namespace Zerg
{
    class ZergClass
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> alfabet = new Dictionary<string, int>() {
            {"Rawr",0},
            {"Rrrr",1},
            {"Hsst",2},
            {"Ssst",3},
            {"Grrr",4},
            {"Rarr",5},
            {"Mrrr",6},
            {"Psst",7},
            {"Uaah",8},
            {"Uaha",9},
            {"Zzzz",10},
            {"Bauu",11},
            {"Djav",12},
            {"Myau",13},
            {"Gruh",14}
            };
            string[] strArr = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
            string input = String.Join("", strArr);
            BigInteger multiplier = 1;
            BigInteger sum = 0;
            for (int i = input.Length - 4; i >= 0; i -= 4)
            {
                int codedNum;
                if (alfabet.TryGetValue(input.Substring(i, 4), out codedNum))
                {
                    sum += codedNum * multiplier;
                    multiplier *= 15;
                }
            }
            Console.WriteLine("{0}", sum);
        }
    }
}
