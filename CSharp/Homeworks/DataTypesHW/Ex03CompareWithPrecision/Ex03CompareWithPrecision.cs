using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03CompareWithPrecision
{
    /*3. Write a program that safely compares floating-point numbers with precision of 0.000001. 
     * Examples:(5.3 ; 6.01)  false;  (5.00000001 ; 5.00000003)  true
*/
    class Ex03CompareWithPrecisionClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert both numbers: ");
            //convert the console input to float
            float firstNum=float.Parse(Console.ReadLine());
            float secondNum = float.Parse(Console.ReadLine());
            //conditional operator ?: The same as the if-else construction, but shorter
            //the condition is before the ?. If it is evaluated to true the expression between ? and : is returned
            //if the condition is false, the expression after the : is returned
            Console.WriteLine( Math.Abs(firstNum - secondNum)<0.000001 ? true : false);
        }
    }
}
