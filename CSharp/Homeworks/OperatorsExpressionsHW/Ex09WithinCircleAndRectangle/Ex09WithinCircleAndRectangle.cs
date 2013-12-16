using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex09WithinCircleAndRectangle
{
    /*9. Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3)
     * and out of the rectangle R(top=1, left=-1, width=6, height=2).*/
    class Ex09WithinCircleAndRectangleClass
    {
        static void Main(string[] args)
        {
            Console.Write("x: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("y: ");
            int y = int.Parse(Console.ReadLine());
            bool isInside = !(y <= 1 && y >= -1 && x >= -1 && x <= 5) && ((x - 1) * (x - 1) + (y - 1) * (y - 1) <= 9);
            Console.WriteLine("Is out of the rectangle and inside of the circle area: {0}", isInside);
        }
    }
}
