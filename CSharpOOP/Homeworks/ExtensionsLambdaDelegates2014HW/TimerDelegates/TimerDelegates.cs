using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AllDivisibleBy7And3;

namespace TimerDelegates
{
    /*7. Using delegates write a class Timer that can execute certain method at each t seconds.*/

    //I tried to subscribe a method with parameters to my delegate but I could'n. 
    //That is why I call a method without parameters that call another method with parameters

    public class TimerDelegatesClass
    {
        static int[] myArr = new int[10] { 3, 8, 21, 54, 49, 69, -42, 64, 42, 46 };

        static void Main(string[] args)
        {
            Timer timer = new Timer(2111, MethodWithoutParameters);
            Timer timer1 = new Timer(4000, SecondMethodWithoutParameters);
        }

        public static void MethodWithoutParameters()
        {
            AllDivisibleBy7And3Class.PrintUsingExtensions(myArr);//Method with parameters
        }
        public static void SecondMethodWithoutParameters()
        {
            myArr[2] = 53;
            MethodWithParameters(myArr);
        }
        public static void MethodWithParameters(int[] arr)
        {
            int[] myNew = arr.Take(5).ToArray();
            foreach (var item in myNew)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }

}
