

namespace EntityFrameworkDemo.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EntityFrameworkDemo.Data;
    class Program
    {
        static void Main()
        {
            using (var db = new NorthwindEntities())
            {

                foreach (var customer in db.Customers)
                {
                    Console.WriteLine(customer.CompanyName);
                }
            }
        }
    }
}
