using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12ASCII
{
    /*12. Find online more information about ASCII (American Standard Code for Information Interchange)
     * and write a program that prints the entire ASCII table of characters on the console.*/
    //http://www.ascii-code.com/

    class Ex12ASCIIClass
    {
        static void Main(string[] args)
        {
            //ASCII table contains 256 symbols in its extended variation
            //loop trough all the char numbers
            //Not all symbols will be displayed correctly, but it depends on the font of the console and is normal
            for (int i = 0; i < 255; i++)
            {
                Console.WriteLine((char)i);
            }
        }
    }
}
