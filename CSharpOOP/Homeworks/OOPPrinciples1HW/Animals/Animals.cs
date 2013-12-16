using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    /*3. Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods.
     * Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface). 
     * Kittens and tomcats are cats. All animals are described by age, name and sex.
     * Kittens can be only female and tomcats can be only male. Each animal produces a specific sound. 
     * Create arrays of different kinds of animals and calculate the average age of each kind of animal 
     * using a static method (you may use LINQ).*/

    class AnimalsClass
    {
        static void Main(string[] args)
        {
           // Kitten myKit = new Kitten("Sani");
           // myKit.ProduceSound();
           // Tomcat myTom = new Tomcat("Tom");
           // Console.Write("A Tomcat is {0} and says ",myTom.Sex);
           // myTom.ProduceSound();
           // Animal myTom2 = new Tomcat("Tommy", 1);
           // Console.WriteLine(myTom2.Sex);
           // Cat myTom3 = new Tomcat("Tomcho", 2);
           // Console.WriteLine(myTom3.Sex);
           //// myTom3.Sex = Sex.Female; //Property is read-only
           // Console.WriteLine(myKit.Sex);
           // //myKit.Sex = Sex.Male; //Property is read-only

            Animal[] animals = new Animal[6] {
                new Cat("Matsa",2, Sex.Female),
                new Frog("Jabo",1,Sex.Male),
                new Cat("Toma",2,Sex.Male),
                new Cat ("Pisanka",4,Sex.Female),
                new Tomcat("Doncho",5,Sex.Female),
                new Frog("Jaria",5,Sex.Female) };
            foreach (var item in animals)
            {
                Console.Write("I am {0} and I say ",item.Name);
                item.ProduceSound();
            }
            Console.WriteLine();

            Console.WriteLine("Average age of Frogs is {0}", Animal.AverageAge(animals, "Frog"));
            Console.WriteLine("Average age of Cats is {0}", Animal.AverageAge(animals, "Cat"));
            Console.WriteLine("Average age of Tomcats is {0}", Animal.AverageAge(animals, "Tomcat"));
            Console.WriteLine("Average age of Animals is {0}", Animal.AverageAge(animals, "Animal"));
            Console.WriteLine();

            Animal[] animals1 = new Animal[8] {
                new Frog("Dani",3, Sex.Female),
                new Frog("Jabo",1,Sex.Male),
                new Cat("Toma",2,Sex.Male),
                new Tomcat("Kiril",3,Sex.Male),
                new Cat ("Pisanka",4,Sex.Female),
                new Kitten("Tatyana",4,Sex.Female),
                new Tomcat("Doncho",5,Sex.Male),
                new Frog("Jaria",5,Sex.Female) };

            Console.WriteLine("Average age of Frogs is {0}", Animal.AverageAge(animals1, "Frog"));
            Console.WriteLine("Average age of Cats is {0}", Animal.AverageAge(animals1, "Cat"));
            Console.WriteLine("Average age of Tomcats is {0}", Animal.AverageAge(animals1, "Tomcat"));
            Console.WriteLine("Average age of Animals is {0}", Animal.AverageAge(animals1, "Animal"));


        }
    }
}
