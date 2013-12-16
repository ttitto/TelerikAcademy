using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04ConditionalCountOfNumbers
{
    /*4. Write a program that reads two positive integer numbers and prints how many numbers p exist 
     * between them such that the remainder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.*/
    class Ex04ConditionalCountOfNumbersClass
    {
        static void Main(string[] args)
        {
            Console.Write("first number: ");
            uint first = uint.Parse(Console.ReadLine());
            Console.Write("second number: ");
            uint second = uint.Parse(Console.ReadLine());

            uint cnt = 0;
            //looping from the smaller number to the bigger inclusive
            for (uint i = (first > second) ? second : first; i <= ((first > second) ? first : second); i++)
            {
                if (i % 5 == 0)
                {
                    cnt++;
                }
            }
            Console.WriteLine(cnt);
        }
    }
}
