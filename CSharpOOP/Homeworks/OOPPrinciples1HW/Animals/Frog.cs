using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    class Frog :Animal
    {
        public Frog(string name, uint age, Sex sex)
            :base(name, age, sex)
        {
        }
        public override void ProduceSound()
        {
            Console.WriteLine("Qua Qua Qua");
        }
    }
}
