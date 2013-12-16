using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMASPIntegers
{
    /*Write methods to calculate minimum, maximum, average, sum and product of given
     * set of integer numbers. Use variable number of arguments.*/
    class MMASPIntegersClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert the set of integers. \r To continue to calculations enter \"b\"");
            List<long> ints = new List<long>();
            string input = Console.ReadLine();
            while (input != "b")
            {
                ints.Add(long.Parse(input));
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
        static long Minimum(params long[] longs)
        {
            return longs.ToList().Min();
        }
        static long Maximum(params long[] longs)
        {
            return longs.ToList().Max();
        }
        static long Sum(params long[] longs)
        {
            return longs.ToList().Sum();
        }
        static long Product(params long[] longs)
        {
            long product=1;
            for (int i = 0; i < longs.Length; i++)
            {
                product=longs[i]*product;
            }
            return product;
        }
        static double Average(params long[] longs)
        {
            return longs.ToList().Average();
        }

    }
}
