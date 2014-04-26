

namespace Ex10SuppliersIncome
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EntityFrameworkDemo.Data;
    class Program
    {
        static void Main(string[] args)
        {
            using (var DBContext=new NorthwindEntities())
            {
              var suppliers=  DBContext.usp_SuppliersIncomeInTimeRange("Ma Maison", DateTime.Parse("1996-07-11 00:00:00.000"), DateTime.Parse("1996-07-11 00:00:00.000"));
              foreach (var supplier in suppliers)
              {
                  Console.WriteLine(supplier.CompanyName, supplier.Total_Price, supplier.OrderDate);
              }
            }
        }
    }
}
