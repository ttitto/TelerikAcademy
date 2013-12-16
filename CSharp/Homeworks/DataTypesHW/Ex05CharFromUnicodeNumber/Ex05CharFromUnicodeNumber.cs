using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05CharFromUnicodeNumber
{
  /*5. Declare a character variable and assign it with the symbol that has Unicode code 72. 
   * Hint: first use the Windows Calculator to find the hexadecimal representation of 72.*/
    class Ex05CharFromUnicodeNumberClass
    {
        static void Main(string[] args)
        {
            char myChar = (char)0x48; //explicit conversion
            Console.WriteLine(myChar);
        }
    }
}
