using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03RectangleArea
{
    /*3. Write an expression that calculates rectangle’s area by given width and height.*/
    class Ex03RectangleAreaClass
    {
        static void Main(string[] args)
        {
            double area;
            double width;
            double height;
            Console.WriteLine("Enter width: ");
            width = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter height: ");
            height = double.Parse(Console.ReadLine());
            area = width * height;
            Console.WriteLine("Area: {0}",area);
        }
    }
}
