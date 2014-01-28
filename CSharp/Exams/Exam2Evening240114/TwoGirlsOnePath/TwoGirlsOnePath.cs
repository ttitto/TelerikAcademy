using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TwoGirlsOnePath
{
    class TwoGirlsOnePathClass
    {
        static BigInteger[] field;
        static int fSize = 0;
        static bool isMollyOnEmpty = false;
        static bool isDollyOnEmpty = false;
        static BigInteger sumMolly = 0;
        static BigInteger sumDolly = 0;
        static int nextMollyPos;
        static int nextDollyPos;
        static int currMollyPos;
        static int currDollyPos;
        static void Main(string[] args)
        {
            field = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(item => BigInteger.Parse(item)).ToArray();
            fSize = field.Count();

            sumMolly = field[0];
            sumDolly = field[fSize - 1];
            currMollyPos = 0;
            currDollyPos = fSize - 1;
            currMollyPos = nextMollyPos = GetMollyNextPos();
            currDollyPos = nextDollyPos = GetDollyNextPos();
            field[0] = 0;
            field[fSize - 1] = 0;

            GameRun();
            if (isMollyOnEmpty==true && isDollyOnEmpty==false)
            {
                Console.WriteLine("Dolly");

            }
            if (isMollyOnEmpty==false && isDollyOnEmpty==true)
            {
                Console.WriteLine("Molly");

            }
            if (isMollyOnEmpty==true && isDollyOnEmpty==true)
            {
                Console.WriteLine("Draw");
            }
            Console.WriteLine("{0} {1}", sumMolly, sumDolly);
        }
        private static int GetMollyNextPos()
        {
            return (int)(field[currMollyPos] + (BigInteger)currMollyPos) % (fSize);
        }
        private static int GetDollyNextPos()
        {
            nextDollyPos = (int)((BigInteger)currDollyPos - (field[currDollyPos]));
            while (nextDollyPos < 0)
            {
                nextDollyPos = fSize + nextDollyPos;
            }
            return nextDollyPos;
        }


        static void GameRun()
        {
            //both takes flowers from the starting position

            while (true)
            {
                if (isMollyOnEmpty==true)
                {
                    break;
                }
                if (isDollyOnEmpty==true)
                {
                    break;
                }
                //if Molly is on empty
                if (field[currMollyPos] == 0)
                {
                    isMollyOnEmpty = true;
                }

                //if Dolly is on empty
                if (field[currDollyPos] == 0)
                {
                    isDollyOnEmpty = true;
                }
                if (currMollyPos == currDollyPos)
                {
                    //divide flowers
                    sumMolly += field[currMollyPos] % 2;
                    sumDolly += field[currDollyPos] % 2;
                    field[currMollyPos] = 1;
                    //current=next
                    nextMollyPos = GetMollyNextPos();
                    nextDollyPos = GetDollyNextPos();

                }
                else
                {
                    //add flowers to both
                    //nullify field
                    sumMolly += field[currMollyPos];
                    sumDolly += field[currDollyPos];
                    //current=next
                    nextMollyPos = GetMollyNextPos();
                    nextDollyPos = GetDollyNextPos();
                    field[currDollyPos] = 0;
                    field[currMollyPos] = 0;
                }
                currMollyPos = nextMollyPos;
                currDollyPos = nextDollyPos;
            }
        }
    }
}
