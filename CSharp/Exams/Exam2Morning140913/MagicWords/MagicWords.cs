using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWords
{
    class MagicWordsClass
    {
        static int n = 0;
        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            List<string> arr = new List<string>(n);
            for (int ii = 0; ii < n; ii++)
            {
                arr.Add(Console.ReadLine());
            }

            Reorder(arr);
            Print(arr);
        }
        private static void Reorder(List<string> arr)
        {
            int indx = 0;
            for (int i = 0; i < n; i++)
            {
                string item = arr[i];
                indx = arr[i].Length % (arr.Count + 1);

                if (indx >= i)
                {
                    arr.Insert(indx, item);
                    //arr.Remove(arr[i]);
                    arr.RemoveAt(i);
                }
                else
                {
                    arr.RemoveAt(i);
                    //arr.Remove(arr[i]);
                    arr.Insert(indx, item);
                }
            }
        }
        private static void Print(List<string> arr)
        {
            StringBuilder sb = new StringBuilder();
            int maxLength = arr.Select(w => w.Length).Max();
            for (int l = 0; l < maxLength; l++)
            {
                for (int w = 0; w < arr.Count; w++)
                {
                    if (arr[w].Length > l)
                    {
                        sb.Append(arr[w][l]);
                    }
                }
            }
            Console.WriteLine(sb.ToString());
        }


    }
}
