using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonProgram
{
    /*Create a class Person with two fields – name and age. Age can be left unspecified (may contain null value. 
     * Override ToString() to display the information of a person and if age is not specified – to say so. 
     * Write a program to test this functionality.*/
    class Person
    {
        string name;
        int? age;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == null) throw new ArgumentNullException("Name can not be null!");
                this.name = value;
            }
        }
        public int? Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public Person(string name)
        {
            this.Name = name;
        }
        public Person(string name, int age)
            : this(name)
        {
            this.Age = age;
        }

        public override string ToString()
        {
            if (this.Age == null) { return this.Name + ", age not specified"; }
            else return this.Name + ", " + this.Age;
        }
    }
}
