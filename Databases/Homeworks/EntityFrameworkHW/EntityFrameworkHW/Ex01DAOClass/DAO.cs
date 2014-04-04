

namespace Ex01DAOClass
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EntityFrameworkDemo.Data;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
        public class DAO
    {
        public static void UpdateCustomerContact(string CustomerId, string newContactName)
        {
            using (var dbContext = new NorthwindEntities())
            {
                var customer = dbContext.Customers.Where(c => c.CustomerID == CustomerId);
                if (customer.Count() > 0)
                {
                    customer.FirstOrDefault().ContactName = newContactName;
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException("Customer with the given CustomerID doesn't exist!");
                }
            }
        }
        public static void InsertCustomer(string customerId, string companyName, string contactName = null, string contactTitle = null, string address = null, string city = null, string region = null, string postalCode = null, string country = null, string phone = null, string fax = null)
        {
            if (customerId.Length > 5)
            {
                throw new ArgumentException("Customer couldn't be added because the Customer ID can not be longer than 5 chars");
            }
            else
            {
                using (var dbContext = new NorthwindEntities())
                {
                    Customer customer = new Customer()
                    {
                        CustomerID = customerId,
                        CompanyName = companyName,
                        ContactName = contactName,
                        ContactTitle = contactTitle,
                        Address = address,
                        City = city,
                        Region = region,
                        PostalCode = postalCode,
                        Country = country,
                        Phone = phone,
                        Fax = fax
                    };
                    dbContext.Customers.Add(customer);
                    dbContext.SaveChanges();
                }
            }

        }
        public static void DeleteCustomer(string customerId)
        {
            using (var dbContext = new NorthwindEntities())
            {
                var customer = dbContext.Customers.Where(c => c.CustomerID == customerId).First();

                dbContext.Customers.Remove(customer);
                dbContext.SaveChanges();
            }
        }

    }

}
