using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex11LinkedList
{
    /*11. Implement the data structure linked list. Define a class ListItem<T> that has two fields: value (of type T)
     * and NextItem (of type ListItem<T>). Define additionally a class LinkedList<T> with a single field FirstElement
     * (of type ListItem<T>).*/

    //Implemented AddFirst, AddLast, RemoveFirst, RemoveLast, RemoveFirst(T value), Count, Indexer

    public class LinkedList<T> where T : IComparable
    {
        private class ListItem
        {
            public ListItem(T value)
            {
                this.Value = value;
                this.NextItem = null;
            }
            public ListItem(T value, ListItem nextItem)
                : this(value)
            {
                this.NextItem = nextItem;
            }

            private T value;
            private ListItem nextItem;

            public T Value
            {
                get { return this.value; }
                set { this.value = value; }
            }
            public ListItem NextItem
            {
                get { return this.nextItem; }
                set { this.nextItem = value; }
            }
        }

        public LinkedList()
        {
            this.FirstItem = null;
        }

        private ListItem firstItem;
        private ListItem FirstItem
        {
            get { return this.firstItem; }
            set { this.firstItem = value; }
        }

        #region Methods
        public void AddFirst(T value)
        {
            if (this.FirstItem == null) this.FirstItem = new ListItem(value);
            else
            {
                this.FirstItem = new ListItem(value, this.FirstItem);
            }
        }
        public void AddLast(T value)
        {
            if (this.FirstItem == null) this.FirstItem = new ListItem(value);
            else
            {
                ListItem current = this.FirstItem;
                while (current.NextItem != null)
                {
                    current = current.NextItem;
                }
                current.NextItem = new ListItem(value);
            }
        }
        public void RemoveFirst()
        {
            if (this.firstItem != null) this.FirstItem = this.FirstItem.NextItem;
        }
        public void RemoveLast()
        {
            ListItem previous = null;
            ListItem current = null;
            if (this.FirstItem == null) return;
            else
            {
                current = this.FirstItem;
                while (current.NextItem != null)
                {
                    previous = current;
                    current = previous.NextItem;
                }
                previous.NextItem = null;
            }
        }
        public void RemoveFirst(T value)
        {
            ListItem previous = null;
            ListItem current = null;
            if (this.FirstItem == null) return;
            else
            {
                //Removes the first if is==value
                current = this.FirstItem;
                if (current.Value.CompareTo(value) == 0)
                {
                    this.FirstItem = this.FirstItem.NextItem;
                    return;
                }
                while (current.NextItem != null)
                {
                    previous = current;
                    current = current.NextItem;
                    if (current.Value.CompareTo(value) == 0)
                    {
                        break;
                    }
                }
                previous.NextItem = current.NextItem;
            }
        }
        /// <summary>
        /// Calculates the number of the values in the linked list
        /// </summary>
        /// <returns>integer as the number of the values in the linked list</returns>
        public int Count()
        {
            int count = 0;
            ListItem current = this.FirstItem;
            count = (current == null) ? 0 : 1;
            while (current.NextItem != null)
            {
                count++;
                current = current.NextItem;
            }
            return count;
        }
        //TODO: Implement the indexer
        //private ListItem this[int index]
        //{
        //    get { ;}
        //    set { ;}
        //}
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            ListItem current = this.FirstItem;
            while (current.NextItem != null)
            {
                sb.AppendFormat("[{0} {1}] ", current.Value, current.NextItem.Value);
                current = current.NextItem;
            }
            return sb.ToString();
        }
        #endregion
    }
    class Ex11LinkedListClass
    {
        static void Main(string[] args)
        {
            LinkedList<int> myLinked = new LinkedList<int>();
            myLinked.AddFirst(1);
            myLinked.AddFirst(2);
            myLinked.AddFirst(3);
            myLinked.AddLast(4);
            myLinked.AddLast(5);
            Console.WriteLine(myLinked.ToString());
            Console.WriteLine(myLinked.Count());
            myLinked.RemoveFirst(5);
            Console.WriteLine(myLinked.ToString());
            myLinked.RemoveFirst();
            Console.WriteLine(myLinked.ToString());
            myLinked.RemoveLast();
            Console.WriteLine(myLinked.ToString());
            Console.WriteLine(myLinked.Count());
        }
    }
}
