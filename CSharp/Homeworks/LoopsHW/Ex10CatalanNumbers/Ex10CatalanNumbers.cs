using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace Ex10CatalanNumbers
{
    /*10. Write a program to calculate the Nth Catalan number by given N.
     First some catalans: 1, 1, 2, 5, 14, 42, 132, 429, 1430, 4862, 16796, 
     * 58786, 208012, 742900, 2674440, 9694845, 35357670, 129644790, 477638700, 
     * 1767263190, 6564120420, 24466267020, 91482563640, 343059613650, 1289904147324, 4861946401452     */
    class Ex10CatalanNumbersClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert N: ");
            uint n = uint.Parse(Console.ReadLine());
            if (n == 0 || n == 1)
            {
                Console.WriteLine(1);
                return;
            }
            double product = 1;
            for (uint ii = 2; ii <= n; ii++)
            {
                product *= (double)(n + ii) / ii;
            }
            Console.WriteLine(product);
        }
    }
}
