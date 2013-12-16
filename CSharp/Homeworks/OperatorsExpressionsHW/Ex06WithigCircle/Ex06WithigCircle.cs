using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex06WithigCircle
{
    /*6. Write an expression that checks if given point (x,  y) is within a circle K(O, 5).*/
    class Ex06WithigCircleClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert x: ");
            int x=int.Parse(Console.ReadLine());
            Console.Write("Insert y: ");
            int y = int.Parse(Console.ReadLine());

            bool isOutside = Math.Sqrt(x*x+y*y)>5;
            Console.WriteLine(isOutside);
        }
    }
}
