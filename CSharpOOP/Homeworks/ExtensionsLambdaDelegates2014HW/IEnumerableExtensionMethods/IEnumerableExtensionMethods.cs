using System;
using System.Collections.Generic;
using System.Linq;

namespace IEnumerableExtensionMethods
{
    /*2. Implement a set of extension methods for IEnumerable<T> that implement the following group functions:
     * sum, product, min, max, average.*/

    //I hope there is no need to comment
    static class IEnumerableExtensionMethodsClass
    {
        static T Sum<T>(this IEnumerable<T> myIEnum)
        {
            dynamic sum = 0;
            foreach (var item in myIEnum)
            {
                sum = sum + (dynamic)item;
            }
            return sum;
        }
        static T Product<T>(this IEnumerable<T> myIEnum)
        {
            dynamic product = 1;
            foreach (var item in myIEnum)
            {
                product = product * (dynamic)item;
            }
            return product;
        }
        static T Min<T>(this IEnumerable<T> myIEnum)
        {
            dynamic min = myIEnum.First<T>();
            foreach (var item in myIEnum)
            {
                if (min > item) min = item;
            }
            return min;
        }
        static T Max<T>(this IEnumerable<T> myIEnum)
        {
            dynamic max = myIEnum.First<T>();
            foreach (var item in myIEnum)
            {
                if (max < item) max = item;
            }
            return max;
        }
        static T Average<T>(this IEnumerable<T> myIEnum)
        {
            dynamic sum = 0;
            foreach (var item in myIEnum)
            {
                sum = sum + (dynamic)item;
            }
            return sum/myIEnum.Count();
        }


        static void Main(string[] args)
        {
            List<double> list = new List<double>() { 2.5, 3.5, 4.8, -25.48 };
            Console.WriteLine(list.Sum<double>());
            Console.WriteLine(list.Product<double>());
            Console.WriteLine(list.Min<double>());
            Console.WriteLine(list.Max<double>());
            Console.WriteLine(list.Average<double>());        
        }
    }
}
