using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PolynomialsExtension
{
   public class PolynomialsExtensionClass
    {
        static void Main(string[] args)
        {
        }
        public static double[] SubtractPolynomials(this double[] pol1, double[] pol2)
        {
            int length1 = pol1.Length;
            int length2 = pol2.Length;
            double[] biggerArr;
            int smaller;
            int bigger;
            double[] sum;
            if (length1 > length2)
            {
                sum = new double[length1];
                bigger = length1;
                biggerArr = pol1;
                smaller = length2;
            }
            else
            {
                sum = new double[length2];
                bigger = length2;
                biggerArr = pol2;
                smaller = length1;
            }
            for (int i = 0; i < smaller; i++)
            {
                sum[i] = pol1[i] - pol2[i];
            }
            if (length1 > length2)
            {
                for (int j = smaller; j < bigger; j++)
                {
                    sum[j] = biggerArr[j];
                }
            }
            else
            {
                for (int j = smaller; j < bigger; j++)
                {
                    sum[j] = -biggerArr[j];
                }

            }

            return sum;
        }

    }
}
