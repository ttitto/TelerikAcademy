using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01OddEven
{
    /*1. Write an expression that checks if given integer is odd or even.*/
    class Ex01OddEvenClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert an integer: ");
            int myInt=int.Parse(Console.ReadLine());
            bool isEven = myInt % 2 == 0;
            Console.WriteLine("isEven: {0}",isEven);
        }
    }
}
