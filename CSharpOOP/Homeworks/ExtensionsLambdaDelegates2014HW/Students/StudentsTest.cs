using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class StudentsTestCla
    {
        static void Main(string[] args)
        {
            /*Task 9: Create a List<Student> with sample students. Select only the students that are from group number 2. 
             * Use LINQ query. Order the students by FirstName.*/
            List<Student> students = new List<Student>();
            students.Add(new Student("Peter", "Pavlov", "102406", 1));
            students.Add(new Student("Kosta", "Mihov", "076005", 1));
            students.Add(new Student("Max", "Mustermann", "064006", 1));
            students.Add(new Student("Damyan", "Damyanov", "032004", 1));
            students.Add(new Student("Desi", "Pavlova", "102206", 1));
            students.Add(new Student("Mihail", "Dimitrov", "122406", 2));
            students.Add(new Student("Acho", "Aliev", "099804", 2));
            students.Add(new Student("Todor", "Gradev", "802405", 2));
            students.Add(new Student("Peter", "Slavov", "094006", 3));
            students[1].Email = "ala@dir.bg";
            students[4].Email = "milka@abv.bg";
            students[6].Email = "misho@abv.bg";

            Console.WriteLine("The students from Group 2 are: ");
            var group2 = from stud in students
                         where stud.GroupNumber == 2
                         orderby stud.FName
                         select stud;
            foreach (var item in group2)
            {
                Console.WriteLine(item.ToString());
            }
            //TASK10: the same with ext.method
            Console.WriteLine("The students from Group 2 are: ");
            var newGroup2 = students.Where(st => st.GroupNumber == 2).OrderBy(st => st.FN).Select(st => st);
            foreach (var item in newGroup2)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();

            //TASK11: all with email in abv.bg
            Console.WriteLine("Students with emails in abv.bg");
            var abv = from stud in students
                      where stud.Email!=null
                      where stud.Email.Contains("abv.bg")
                      select stud;
            foreach (var item in abv)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
