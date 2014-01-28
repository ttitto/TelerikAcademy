using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BunnyFactory
{
    class BunnyFactoryClass
    {
        static List<int> cages = new List<int>();
        static void Main(string[] args)
        {
            int n = 0;
            while (int.TryParse(Console.ReadLine(), out n))
            {
                cages.Add(n);
            }
            FactoryRun(ref cages);
            PrintResult(ref cages);

        }

        static void FactoryRun(ref List<int> cages)
        {
            bool isWorking = true;
            int cycle = 1;
            BigInteger sum = 0;
            BigInteger product = 1;
            while (isWorking)
            {
                //1. if less cages than ith cycle
                if (cages.Count <= cycle)
                {
                    isWorking = false;
                    return;
                }
                //2. take first i cages and sum bunnies
                int s = cages.Take(cycle).Aggregate((i, j) => i + j);

                //3. factory stops if cages.count-cycle<s
                if (cages.Count() - cycle < s)
                {
                    isWorking = false;
                    return;
                }
                else
                {
                    sum = cages.Skip(cycle).Take(s).Sum();
                    product = cages.Skip(cycle).Take(s).Aggregate((i, j) => i * j);
                    string next = sum.ToString() + product.ToString();
                    List<int> nextCages = next.ToCharArray().Select(i => i - '0').ToList();
                    nextCages.AddRange(cages.Skip(cycle + s).Take(cages.Count - cycle - s));
                    nextCages.RemoveAll(i => (i == 0 || i == 1));
                    cages = nextCages;
                }

                cycle++;
            }
        }
        private static void PrintResult(ref List<int> cages)
        {
            cages.ForEach(item => Console.Write("{0} ", item));
        }

    }
}
