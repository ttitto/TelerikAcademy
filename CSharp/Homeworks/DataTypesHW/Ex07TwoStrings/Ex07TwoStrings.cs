using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex07TwoStrings
{
    /*7. Declare two string variables and assign them with “Hello” and “World”. Declare an object variable and assign it 
     * with the concatenation of the first two variables (mind adding an interval). Declare a third string variable 
     * and initialize it with the value of the object variable (you should perform type casting).*/
    class Ex07TwoStringsClass
    {
        static void Main(string[] args)
        {
            string hello = "Hello";
            string world = "World";
            object obj = hello +" "+ world;
            string convertedObj = (string)obj;
            Console.WriteLine(convertedObj);
        }
    }
}
