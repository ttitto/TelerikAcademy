using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodeAndEncrypt
{
    class EncodeAndEncryptClass
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string cypher = Console.ReadLine();
            Console.WriteLine(Encode(Encrypt(message, cypher) + cypher) + cypher.Length.ToString());
        }

        static string Encrypt(string message, string cypher)
        {
            int mLen = message.Length;
            int cLen = cypher.Length;
            StringBuilder sb = new StringBuilder();

            if (mLen >= cLen)
            {
                int indx = 0;
                for (int m = 0; m < mLen; m++)
                {
                    sb.Append(PairEncrypt(message[m], cypher[indx % cLen]));
                    indx++;
                }
            }
            else
            {
                int indx = 0;
                for (int c = 0; c < cLen; c++)
                {

                    sb.Append(PairEncrypt(message[indx % mLen], cypher[c]));
                    if (indx == mLen - 1)
                    {
                        message = sb.ToString();
                        sb.Clear();
                    }
                    indx++;
                }
                sb.Append(message.Substring(sb.Length));
            }

            return sb.ToString();
        }
        static string Encode(string toEncode)
        {
            StringBuilder total = new StringBuilder();
            StringBuilder current = new StringBuilder();
            int cnt = 0;

            toEncode += '*';
            for (int ch = 1; ch < toEncode.Length; ch++)
            {
                if (toEncode[ch] == toEncode[ch - 1])
                {
                    current.Append(toEncode[ch]);
                    cnt++;
                }
                else
                {
                    current.Append(toEncode[ch - 1]);
                    cnt++;

                    //Check if the current length is bigger than the cnt
                    //set counter to 0
                    if (current.Length > (cnt.ToString() + toEncode[ch - 1]).Length)
                    {
                        total.Append(cnt.ToString() + toEncode[ch - 1]);
                    }
                    else
                    {
                        total.Append(current.ToString());
                    }
                    cnt = 0;
                    current.Clear();
                    // total.Append(toEncode[ch-1]);
                }
            }
            return total.ToString();
        }

        static char PairEncrypt(char first, char second)
        {
            return (char)(((first - 65) ^ (second - 65)) + 65);
        }
    }
}
