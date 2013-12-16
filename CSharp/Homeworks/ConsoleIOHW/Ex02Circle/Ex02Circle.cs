using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02Circle
{
    /*2. Write a program that reads the radius r of a circle and prints its perimeter and area.*/
    class Ex02CircleClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert the radius: ");
            double radius = double.Parse(Console.ReadLine());
            const double PI = Math.PI;

            Console.WriteLine("Area: {0:N3}", PI * 2 * radius);//showed with 3 digits after the decimal point
            Console.WriteLine("Perimeter: {0:N}", PI * radius * radius);
        }
    }
}
