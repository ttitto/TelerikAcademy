

namespace Ex07Conflicts
{
    /*Try to open two different data contexts and perform concurrent changes on the same records.
     What will happen at SaveChanges()? How to deal with it?*/
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EntityFrameworkDemo.Data;
    class Ex07ConflictsClass
    {
        static void Main()
        {
            using (var dbFirst = new NorthwindEntities())
            {
                using (var dbSecond = new NorthwindEntities())
                {
                    dbSecond.Categories.Where(c => c.CategoryName == "Production").FirstOrDefault().Description = "Dried fruit and bean";
                    dbFirst.Categories.Where(c => c.CategoryName == "Production").FirstOrDefault().Description = "Dried fruit and bean curd";
                    dbSecond.SaveChanges();
                    dbFirst.SaveChanges();
                }
            }
        }
    }
}
