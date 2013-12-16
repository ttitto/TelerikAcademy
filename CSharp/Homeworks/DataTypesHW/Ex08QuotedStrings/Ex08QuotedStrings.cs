using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex08QuotedStrings
{
    /*Declare two string variables and assign them with following value:
      The "use" of quotations causes difficulties.
	Do the above in two different ways: with and without using quoted strings.
*/
    class Ex08QuotedStringsClass
    {
        static void Main(string[] args)
        {
            string escaped = "The \"use\" of quotations causes difficulties.";
            string atSymbol = @"The ""use"" of quotations causes difficulties.";

            Console.WriteLine(escaped);
            Console.WriteLine(atSymbol);

        }
    }
}
