using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02ReverseSequenceUsingStack
{
    /*02. Write a program that reads N integers from the console and reverses them using a stack. Use the Stack<int> class.*/
    class Ex02ReverseSequenceUsingStackClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert the number of integers N: ");
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                stack.Push(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ",stack.Pop());
            }
        }
    }
}
