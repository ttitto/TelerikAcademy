using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriangleSurface
{/*Write methods that calculate the surface of a triangle by given:
Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.*/
    class TriangleSurfaceClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Choose the method for area calculation of a triangle: 
side and an altitude - Press 1
three sides - Press 2
two sides and an angle - Press 3");
            int input = int.Parse(Console.ReadLine());
            double side, sideA, sideB, sideC, altitude;
            int angle;
            switch (input)
            {
                case 1:
                    {
                        Console.Write("Insert side: ");
                        side = double.Parse(Console.ReadLine());
                        Console.Write("Insert altitude: ");
                        altitude = double.Parse(Console.ReadLine());
                        Console.WriteLine("The area of the triangle is {0,2:F}", TriangleSurface(side, altitude));
                        break;
                    }
                case 2:
                    {
                        Console.Write("Insert three sides: ");
                        sideA = double.Parse(Console.ReadLine());
                        sideB = double.Parse(Console.ReadLine());
                        sideC = double.Parse(Console.ReadLine());
                        Console.WriteLine("The area of the triangle is {0,2:F}", TriangleSurface(sideA, sideB, sideC));
                        break;
                    }
                case 3:
                    {
                        Console.Write("Insert twо sides: ");
                        sideA = double.Parse(Console.ReadLine());
                        sideB = double.Parse(Console.ReadLine());
                        Console.Write("Insert an angle: ");
                        angle = int.Parse(Console.ReadLine());
                        Console.WriteLine("The area of the triangle is {0,2:F}", TriangleSurface(sideA, sideB, angle));
                        break;
                    }
                default:
                    break;
            }

        }
        static double TriangleSurface(double side, double altitude)
        {
            double surface = side * altitude / 2;
            return surface;
        }
        static double TriangleSurface(double sideA, double sideB, double sideC)
        {
            double semiPerimeter = (sideA + sideB + sideC) / 2;
            double surface = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
            return surface;
        }
        static double TriangleSurface(double sideA, double sideB, int angle)
        {
            double surface = (sideA * sideB * Math.Sin((double)angle)) / 2;
            return surface;
        }

    }

}
