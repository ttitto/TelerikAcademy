using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvergentSeries
{
    class ConvergentSeriesClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{0:0.00}", CalculateSerie(indx => 1 / Math.Pow(2, indx), 0.01));
            Console.WriteLine("{0:0.00}", CalculateSerie(indx => 1 / Factorial(indx), 0.01));
            Console.WriteLine("{0:0.00}", CalculateSerie(indx => Math.Pow(-1,indx+1)*1 / Math.Pow(2, indx), 0.01));
        }
        static double Factorial(int num)
        {
            double result = 1;
            if (num == 1 || num == 0) return 1;
            for (int i = num; i > 0; i--)
            {
                result *= i;
            }
            return result;
        }
        static double CalculateSerie(Func<int, double> function, double precision)
        {
            int cnt = 1;
            double previousSum;
            double sum = 0;
            do
            {
                previousSum = sum;
                sum += function(cnt);
                cnt++;
            } while (Math.Abs(sum - previousSum) > precision);

            return sum+1;
        }
    }
}
