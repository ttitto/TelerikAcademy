using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompleteWithAsterix
{/*06.Write a program that reads from the console a string of maximum 20 characters. 
  * If the length of the string is less than 20, the rest of the characters should be filled with '*'.
  * Print the result string into the console.*/
    class CompleteWithAsterixClass
    {
        static void Main(string[] args)
        {
            try
            {

                Console.Write("Insert a string with maximum 20 chars: ");
                string myStr = Console.ReadLine();
                if (myStr.Length < 20)
                {
                    myStr = new string(myStr.PadRight(20, '*').ToString().ToArray());
                }
                else throw new ArgumentException("The maximal length of the input is 20 characters.");
                Console.WriteLine(myStr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
