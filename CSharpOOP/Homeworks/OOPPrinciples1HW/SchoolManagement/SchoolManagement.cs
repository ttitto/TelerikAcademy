using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolManagement
{
    /*1. We are given a school. In the school there are classes of students. Each class has a set of teachers. 
     * Each teacher teaches a set of disciplines. Students have name and unique class number. 
     * Classes have unique text identifier. Teachers have name. Disciplines have name, number of lectures and number of exercises. 
     * Both teachers and students are people. Students, classes, teachers and disciplines could have optional comments (free text block).
	Your task is to identify the classes (in terms of  OOP) and their attributes and operations, 
     * encapsulate their fields, define the class hierarchy and create a class diagram with Visual Studio.*/
    class SchoolManagement
    {
        static void Main(string[] args)
        {
            Discipline mathematics = new Discipline("Mathematics", 20, 240);
            Discipline history = new Discipline("History", 5, 60);
            Discipline geography = new Discipline("Geography", 5, 60);
            Discipline french = new Discipline("French", 10, 130);

            Teacher ivanov = new Teacher("Ivanov", new List<Discipline> { history, geography });
            Teacher dimitrova = new Teacher("Dimitrova", new List<Discipline> { french });
            Teacher penkov = new Teacher("Penkov", new List<Discipline> { mathematics });


            Student pesho = new Student("Petar Dimitrov", 15);
            Student ivan = new Student("Ivan Ivanov", 12);
           // ivan.Number = uint.Parse(Console.ReadLine());

            SchoolClass a1 = new SchoolClass("1A", new Dictionary<uint, Student> { 
            { pesho.Number, pesho }, { ivan.Number, ivan },{1,new Student("Haralampi Djambazov",1)} },
                new List<Teacher> { ivanov, dimitrova, penkov });
            // a1.Students.Add(...) is impossible, because Students is returned as IEnumerable<>
            a1.AddStudent(new Student("Marijka Marinova", 13));//if we change 13 to 12 or 15 an exception is thrown 
            //because of duplicated student's number
            School smirnenski = new School(new List<SchoolClass> { a1 });

            a1.AddComment(String.Format("The only class in this village has {0} students:", a1.Students.Count()));
            a1.ShowComment();
            foreach (var item in a1.Students.OrderBy(k=>k.Number))
            {
                Console.WriteLine("number: {0,2},names; {1}", item.Number, item.Name);
            }
            SchoolClass b1 = new SchoolClass("b1", new Dictionary<uint, Student> { 
            { pesho.Number, pesho }, { ivan.Number, ivan },{1,new Student("Haralampi Djambazov",1)} },
                new List<Teacher> { ivanov, dimitrova, penkov });
            smirnenski.AddClass(b1);
           // smirnenski.AddClass(a1);//throws ArgumentException



        }
    }
}
