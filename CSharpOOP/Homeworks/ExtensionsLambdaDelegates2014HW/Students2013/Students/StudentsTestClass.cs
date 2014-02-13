using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Students
{
    /*3. Write a method that from a given array of students finds all students whose first name is before 
     * its last name alphabetically. Use LINQ query operators.
      4. Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
      5. Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by
     * first name and last name in descending order. Rewrite the same with LINQ.*/
    class StudentsTestClass
    {
        static void Main(string[] args)
        {
            List<Student> myStudentList = new List<Student>(){
                new Student("Pesho","Petkov",19),
                new Student("Ivan","Tsvetkov",28),
                new Student("Kalina","Ivanova",24),
                new Student("Tatyana","Dimitrova",21),
                new Student("Kalina","Georgieva",21)};

            Console.WriteLine("All students: ");
            myStudentList.ForEach(s => Console.WriteLine(s.ToString()));
            Console.WriteLine();

            Console.WriteLine("Students whose first name is before their last name alphabetically: ");
            foreach (var item in FirstNameBefore(myStudentList))
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("Students whose age is between 18 and 24 years: ");
            foreach (var item in AgeBetween1824(myStudentList))
            {
                Console.WriteLine(item.Name + " " + item.LastName);
            }
            Console.WriteLine();
            //Ordered Descending
            Console.WriteLine("All students ordered descending by Names, then by LastNames, using Extension methods");
            OrderByExtensions(myStudentList);
            Console.WriteLine();

            Console.WriteLine("All students ordered descending by Names, then by LastNames, using LINQ");
            OrderByLinq(myStudentList);
        }
        static IEnumerable<Student> FirstNameBefore(List<Student> myStudentList)
        {
            var filtered = from st in myStudentList
                           where st.Name.CompareTo(st.LastName) <= 0
                           select st;
            return filtered;
        }

        static IEnumerable<Student> AgeBetween1824(List<Student> myStudentList)
        {
            var filtered = from st in myStudentList
                           where st.Age > 18 && st.Age < 24
                           select new Student(st.Name, st.LastName);
            return filtered;
        }

        static void OrderByExtensions(List<Student> myStudentList)
        {
            var sorted = myStudentList.OrderByDescending((s) => s.Name).ThenByDescending(s => s.LastName).ToList();
            sorted.ForEach(s => Console.WriteLine(s.ToString()));
        }

        static void OrderByLinq(List<Student> myStudentList)
        {
            var sorted = from st in myStudentList
                         orderby st.Name descending, st.LastName descending
                         select st;
            foreach (var item in sorted)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
