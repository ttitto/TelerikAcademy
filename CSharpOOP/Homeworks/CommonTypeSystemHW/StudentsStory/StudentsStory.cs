using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsStory
{
    class StudentsStoryClass
    {
        static void Main(string[] args)
        {
            Student IvanPetrov = new Student("Ivan", "Todorov", "Petrov", "8012105421", Universities.NBU, Specialties.MathematicsAndInformatics);
            Student StoyanIvanov = new Student("Stoyan", "Todorov", "Ivanov", "7810126428", Universities.SU, Specialties.Physics);
            Student Stoyan = new Student("Stoyan", "Todorov", "Ivanov", "7810126428", Universities.SU, Specialties.Chemistry);
            if (IvanPetrov == StoyanIvanov) Console.WriteLine("true");
            else Console.WriteLine("false");
            if (Stoyan != StoyanIvanov) Console.WriteLine("true");
            else Console.WriteLine("false");
            Student ivan = (Student)IvanPetrov.Clone();

            ivan.SocialSN = "7810126428";
            Console.WriteLine(IvanPetrov.CompareTo(ivan));
            Console.WriteLine(IvanPetrov.CompareTo(Stoyan));           

            ivan.Faculty = Faculties.ChemistryFaculty;
            ivan.MiddleName = "Mihaylov";
            Console.WriteLine(IvanPetrov.MiddleName);

        }
    }
}
