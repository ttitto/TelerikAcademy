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

            students[0].Tel = "044/667515";
            students[3].Tel = "0885/368157";
            students[4].Tel = "0887/658246";
            students[6].Tel = "02/2351010";
            students[2].Tel = "02/8921234";
            students[8].Tel = "02/6584567";

            students[2].Marks = new List<int>() { 2, 5, 6, 4, 3, 3, 5, 5, 2 }.AsEnumerable();
            students[3].Marks = new List<int>() { 2, 5, 6, 4, 3, 3, 5, 5, 3 }.AsEnumerable();
            students[4].Marks = new List<int>() { 3, 5, 4, 4, 3, 3, 5, 5, 4 }.AsEnumerable();
            students[5].Marks = new List<int>() { 2, 5, 6, 4, 3, 3, 5, 5, 5 }.AsEnumerable();
            students[7].Marks = new List<int>() { 3, 5, 6, 4, 3, 3, 5, 5, 6 }.AsEnumerable();

            students[2].Group = new Group(1, "Physics");
            students[3].Group = new Group(1, "Mathematics");
            students[4].Group = new Group(1, "Physics");
            students[5].Group = new Group(2, "Mathematics");
            students[7].Group = new Group(2, "History");


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
                      where stud.Email != null
                      where stud.Email.Contains("abv.bg")
                      select stud;
            foreach (var item in abv)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();

            //TASK12: all phones in Sofia
            Console.WriteLine("All students with phones in Sofia:");
            var sofiaPhones = from stud in students
                              where stud.Tel != null
                              where stud.Tel.Contains('/')
                              where stud.Tel.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[0] == "02"
                              select stud;

            foreach (var item in sofiaPhones)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();

            //TASK13: anonymous class
            Console.WriteLine("Students with at least one excellent note: ");
            var excellentStudents = from stud in students
                                    where stud.Marks.Contains(6)
                                    select new { Fullname = stud.FName + " " + stud.LName, Marks = stud.Marks };
            foreach (var item in excellentStudents)
            {
                Console.WriteLine(item.Fullname + ": " + string.Join(", ", item.Marks));
            }
            Console.WriteLine();

            //TASK14: two low notes
            Console.WriteLine("Students with two notes 2: ");
            var lowStudents = students.Where(st => st.Marks.Count(m => m == 2) == 2);

            foreach (var item in lowStudents)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();

            //TASK15: all marks of enrolled students in 2006
            Console.WriteLine("All the marks of the students that enrolled in 2006: ");
            var students2006 = from stud in students
                               where stud.FN.Substring(4, 2) == "06"
                               select stud.Marks;

            foreach (var item in students2006)
            {
                Console.Write(string.Join(", ", item));
                Console.WriteLine();
            }

            //TASK16: Extract all students from the Mathematics department
            Console.WriteLine("All students from the Mathematics department: ");
            var mathStudents = from stud in students
                               where stud.Group != null
                               where stud.Group.DepartmentName == "Mathematics"
                               select stud;

            foreach (var item in mathStudents)
            {
                Console.WriteLine(string.Join("\n", item.ToString()));
            }
            Console.WriteLine();

            //TASK18: All students. grouped by DepartmentName
            Console.WriteLine("All students grouped by department name (LINQ): ");

            var grouped = from stud in students
                          where stud.Group != null
                          group stud by stud.Group.DepartmentName into g
                          select new { DepGroup = g.Key, Students = g };

            foreach (var item in grouped)
            {
                Console.WriteLine(item.DepGroup);
                foreach (var st in item.Students)
                {
                    Console.WriteLine(" " + st.ToString());
                }
            }
            Console.WriteLine();
            //TASK19:
            Console.WriteLine("All students grouped by department name (EXT METHODS): ");
            var groupedExt = students.Where(st => st.Group != null).GroupBy(st => st.Group.DepartmentName).Select(st => st);
            foreach (var item in groupedExt)
            {
                Console.WriteLine(item.Key);
                foreach (var st in item)
                {
                    Console.WriteLine("  " + st.ToString());
                }
            }

        }
    }
}
