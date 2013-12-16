// -----------------------------------------------------------------------
// <copyright file="BitArray64.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace BitArrayExercise
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;

    /// <summary>
    /// Holds the bits of a ulong number as array of integers
    /// </summary>
    public class BitArray64 : IEnumerable<int>
    {
        int[] bits64 = new int[64];
        public IEnumerable<int> Bits64
        {
            get { return this.bits64.AsEnumerable<int>(); }
            set
            {
                if (value.Count() != 64 | value == null) throw new ArgumentException("Invalid array!");
                this.bits64 = value.ToArray();
            }
        }

        public BitArray64(ulong number)
        {
            this.Bits64 = this.ConvertToBitArray(number);
        }

        private IEnumerable<int> ConvertToBitArray(ulong number)
        {
            return Convert.ToString((long)number, 2).PadLeft(64, '0').Select(b => int.Parse(b.ToString())).AsEnumerable<int>();
        }
        //implement IEnumarable<int>

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                // yield return this.Bits64.ElementAt(i);//working with the property
                yield return this.bits64[i];//working with the field, it is save since foreach can not assign value
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="bit"></param>
        /// <returns></returns>
        public int this[int bit]
        {
            get { return this.bits64[bit]; }
            set { this.bits64[bit] = value; }
        }
        /// <summary>
        /// Compares two BitArray64 objects by comparing their elements each by each
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True if all  elements are the same</returns>
        public override bool Equals(object obj)
        {
            BitArray64 bitArray64 = obj as BitArray64;
            if (bitArray64 == null) return false;
            for (int ii = 0; ii < 64; ii++)
            {
                if (this.bits64[ii] != bitArray64.bits64[ii])
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
        /// <summary>
        /// Compares two BitArray64 objects by using the overriden .Equals() method
        /// </summary>
        /// <param name="ba1"></param>
        /// <param name="ba2"></param>
        /// <returns></returns>
        public static bool operator ==(BitArray64 ba1, BitArray64 ba2)
        {
            return BitArray64.Equals(ba1, ba2);
        }
        /// <summary>
        /// Compares two BitArray64 objects by using the overriden .Equals() method
        /// </summary>
        /// <param name="ba1"></param>
        /// <param name="ba2"></param>
        /// <returns></returns>
        public static bool operator !=(BitArray64 ba1, BitArray64 ba2)
        {
            return !BitArray64.Equals(ba1, ba2);
        }
    }

}
