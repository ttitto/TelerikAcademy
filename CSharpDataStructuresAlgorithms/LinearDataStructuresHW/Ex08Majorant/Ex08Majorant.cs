using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex08Majorant
{
    /*08. * The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. Write a program 
     * to find the majorant of given array (if exists). 
  * Example: {2, 2, 3, 3, 2, 3, 4, 3, 3}  3*/
    class Ex08MajorantClass
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] arr = new string[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = Console.ReadLine();
            }

            Array.Sort(arr);

            int minCount = n / 2 + 1;
            int currOccurencies = 1;
            int maxOccurencies = 0;
            for (int i = 1; i < n; i++)
            {
                if (arr[i]==arr[i-1])
                {
                    currOccurencies++;
                }
                else
                {
                    currOccurencies = 1;
                }
                if (currOccurencies>maxOccurencies)
                {
                    maxOccurencies = currOccurencies;
                }
                if (maxOccurencies>=minCount)
                {
                    Console.WriteLine("There is a majorant: {0}",arr[i]);
                    break;
                }
                if((maxOccurencies+n-i)<=minCount)
                {
                    Console.WriteLine("There isn't any majorant!");
                    break;
                }
            }
        }
    }
}
