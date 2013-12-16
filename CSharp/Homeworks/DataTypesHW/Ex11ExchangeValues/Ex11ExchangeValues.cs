using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex11ExchangeValues
{
    /*11. Declare  two integer variables and assign them with 5 and 10 and after that exchange their values.*/
    class Ex11ExchangeValuesClass
    {
        static void Main(string[] args)
        {
            //enjoy it
            int a = 5;
            int b = 10;
            //swap using a temporary variable
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine(a);
            Console.WriteLine(b);

            //bitwise value swapping
            //You will learn about it in the Operators lecture
            a ^= b;
            b ^= a;
            a ^= b;
            Console.WriteLine(a);
            Console.WriteLine(b);

            //swapping using artihmetic operations (+, *)
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
