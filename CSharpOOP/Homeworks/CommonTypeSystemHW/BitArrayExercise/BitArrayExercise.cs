using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace BitArrayExercise
{
    /*5. Define a class BitArray64 to hold 64 bit values inside an ulong value. 
     * Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.*/
    class BitArrayExerciseClass
    {
        static void Main(string[] args)
        {
            //testing constructor
            BitArray64 myArr = new BitArray64(29015804678465);
            BitArray64 secArr = new BitArray64(654686519984651618);
            BitArray64 sameRef = myArr;
            BitArray64 sameVal = new BitArray64(29015804678465);
            //testing indexer
            Console.WriteLine(myArr[57].ToString());
            //testing IEnumerable<int>
            foreach (var item in myArr)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            //testing comparison
            Console.WriteLine(myArr.Equals(sameRef));
            Console.WriteLine(myArr.Equals(sameVal));
            Console.WriteLine(myArr.Equals(secArr));
            Console.WriteLine(sameRef.Equals(sameVal));
            Console.WriteLine();
            Console.WriteLine(myArr==sameRef);
            Console.WriteLine(myArr==sameVal);
            Console.WriteLine(myArr==secArr);
            Console.WriteLine(sameRef==sameVal);
            Console.WriteLine();
            Console.WriteLine(myArr != sameRef);
            Console.WriteLine(myArr != sameVal);
            Console.WriteLine(myArr != secArr);
            Console.WriteLine(sameRef != sameVal);


        }
    }
}
