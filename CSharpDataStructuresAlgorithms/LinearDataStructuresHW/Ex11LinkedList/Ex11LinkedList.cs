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

    //Implemented AddFirst, AddLast, RemoveFirst, RemoveLast, Remove, Count, Indexer

    public class LinkedList<T>
    {
        private class ListItem<T>
        {
            public ListItem(T value)
            {
                this.Value = value;
                this.NextItem = null;
            }
            public ListItem(T value, ListItem<T> nextItem)
                :this(value)
            {
                this.NextItem = nextItem;
            }

            private T value;
            private ListItem<T> nextItem;

            public T Value
            {
                get { return this.value; }
                set { this.value = value; }
            }
            public ListItem<T> NextItem
            {
                get { return this.nextItem; }
                set { this.nextItem = value; }
            }
        }

        public LinkedList()
        {
            this.FirstItem = null;
        }

        private ListItem<T> firstItem;
        public ListItem<T> FirstItem
        {
            get { return this.firstItem; }
            set { this.firstItem = value; }
        }

    }
    class Ex11LinkedListClass
    {
        static void Main(string[] args)
        {
            

        }
    }
}
