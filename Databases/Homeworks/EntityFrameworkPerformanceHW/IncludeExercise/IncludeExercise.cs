
namespace IncludeExercise
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EFTelerikAcademy.Data;
    using System.Diagnostics;
    class IncludeExerciseClass
    {
        static void Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            SelectWithoutInclude();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        private static void SelectWithoutInclude()
        {
            using (var TAContext = new TelerikAcademyEntities())
            {
             
                foreach (var emp in TAContext.Employees)
                {
                    Console.WriteLine("{0}, {1}, {2}", emp.LastName, emp.Department.Name, emp.Address.Town.Name);
                }
            }
        }
        private static void SelectWithInclude()
        {
            using (var TAContext = new TelerikAcademyEntities())
            {
                
                foreach (var emp in TAContext.Employees.Include("Department").Include("Address"))
                {
                    Console.WriteLine("{0}, {1}, {2}", emp.LastName, emp.Department.Name, emp.Address.Town.Name);
                }
            }
        }
    }
}
