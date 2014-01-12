using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

class PermutationsGenerator
{
    static HashSet<string> myHash = new HashSet<string>();
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char[] arr = new char[n];
        for (int pos = 0; pos < n; pos++)
        {
            arr[pos] = char.Parse(Console.ReadLine());
        }

        GeneratePermutations(arr, 0, myHash);
        
        Console.WriteLine(myHash.Distinct().Count());
    }
    static int cnt = 0;
   // static StringBuilder sb = new StringBuilder();
    static void GeneratePermutations<T>(T[] arr, int k, HashSet<string> myHash)
    {

        if (k >= arr.Length)
        {
            bool isRepetitive = false;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i].Equals(arr[i + 1]))
                {
                    isRepetitive = true;
                    break;
                }
            }
            if (!isRepetitive)
            {
                //foreach (var item in arr)
                //{
                //    sb.Append(item);
                //}

                //if (!myHash.Contains(arr))
                //{
                    cnt++;
                    myHash.Add(String.Join("", arr));
                  //  Console.WriteLine(sb.ToString());
                //}

                //sb.Clear();
            }
        }
        else
        {
            GeneratePermutations(arr, k + 1, myHash);
            for (int i = k + 1; i < arr.Length; i++)
            {
                Swap(ref arr[k], ref arr[i]);
                GeneratePermutations(arr, k + 1, myHash);
                Swap(ref arr[k], ref arr[i]);
            }
        }
    }

    static void Swap<T>(ref T first, ref T second)
    {
        T oldFirst = first;
        first = second;
        second = oldFirst;
    }
}
