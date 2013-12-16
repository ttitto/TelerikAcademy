using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04ThirdDigitCheck
{
    /*4. Write an expression that checks for given integer if its third digit (right-to-left) is 7.
     * E. g. 1732  true.*/
    class Ex04ThirdDigitCheckClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert an integer: ");
            string myStr=Console.ReadLine();
            //As we need only an expression but not a working program I will not check for an invalid input
            //first takes a substring with length 1  starting from the third position counting from right to left
            bool thirdIs7 = myStr.Substring(myStr.Length - 3, 1) == "7";
            Console.WriteLine(thirdIs7);
        }
    }
}
