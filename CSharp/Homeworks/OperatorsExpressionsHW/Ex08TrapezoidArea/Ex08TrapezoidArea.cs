using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex08TrapezoidArea
{
    /*8. Write an expression that calculates trapezoid's area by given sides a and b and height h.*/
    class Ex08TrapezoidAreaClass
    {
        static void Main(string[] args)
        {
            double sideA, sideB, height;
            Console.Write("side a: ");
            sideA = double.Parse(Console.ReadLine());
            Console.Write("side b: ");
            sideB = double.Parse(Console.ReadLine());
            Console.Write("height h: ");
            height = double.Parse(Console.ReadLine());

            double area = (sideB + sideA) * height / 2;
            Console.WriteLine("trapezoid area: {0}",area);
        }
    }
}
