using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex06QuadraticEquation
{
    /*6. Write a program that enters the coefficients a, b and c of a quadratic equation 	a*x2 + b*x + c = 0    
     and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.*/
    class Ex06QuadraticEquationClass
    {
        static void Main(string[] args)
        {
            Console.Write("a= ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b= ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c= ");
            double c = double.Parse(Console.ReadLine());

            double root1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            double root2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);

            Console.WriteLine("The solution is: ({0:N},{1:N})", root1, root2);
        }
    }
}
