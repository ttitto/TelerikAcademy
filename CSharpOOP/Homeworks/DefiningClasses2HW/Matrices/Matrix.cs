using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrices
{
    /*8. Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 
9. Implement an indexer this[row, col] to access the inner matrix cells.
10. Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication.
     * Throw an exception when the operation cannot be performed. Implement the true operator (check for non-zero elements).*/
    /// <summary>
    /// Generic class holding Matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Matrix<T>
        where T : struct
    {
        private int dim1;
        private int dim2;
        private T[,] elements;

        /// <summary>
        /// Holds the size of the first dimension (rows) of the matrix.
        /// Can't be negative.
        /// </summary>
        public int Dim1
        {
            get { return dim1; }
            set
            {
                if (value <= 0) throw new IndexOutOfRangeException("Invalid range for the first dimension!");
                dim1 = value;
            }
        }
        /// <summary>
        /// Holds the size of the second dimension (columns) of the matrix
        /// Can't be negative.
        /// </summary>
        public int Dim2
        {
            get { return dim2; }
            set
            {
                if (value <= 0) throw new IndexOutOfRangeException("Invalid range for the second dimension!");
                dim2 = value;
            }
        }

        public Matrix(int dim1, int dim2)
        {
            if (this.IsNumericType<T>() == false) throw new ArgumentException("Invalid Type!");
            this.Dim1 = dim1;
            this.Dim2 = dim2;
            this.elements = new T[Dim1, Dim2];
        }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="indx1">Index for the rows</param>
        /// <param name="indx2">Index for the columns</param>
        /// <returns></returns>
        public T this[int indx1, int indx2]
        {
            get { return this.elements[indx1, indx2]; }
            set
            {
                if (indx1 < 0 || indx2 < 0 || indx1 >= this.Dim1 || indx2 >= this.Dim2)
                    throw new IndexOutOfRangeException("Index is outside the current Matrix dimensions!");
                this.elements[indx1, indx2] = value;
            }
        }
        //Checks if the used type is numeric
        private bool IsNumericType<T>()
        {
            if (typeof(T) != typeof(Int16) &&
                typeof(T) != typeof(Int32) &&
                typeof(T) != typeof(Int64) &&
                typeof(T) != typeof(Double) &&
                typeof(T) != typeof(Single) &&
                typeof(T) != typeof(Decimal) &&
                typeof(T) != typeof(UInt16) &&
                typeof(T) != typeof(UInt32) &&
                typeof(T) != typeof(UInt64))
            {
                return false;
            }
            else return true;

        }
        /// <summary>
        /// Returns a string with the elements of the matrix, ordered by rows and columns and separated with a ','
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // int maxLength = 0;
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < this.Dim1; row++)
            {
                for (int col = 0; col < this.Dim2; col++)
                {
                    //  int currLength=this[row,col].ToString().Length;
                    //  if(currLength>maxLength)maxLength=currLength;
                    if (col == this.Dim2 - 1) sb.Append(this[row, col].ToString());
                    else sb.Append(this[row, col].ToString() + ",");

                }
                if (row != this.Dim1 - 1) sb.Append('\n');

            }
            //sb.Replace(",",new String(' ',maxLength));
            return sb.ToString();
        }

        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.Dim1 != m2.Dim1 || m1.Dim2 != m2.Dim2) throw new InvalidOperationException("The Matrices are incompatible for addition!");
            else
            {
                Matrix<T> result = new Matrix<T>(m1.Dim1, m1.Dim2);
                for (int i = 0; i < m1.Dim1; i++)
                {
                    for (int j = 0; j < m1.Dim2; j++)
                    {
                        result = (dynamic)m1[i, j] + (dynamic)m2[i, j];
                    }
                }
                return result;
            }

        }

        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.Dim1 != m2.Dim1 || m1.Dim2 != m2.Dim2) throw new ArgumentException("The Matrices are incompatible for addition!");
            else
            {
                Matrix<T> result = new Matrix<T>(m1.Dim1, m1.Dim2);
                for (int i = 0; i < m1.Dim1; i++)
                {
                    for (int j = 0; j < m1.Dim2; j++)
                    {
                        result = (dynamic)m1[i, j] - (dynamic)m2[i, j];
                    }
                }
                return result;
            }

        }

        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.Dim2 != m2.Dim1) throw new ArgumentException("The matrices are incompatible for multiplication");
            else
            {
                Matrix<T> result = new Matrix<T>(m1.Dim1, m2.Dim2);
                for (int row1 = 0; row1 < m1.Dim1; row1++)
                {
                    for (int col2 = 0; col2 < m2.Dim2; col2++)
                    {
                        dynamic sum = 0;
                        for (int col1 = 0; col1 < m1.Dim2; col1++)
                        {
                            sum = sum + (dynamic)m1[row1, col1] * (dynamic)m2[col1, col2];
                        }
                        result[row1, col2] = sum;
                        sum = 0;
                    }
                }
                return result;
            }
        }

        public static bool operator true(Matrix<T> m)
        {
            for (int row = 0; row < m.Dim1; row++)
            {
                for (int col = 0; col < m.Dim2; col++)
                {
                    if (Comparer<T>.Equals(m[row, col], 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// returns false when 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static bool operator false(Matrix<T> m)
        {
            for (int row = 0; row < m.Dim1; row++)
            {
                for (int col = 0; col < m.Dim2; col++)
                {
                    if (!Comparer<T>.Equals(m[row, col], 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
