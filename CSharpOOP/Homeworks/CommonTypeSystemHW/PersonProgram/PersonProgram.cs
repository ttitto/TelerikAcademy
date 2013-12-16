using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonProgram
{
    class PersonProgramClass
    {
        static void Main(string[] args)
        {
            Person me = new Person("Dragan");
            Console.WriteLine( me.ToString());
            Person you = new Person("Petkan", 34);
            Console.WriteLine(you.ToString());
        }
    }
}
