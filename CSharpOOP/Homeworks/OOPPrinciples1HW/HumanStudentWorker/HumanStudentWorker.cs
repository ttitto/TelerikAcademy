using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HumanStudentWorker
{
    /* Define abstract class Human with first name and last name. Define new class Student which 
     * is derived from Human and has new field – grade. Define class Worker derived from Human with 
     * new property WeekSalary and WorkHoursPerDay and method MoneyPerHour() that returns money earned 
     * by hour by the worker. Define the proper constructors and properties for this hierarchy. 
     * Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method). 
     * Initialize a list of 10 workers and sort them by money per hour in descending order. 
     * Merge the lists and sort them by first name and last name.*/
    class HumanStudentWorkerClass
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Todor", "Todorov", "A"));
            students.Add(new Student("Todor", "Ivanov", "B"));
            students.Add(new Student("Dimitar", "Georgiev", "B"));
            students.Add(new Student("Petar", "Blagoev", "C"));
            students.Add(new Student("Angel", "Bonev", "A"));
            students.Add(new Student("Kiril", "Rachev", "C"));
            students.Add(new Student("Vladimir", "Hristov", "A"));
            students.Add(new Student("Nedelina", "Stoyanova", "D"));
            students.Add(new Student("Dana", "Mineva", "C"));
            students.Add(new Student("Hristina", "Markova", "A"));
            //loops through the ordered list
            foreach (var item in students.OrderBy(s => s.Grade))
            {
                Console.WriteLine(item.FName + " " + item.LName + " grade: " + item.Grade);
            }
            Console.WriteLine();
            List<Worker> workers = new List<Worker>();
            workers.Add(new Worker("Dimitar", "Polyanov", 7.5f, 320.20m));
            workers.Add(new Worker("Rachko", "Kapitanov", 4.5f, 280.43m));
            workers.Add(new Worker("Venko", "Pavlov", 8.7f, 520.20m));
            workers.Add(new Worker("Yordan", "Parushev", 7.5f, 320.20m));
            workers.Add(new Worker("Donko", "Donev", 7.5f, 320.20m));
            workers.Add(new Worker("Hristo", "Arnaudov", 5.5f, 250m));
            workers.Add(new Worker("Lisichka", "Valkova", 5.5f, 220m));
            workers.Add(new Worker("Damyan", "Damyanov", 7.5f, 320.20m));
            workers.Add(new Worker("Velislava", "Kozunakova", 4f, 220.20m));
            workers.Add(new Worker("Kalinka", "Gurgulova", 4f, 160.20m));
            uint workDays = 5;
            //loops through the ordered list
            foreach (var item in workers.OrderByDescending(w => w.MoneyPerHour(workDays)))
            {
                Console.WriteLine(item.FName + " " + item.LName + " {0:N} lv/hour", item.MoneyPerHour(workDays));
            }

            Console.WriteLine();
            //merges the students and workers list in a humans list
            List<Human> humans = workers.Concat<Human>(students).ToList<Human>();
            //loops through the previously ordered by first name and then by last name humans list
            foreach (var item in humans.OrderBy(h => h.FName).ThenBy(ln => ln.LName))
            {
                Console.WriteLine(item.FName+" "+item.LName);
            }

        }
    }
}