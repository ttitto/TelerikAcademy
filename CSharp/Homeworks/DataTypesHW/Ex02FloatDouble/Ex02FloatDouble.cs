using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02FloatDouble
{
    /*
     2. Which of the following values can be assigned to a variable of type float and which to a
     * variable of type double: 34.567839023, 12.345, 8923.1234857, 3456.091?
     * */
    class Ex02FloatDoubleClass
    {
        static void Main(string[] args)
        {
            //Float holds a number with precision 7 digits after the decimal point
            //Double holds a number with precision 15-16 digits after the decimal point
            double a = 34.567839023;
            float b = 12.345f;
            float c = 8923.1234857f;
            float d = 3456.091f;
        }
    }
}
