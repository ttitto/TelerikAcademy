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
    class ListItem<T>
    {
       
        public ListItem(T value)
        {
            this.Value = value;
            this.NextItem = null;
        }
        public ListItem(T value, ListItem<T> newItem)
            : this(value)
        {
            newItem.NextItem = this;
        }
        private T value;
        private ListItem<T> nextItem;

        public T Value
        {
            get { return this.value; }
            set
            {
                if (value == null) throw new ArgumentNullException("Value can not be null!");
                this.value = value;
            }
        }
        public ListItem<T> NextItem
        {
            get { return this.nextItem; }
            set
            {
                // if (value == null) throw new ArgumentNullException("NextItem can not be null!");
                this.nextItem = value;
            }
        }
    }

    class LinkedList<T>
    {

        public LinkedList()
        {
          
        }
        private ListItem<T> firstElement;
        public ListItem<T> FirstElement
        {
            get { return this.firstElement; }
            set
            {
                if (value == null) throw new ArgumentNullException("First element can not be null!");
                this.firstElement = value;
            }
        }
        /// <summary>
        /// Adds a new ListItem to the begin of the LinkedList
        /// </summary>
        /// <param name="newItem">the ListItem to be added</param>
        public void Add(ListItem<T> newItem)
        {
            if(this.FirstElement.Value==null)
            {
                this.FirstElement = newItem;
            }
            else
            {
            }

        }
    }
    class Ex11LinkedListClass
    {
        static void Main(string[] args)
        {
            ListItem<string> first = new ListItem<string>("1");
            LinkedList<string> myLinked = new LinkedList<string>();
           
            myLinked.Add(first);
            myLinked.Add(new ListItem<string>("2"));

        }
    }
}
