using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShapesCalculateSurface
{
    /*1. Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height.
     * Define two new classes Triangle and Rectangle that implement the virtual method and return the surface 
     * of the figure (height*width for rectangle and height*width/2 for triangle). 
     * Define class Circle and suitable constructor so that at initialization height must be kept equal to width 
     * and implement the CalculateSurface() method. 
     * 
     * Write a program that tests the behavior of the CalculateSurface() method for different shapes
     * (Circle, Rectangle, Triangle) stored in an array.*/
    class ShapesCalculateSurfaceClass
    {
        static void Main(string[] args)
        {
            Circle c = new Circle(2.3);
            Shape rect = new Rectangle(2.5, 5.6);
            Triangle tr = new Triangle(5.9,4.5);
            Shape circle = new Circle(84000d);
            Shape triangle = new Triangle(3.4, 2.3);

            Shape[] shapes = new Shape[5] { c, rect, tr, circle, triangle };
            foreach (var item in shapes)
            {
                checked
                {
                    Console.WriteLine("I am {0} and my surface is {1:F}", item.GetType().Name.PadLeft(10, ' '), item.CalculateSurface(item));
                }
            }
        }
    }
}
