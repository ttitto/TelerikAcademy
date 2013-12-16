using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex10ConvergentSeries
{
    /*10. Write a program to calculate the sum (with accuracy of 0.001): 
      1 + 1/2 - 1/3 + 1/4 - 1/5 + ...*/
    class Ex10ConvergentSeriesClass
    {
        static void Main(string[] args)
        {
            float elementResult = 1;//holds the value of a member of the serie
            float sum = elementResult;
            uint counter = 2;//counts the number of the current iteration

            //until the addend get smaller than our precision requirement
            while (Math.Abs(elementResult) > 0.001)
            {
                elementResult = 1f / counter;
                //if the member's divisor is even, add the element result
                if (counter % 2 == 0)
                {
                    sum += elementResult;
                }
                //else subtract the element result
                else
                {
                    sum -= elementResult;
                }
                counter++;
            }

            Console.WriteLine("The limit of the serie is: {0:N3}", sum);
        }
    }
}
