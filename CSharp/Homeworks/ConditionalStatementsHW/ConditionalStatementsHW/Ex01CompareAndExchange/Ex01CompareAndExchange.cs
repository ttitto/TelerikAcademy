using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex01CompareAndExchange
{
    /*1. Write an if statement that examines two integer variables and exchanges their values 
     * if the first one is greater than the second one.*/
    class Ex01CompareAndExchangeClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert the first integer: ");
            int first = int.Parse(Console.ReadLine());
            Console.Write("Insert the second integer: ");
            int second = int.Parse(Console.ReadLine());

            if (first > second)
            {
                //bitwise exchange
                first ^= second;
                second ^= first;
                first ^= second;
            }
            Console.WriteLine("first: {0}, second: {1}",first,second);
        }
    }
}
