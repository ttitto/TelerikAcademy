using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02DividedBy5And7
{
    /*2. Write a boolean expression that checks for given integer if it can be divided 
     * (without remainder) by 7 and 5 in the same time.*/
    class Ex02DividedBy5And7Class
    {
        static void Main(string[] args)
        {
            Console.Write("Insert an integer: ");
            int myInt = int.Parse(Console.ReadLine());
            bool isOK = (myInt % 5 == 0) && (myInt % 7 == 0);
            Console.WriteLine(isOK);
        }
    }
}
