using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolynomialsAddition
{
    public class PolynomialsAdditionClass
    {
        /*Write a method that adds two polynomials. Represent them as arrays of their coefficients as in the example below:
		x2 + 5 = 1x2 + 0x + 5 */
        static void Main(string[] args)
        {
            //Input data
            Console.Write("Insert the members count for the first polynomial: ");
            int polyn1Length = int.Parse(Console.ReadLine());
            Console.Write("Insert the members count for the second polynomial: ");
            int polyn2Length = int.Parse(Console.ReadLine());
            double[] polyn1 = new double[polyn1Length];
            double[] polyn2 = new double[polyn2Length];
            Console.WriteLine("Insert the members of the first polynomial, starting from the lowest power of the variable: ");
            for (int i = 0; i < polyn1Length; i++)
            {
                polyn1[i] = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Insert the members of the second polynomial, starting from the lowest power of the variable: ");
            for (int i = 0; i < polyn2Length; i++)
            {
                polyn2[i] = double.Parse(Console.ReadLine());
            }
            
            Console.WriteLine("The sum of the polynomials results to:");
            foreach (var item in AddPolynomials(polyn1,polyn2))
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
            Console.WriteLine("The subtraction of the polynomials results to:");
            foreach (var item in SubtractPolynomials(polyn1, polyn2))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("The multiplication of the polynomials results to:");
            foreach (var item in MultiplyPolynomials(polyn1, polyn2))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public static double[] AddPolynomials(double[] pol1, double[] pol2)
        {
            //There is a much shorter resolution to this method using List<> but array is required
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
                sum[i] = pol1[i] + pol2[i];
            }
            for (int j = smaller; j < bigger; j++)
            {
                sum[j] = biggerArr[j];
            }

            return sum;
        }
        public static double[] SubtractPolynomials( double[] pol1, double[] pol2)
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
        public static double[] MultiplyPolynomials(double[] pol1, double[] pol2)
        {
            
            double[] multPol=new double[pol1.Length+pol2.Length-1];
            for (int i = 0; i < pol1.Length; i++)
            {
                for (int j = 0; j < pol2.Length; j++)
                {
                    multPol[i + j] = multPol[i + j] + pol1[i] * pol2[j];
                }
            }
            return multPol;
        }
    }
}
