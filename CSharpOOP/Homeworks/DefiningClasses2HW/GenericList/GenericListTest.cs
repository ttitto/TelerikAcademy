using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Matrices;

namespace GenericList
{
    class GenericListTest
    {
        static void Main(string[] args)
        {
            GenericList<int> mylist = new GenericList<int>(2);
            mylist.Add(1);
            mylist.Add(2);
            mylist.Add(3);
            mylist.Add(-33);
            mylist.Add(4);
            mylist.Add(5);

            mylist.RemoveAt(new int[] { 2, 4 });
            mylist.InsertAt(10, 2);
            Console.WriteLine(mylist.ToString());
            Console.WriteLine(mylist.Min<int>());
            Console.WriteLine(mylist.Max<int>());
            mylist.Clear(1);

            Matrix<int> mm1 = new Matrix<int>(5, 3);
            Matrix<int> mm2 = new Matrix<int>(3, 6);
            Console.WriteLine(mm2.ToString());
            // Matrix<char> mm4 = new Matrix<char>(2, 3);
            //Matrix<char> mm5 = new Matrix<char>(3, 2);
            // Matrix<int> multiple =new Matrix<int>(7,7);
            Matrix<int> multiple = mm1 * mm2;
            //   Matrix<char> mult = mm4 * mm5; //Runtime exception "Invalid Type"
        }
    }
}
