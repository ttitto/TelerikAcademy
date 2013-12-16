using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncodeDecodeString
{/*07.Write a program that encodes and decodes a string using given encryption key (cipher).
  * The key consists of a sequence of characters. The encoding/decoding is done by performing 
  * XOR (exclusive or) operation over the first letter of the string with the first of the key, 
  * the second – with the second, etc. When the last key character is reached, the next is the first.*/
    class EncodeDecodeStringClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert the string to be encoded: ");
            string text = Console.ReadLine();
            Console.Write("Insert the key: ");
            string key = Console.ReadLine();
            string encoded=EncodeDecodeString(text,key);
            Console.WriteLine("The encoded string looks like: {0}",encoded);
            Console.WriteLine("The decoded string looks like: {0}", EncodeDecodeString(encoded, key));
           
        }
        private static string EncodeDecodeString(string myStr, string myKey)
        {
            string encoded;
            StringBuilder sb = new StringBuilder();
            int i, j;
            for ( i = 0, j=0; i < myStr.Length; i++,j++)
            {
                sb.Append((char)(myStr[i] ^ myKey[j]));
                if(j==myKey.Length-1)j=-1;
            }
            encoded = sb.ToString();
            return encoded;
        }
    }
}
