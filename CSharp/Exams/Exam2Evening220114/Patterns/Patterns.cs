using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    class PatternsClass
    {
        static BigInteger sum = 0;
        static BigInteger max;
        static int[][] jagged;
        static int n;
        static bool hasPattern = false;
        static void Main(string[] args)
        {
            InputData();
            for (int row = 0; row < n - 2; row++)
            {
                for (int col = 0; col < n - 4; col++)
                {
                    if (TryCheckPattern(row, col, out sum))
                    {
                        hasPattern = true;
                        if (max < sum)
                        {
                            max = sum;
                            sum = 0;
                        }
                    }
                }
            }

            if (hasPattern)
            {
                Console.WriteLine("YES {0}", max);
            }
            else
            {
                Console.WriteLine("NO {0}", MainDiagonalSum());
            }
        }

        private static BigInteger MainDiagonalSum()
        {
            sum = 0;

            for (int row = 0; row < n; row++)
            {
                sum += jagged[row][row];
            }
            return sum;
        }
        static bool TryCheckPattern(int row, int col, out BigInteger sum)
        {
            if (jagged[row][col] + 6 == jagged[row + 2][col + 4])
            {
                // sum = jagged[row][col];
                sum = 0;
                //check first row of a pattern
                for (int i = 0; i < 3; i++)
                {
                    if (jagged[row][col + i] + 1 != jagged[row][col + i + 1])
                    {
                        sum = 0;
                        return false;
                    }
                    else
                    {
                        sum += jagged[row][col + i];
                    }
                }
                //check vertical part of the pattern
                for (int i = 0; i < 2; i++)
                {
                    if (jagged[row + i][col + 2] + 1 != jagged[row + i + 1][col + 2])
                    {
                        sum = 0;
                        return false;
                    }
                    else
                    {
                        sum += jagged[row + i + 1][col + 2];
                    }
                }
                //check second horizontal part
                for (int i = 0; i < 2; i++)
                {
                    if (jagged[row + 2][col + i + 2] + 1 != jagged[row + 2][col + i + 3])
                    {
                        sum = 0;
                        return false;
                    }
                    else
                    {
                        sum += jagged[row + 2][col + i + 3];
                    }
                }
                return true;
            }
            else
            {
                sum = 0;
                return false;
            }
        }
        static void InputData()
        {
            n = int.Parse(Console.ReadLine());
            jagged = new int[n][];
            for (int inner = 0; inner < n; inner++)
            {
                jagged[inner] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(item => int.Parse(item)).ToArray();
            }
        }
    }
}
