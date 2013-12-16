using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex09SubsetSumZero
{
    /*9. We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0. 
     * Example: 3, -2, 1, 1, 8  1+1-2=0.*/

    /*A solution using dynamic programming algorithm from the course Algo Academy. The code written in C++ is in the
     presentation of the above course on slide 23
     http://telerikacademy.com/Courses/Courses/Details/18 
     http://pastebin.com/N4VGcBTc */
    class Ex09SubsetSumZeroClass
    {
        static void Main(string[] args)
        {
            int count = 5;
            int[] numbers = new int[count];
            //Input numbers
            for (int i = 0; i < count; i++)
            {
                Console.Write("number {0}:", i);
                numbers[i] = int.Parse(Console.ReadLine());
            }
            //Insert the wanted sum
            Console.Write("Insert searched sum S: ");
            int s = int.Parse(Console.ReadLine());

            int minpos = numbers[0];
            int maxpos = numbers[0];
            int offset = 100000;
            //create shifted array to hold positions (0 or 1) for all sums
            int[] possible = new int[offset + offset];
            //loops through the numbers in the sequence
            for (int j = 0; j < count; j++)
            {
                int newMinPos = minpos;
                int newMaxPos = maxpos;
                int[] newPossible = new int[offset + offset];

                for (int ii = maxpos; ii >= minpos; ii--) //ii = a possible sum
                {
                    if (possible[ii + offset] == 1)
                    {
                        newPossible[ii + numbers[j] + offset] = 1;
                    }
                    if (ii + numbers[j] > newMaxPos)
                    {
                        newMaxPos = ii + numbers[j];
                    }
                    if (ii + numbers[j] < newMinPos)
                    {
                        newMinPos = ii + numbers[j];
                    }
                }
                minpos = newMinPos;
                maxpos = newMaxPos;
                for (int ii = maxpos; ii >= minpos; ii--)
                {
                    if (newPossible[ii + offset] == 1)
                    {
                        possible[ii + offset] = 1;
                    }
                }
                if (numbers[j] > maxpos)
                {
                    maxpos = numbers[j];
                }
                if (numbers[j] < minpos)
                {
                    minpos = numbers[j];
                }
                possible[numbers[j] + offset] = 1;
            }

            if (s >= max || s <= min)
            {
                Console.WriteLine("The sum {0} is impossible.", s);
            }
            else if (possible[s + offset] != 1)
            {
                Console.WriteLine("The sum {0} is impossible.", s);
            }
            else
            {
                Console.WriteLine("The sum {0} is possible.", s);
            }
            Console.WriteLine();

            Console.WriteLine("All possible sums: ");
            for (int i = minpos; i <= maxpos; i++)
            {
                if (possible[i + offset] == 1) Console.Write(" {0}", i);
            }
            Console.WriteLine();
        }
    }
}
