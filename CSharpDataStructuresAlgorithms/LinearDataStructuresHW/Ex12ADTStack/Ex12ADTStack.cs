using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12ADTStack
{
    /*12. Implement the ADT stack as auto-resizable array. Resize the capacity on demand (when no space is available to add / 
     * insert a new element).*/
    class Ex12ADTStackClass
    {
        public class Stack<T> where T : IComparable
        {
            public Stack()
            {
                this.StackArr = new T[INITIAL];
                this.position = -1;
            }

            private const int INITIAL = 10;
            private int capacity = INITIAL;
            private int position;
            private T[] stackArr;

            public T[] StackArr
            {
                get { return this.stackArr; }
                set
                {
                    if (value == null) throw new ArgumentNullException("The stack array can not be null!");
                    this.stackArr = value;
                }
            }
            public int Length
            {
                get { return this.position; }
                set { this.position = value; }
            }
            public T this[int index]
            {
                get
                {
                    return this.StackArr[index];
                }
                set
                {
                    if (value == null) throw new ArgumentNullException("The value of the indexer can not be null!");
                    this.StackArr[index] = value;
                }
            }
            public void Push(T element)
            {
                if (this.position == this.capacity - 1) ResizeInnerArray(this.StackArr);
                this.StackArr[++this.position] = element;
            }
            public T Peek()
            {
                return this.StackArr[position];
            }
            public T Pop()
            {
                return this.StackArr[position--];
            }
            private void ResizeInnerArray(T[] arr)
            {
                this.capacity = arr.Length * 2;//new capacity
                T[] copy = new T[this.capacity];
                arr.CopyTo(copy, 0);
                this.StackArr = copy;
            }
        }
        static void Main(string[] args)
        {
            Stack<int> myStack = new Stack<int>();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);
            myStack.Push(5);
            myStack.Push(6);
            myStack.Push(7);
            myStack.Push(8);
            myStack.Push(9);
            myStack.Push(10);
            myStack.Push(11);

            for (int i = 0; i <= myStack.Length; i++)
            {
                Console.Write("{0} ", myStack[i]);
            }
            Console.WriteLine();

            myStack.Pop();
            myStack.Pop();
            for (int i = 0; i <= myStack.Length; i++)
            {
                Console.Write("{0} ", myStack[i]);
            }
            Console.WriteLine();

            myStack.Peek();
            for (int i = 0; i <= myStack.Length; i++)
            {
                Console.Write("{0} ", myStack[i]);
            }
            Console.WriteLine();
        }
    }
}
