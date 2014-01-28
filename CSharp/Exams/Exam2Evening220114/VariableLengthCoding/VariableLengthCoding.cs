using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableLengthCoding
{
    class VariableLengthCodingClass
    {
        static StringBuilder binaryText = new StringBuilder();
        static Dictionary<string, char> charset = new Dictionary<string, char>();
        static StringBuilder message = new StringBuilder();
        static void Input()
        {
            int[] decNums = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(it => int.Parse(it)).ToArray();

            for (int i = 0; i < decNums.Length; i++)
            {
                binaryText.Append(Convert.ToString(decNums[i], 2));
            }

            int symbolCnt = int.Parse(Console.ReadLine());
            for (int i = 0; i < symbolCnt; i++)
            {
                string temp = Console.ReadLine();
                charset.Add(new String('1', int.Parse(temp.Substring(1))), temp[0]);
            }
        }


        static void Main(string[] args)
        {
            Input();

            var ones = binaryText.ToString().Split('0');
            foreach (var item in ones)
            {
                char currentChar;
                if (charset.TryGetValue(item, out currentChar))
                {
                    message.Append(currentChar);
                }
            }
            Console.WriteLine(message.ToString());
        }
    }
}
