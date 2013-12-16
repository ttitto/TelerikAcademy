using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace Animals
{
    class Animal : ISound
    {
        private uint age;
        private string name;
        private Sex sex;

        public uint Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public Sex Sex
        {
            get { return this.sex; }
           // set { this.sex = value; }
        }

        public Animal(string name, uint age, Sex sex)
        {
            this.Name = name;
            this.Age = age;
            this.sex = sex;
        }
        /// <summary>
        /// A method to be overriden by the inherits
        /// </summary>
        public virtual void ProduceSound()
        {
        }
        /// <summary>
        /// Calculates the average age of the animals from the same type. 
        /// It will consider ex. the Kitten or the Tomcat as Cats.
        /// </summary>
        /// <param name="animals">An array of Animal objects</param>
        /// <param name="type"> The type's name of the given animal as string.</param>
        /// <returns></returns>
        public static double AverageAge(Animal[] animals, string type)
        {
            // myType=new StackFrame().GetMethod().DeclaringType;
            // myType = MethodBase.GetCurrentMethod().DeclaringType;
            Type myType = Assembly.GetExecutingAssembly().GetType("Animals." + type);
            uint count = 0;
            double ageSum = 0;
            for (int i = 0; i < animals.Count(); i++)
            {
                if (myType.IsAssignableFrom(animals[i].GetType()))//Checks if my type is derived from the type of the animal
                {
                    ageSum += animals[i].Age;
                    count++;
                }
            }
            return ageSum / count;
        }

    }
}
