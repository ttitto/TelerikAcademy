using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericMMASPIntegers
{
    class GenericMMASPIntegersClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert the set of integers.\nTo continue to calculations enter \"b\"");
            List<decimal> ints = new List<decimal>();
            string input = Console.ReadLine();
            while (input != "b")
            {
                ints.Add(decimal.Parse(input));
                input = Console.ReadLine();
            }
            Console.WriteLine("Insert one of the commands below:");
            Console.WriteLine("min, max, sum, prod, aver, break");
            string command = Console.ReadLine();
            while (command != "break")
            {
                switch (command)
                {
                    case "min":
                        Console.WriteLine("The minimum for the set of integers is: {0}", Minimum(ints.ToArray()));
                        break;
                    case "max":
                        Console.WriteLine("The maximum for the set of integers is: {0}", Maximum(ints.ToArray()));
                        break;
                    case "aver":
                        Console.WriteLine("The average for the set of integers is: {0}", Average(ints.ToArray()));
                        break;
                    case "sum":
                        Console.WriteLine("The sum for the set of integers is: {0}", Sum(ints.ToArray()));
                        break;
                    case "prod":
                        Console.WriteLine("The product for the set of integers is: {0}", Product(ints.ToArray()));
                        break;
                    default:
                        Console.WriteLine("Command not recognized. Try again!");
                        break;
                }
                command = Console.ReadLine();
            }
        }
        static T Minimum<T>(params T[] longs)
        {
            return (dynamic)longs.ToList().Min();
        }
        static T Maximum<T>(params T[] longs)
        {
            return (dynamic)longs.ToList().Max();
        }
        static T Sum<T>(params T[] longs)
        {
            dynamic sum = default(T);
            for (int i = 0; i < longs.Length; i++)
            {
                sum += (dynamic)longs[i];
            }
            return sum;
        }
        static T Product<T>(params T[] longs)
        {
            dynamic product = default(T);
            product = (dynamic)longs[0];
            for (int i = 1; i < longs.Length; i++)
            {
                product *= (dynamic)longs[i];
            }
            return product;
        }
        static T Average<T>(params T[] longs)
        {
            dynamic sum = default(T);
            for (int i = 0; i < longs.Length; i++)
            {
                sum += (dynamic)longs[i];
            }
            return sum/(dynamic)longs.Length;
        }
    }
}
