using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex09CopyRightTriangle
{
    /*9. Write a program that prints an isosceles triangle of 9 copyright symbols ©. 
     * Use Windows Character Map to find the Unicode code of the © symbol. 
     * Note: the © symbol may be displayed incorrectly.*/
    class Ex09CopyRightTriangleClass
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding("UTF-8"); //changes the encoding to UTF8 to show special symbols
            char copyright = (char)169;
            Console.WriteLine("   "+copyright );
            Console.WriteLine("  "+copyright+" "+copyright);
            Console.WriteLine(" " + copyright + " " + copyright+" "+copyright);
        }
    }
}
