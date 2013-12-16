using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex13TrailingZerosFactoriel
{
    /**13.  Write a program that calculates for given N how many trailing zeros present at the end of the number N!.
     * Examples:
	N = 10  N! = 3628800  2
	N = 20  N! = 2432902008176640000  4
	Does your program work for N = 50 000?
	Hint: The trailing zeros in N! are equal to the number of its prime divisors of value 5. Think why!
*/
    class Ex13TrailingZerosFactorielClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert N: ");
            uint n = uint.Parse(Console.ReadLine());
            //Division of two integers returns only the whole part
            Console.WriteLine("The number of trailing zeros for {0}! is {1}.", n, n / 5);
        }
    }
}
