namespace ToListExercise
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EFTelerikAcademy.Data;
    using System.Diagnostics;
    class ToListExerciseClass
    {
        static void Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Slow();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        private static void Slow()
        {
            using (var TAContext=new TelerikAcademyEntities())
            {
                List<Town> emp = TAContext.Employees.ToList()
                    .Select(e => e.Address).ToList()
                    .Select(a => a.Town).ToList().Where(t => t.Name.ToString()== "Sofia").ToList();

                emp.ForEach(e=>Console.WriteLine(e.Name));
                
            }
        }
        private static void Fast()
        {
            using (var TAContext = new TelerikAcademyEntities())
            {
                List<Town> emp = TAContext.Employees
                    .Select(e => e.Address)
                    .Select(a => a.Town).Where(t => t.Name.ToString() == "Sofia").ToList();

                emp.ForEach(e => Console.WriteLine(e.Name));

            }
        }
    }
}
