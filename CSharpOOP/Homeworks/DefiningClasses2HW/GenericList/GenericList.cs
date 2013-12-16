// -----------------------------------------------------------------------
// <copyright file="GenericList.cs" company="ttitto">
// </copyright>
// -----------------------------------------------------------------------

namespace GenericList
{
    /*5. Write a generic class GenericList<T> that keeps a list of elements of some parametric type T. 
         * Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor.
         * Implement methods for adding element, accessing element by index, removing element by index, 
         * inserting element at given position, clearing the list, finding element by its value and ToString(). 
         * Check all input parameters to avoid accessing elements at invalid positions.
         * 
    6. Implement auto-grow functionality: when the internal array is full, 
         * create a new array of double size and move all elements to it.
    7. Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the  GenericList<T>. 
         * You may need to add a generic constraints for the type T.

    */
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
using System.Collections;

    /// <summary>
    ///Keeps an array of elements of a parametric type T
    /// </summary>
    public class GenericList<T> 
        where T: IComparable
    {
        #region Fields
        private T[] elements;
        private int busy;
        private int capacity;
        #endregion

        #region Properties
        /// <summary>
        /// Holds the capacity of the current GenericList<T> object. 
        /// Only positive values above 0 are allowed.
        /// </summary>
        public int Capacity
        {
            get { return this.capacity; }
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid value for GenericList capacity!");
                this.capacity = value;
            }
        }
        /// <summary>
        /// Holds the index of the first position in the elements array, that is not busy.
        /// Only positive values less than capacity-1 are allowed. Increasing of the capacity is only with the Add() Method allowed.
        /// </summary>
        public int Busy
        {
            get { return this.busy; }
            set
            {
                if (value < 0 || value > this.capacity) throw new IndexOutOfRangeException("Invalid position of the array element!");
                this.busy = value;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a GenericList<T> object with a given capacity. 
        /// All the elements are initialized with the default value for the type T.
        /// </summary>
        /// <param name="capacity"></param>
        public GenericList(int capacity)
        {
            this.Capacity = capacity;
            this.Busy = 0;
            this.elements = new T[Capacity];
        }
        #endregion

        #region Indexer
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return elements[index]; }
            set
            {
                if (index < 0 || index >= this.Capacity)
                    throw new IndexOutOfRangeException("Index is outside the current GenericList's capacity!");
                this.elements[index] = value;
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Adds an element at the first free position
        /// </summary>
        /// <param name="element"></param>
        public void Add(T element)
        {
            if (this.Busy >= this.Capacity) DoubleArraySize(this.Capacity);
            this.elements[this.Busy] = element;
            this.Busy++;
        }
        //Increases the size of the elements array to double of the current capacity
        private void DoubleArraySize(int oldCapacity)
        {
            this.elements = this.elements.Concat(new T[oldCapacity]).ToArray();
            this.Capacity = 2 * oldCapacity;
        }
        /// <summary>
        /// Removes the elements at the positions, given in the int[] indices
        /// </summary>
        /// <param name="indices"></param>
        public void RemoveAt(int[] indices)
        {
            T[] myNewElementsArray = new T[this.Capacity];
            int i = 0;//hold the position of the first array
            int j = 0;//holds the position of the new array
            while (i < this.Capacity)
            {
                if (indices.Contains(i))
                {
                    i++;
                    continue;
                }
                else
                {
                    myNewElementsArray[j] = this.elements[i];
                    j++;
                    i++;
                }
            }
            this.Busy = this.Busy - indices.Count();
            this.elements = myNewElementsArray;
        }
        /// <summary>
        /// Inserts an element at a given position.
        /// Increases the GenericList's capacity with 1;
        /// Positions bigger than the last busy position are not allowed.
        /// </summary>
        /// <param name="index"></param>
        public void InsertAt(T element, int index)
        {
            if (index < 0 || index > this.Busy) throw new IndexOutOfRangeException("The element can not be inserted at the given index!");
            T[] myNewArray = new T[this.Capacity + 1];
            int j = 0;
            for (int i = 0; i <= this.Capacity; i++)
            {
                if (i == index)
                {
                    myNewArray[j] = element;
                    j++;
                }
                else if (i < index)
                {
                    myNewArray[j] = this.elements[i];
                    j++;
                }
                else
                {
                    myNewArray[j] = this.elements[i - 1];
                    j++;
                }
            }
            this.elements = myNewArray;
            this.Busy++;
        }
        /// <summary>
        /// Resets the GenericList to a new GenericList with a given as parameter capacity.
        /// </summary>
        /// <param name="capacity">The capacity of the GenericList after clearing all the elements.        /// <param name="index"></param></param>
        public void Clear(int capacity)
        {
            this.elements = new T[capacity];
            this.Capacity = capacity;
            this.Busy = 0;
        }
        /// <summary>
        /// Finds the index of the next occurence of the element in the GenericList.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int Find(T element, int start, int count)
        {
            if (start + count >= this.Busy) return Array.IndexOf(this.elements, element, start, this.Busy-2);
            else return Array.IndexOf(this.elements, element, start, count);
        }
        /// <summary>
        /// Concatenates all the elements in the genericList, separated with a comma
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Busy; i++)
            {
                if (i==this.Busy-1)
                {
                    sb.Append(this.elements[i]);
                }
                else
	{
                    sb.Append(this.elements[i]+", ");
	}
            }
            return sb.ToString();
        }
        /// <summary>
        /// Returns the minimal value of the elements in the GenericList
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <returns></returns>
        public T Min<K>()
        {
            T result=this.elements[0];
            for (int i = 1; i < this.Busy; i++)
            {
                if (this.elements[i].CompareTo(this.elements[i - 1]) < 0) result = this.elements[i];
            }
            return result;
        }
        /// <summary>
        /// Returns the maximal value of the elements in the GenericList
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <returns></returns>
        public T Max<K>()
        {
            T result = this.elements[0];
            for (int i = 1; i < this.Busy; i++)
            {
                if (this.elements[i].CompareTo(this.elements[i - 1]) > 0) result = this.elements[i];
            }
            return result;
        }

        #endregion
    }
}
