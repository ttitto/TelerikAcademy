using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Students
{
    class Student
    {
        private string name;
        private string lastName;
        private int age;

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid age!");
                this.age = value;
            }
        }
        //The properties for Name and Lastname are in very rare conditions changeable (marriage, typing error etc)
        //but change is not impossible. That is why I left them read-write. 
        public string Name
        {
            get { return this.name; }
            set
            {
                if (!value.All(Char.IsLetter))
                    throw new ArgumentException("Name can not contain digits or other symbols than letters!");
                this.name = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public Student(string name, string lastName, int age)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Age = age;
        }
        public Student(string name, string lastName)
        {
            this.Name = name;
            this.LastName = lastName;
        }
        public override string ToString()
        {
            return this.Name + " " + this.LastName + ", " + this.Age;
        }
    }
}
