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
                indx = arr[i].Length % (arr.IndexOf(arr[i])+2);

                arr.Insert(indx, arr[i]);
            }
        }
        private static void Print(List<string> arr)
        {
            throw new NotImplementedException();
        }


    }
}
