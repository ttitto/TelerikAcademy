using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex07PrimeNumbers
{
    /*7. Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.*/
    class Ex07PrimeNumbersClass
    {
        static void Main(string[] args)
        {
            uint myInt = uint.Parse(Console.ReadLine());
            bool isPrime = (myInt >= 2 ? true : myInt % 2 != 0) &&
                (myInt >= 3 ? true : myInt % 3 != 0) &&
                (myInt >= 4 ? true : myInt % 4 != 0) &&
                (myInt >= 5 ? true : myInt % 5 != 0) &&
                (myInt >= 6 ? true : myInt % 6 != 0) &&
                (myInt >= 7 ? true : myInt % 7 != 0) &&
                (myInt >= 8 ? true : myInt % 8 != 0) &&
                (myInt >= 9 ? true : myInt % 9 != 0) &&
                (myInt >= 10 ? true : myInt % 10 != 0);

            Console.WriteLine(isPrime);
        }
    }
}
