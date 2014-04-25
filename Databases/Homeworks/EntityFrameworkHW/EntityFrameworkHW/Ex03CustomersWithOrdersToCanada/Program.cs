namespace Ex03CustomersWithOrdersToCanada
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EntityFrameworkDemo.Data;
    using System.Data.Common;
    class Program
    {
        static void Main()
        {
            //foreach (var customer in FindCustomersWithOrdersToDestination(1997, "Canada"))
            //{
            //    Console.WriteLine(customer.CustomerID);
            //}
            //foreach (var customer in FindCustomersWithOrdersToDestinationNative(1997, "Canada"))
            //{
            //    Console.WriteLine(customer.CustomerID);
            //}
            //foreach (var order in SalesByPeriodAndDestination("Canada", new DateTime(1997, 01, 01), new DateTime(1997, 12, 31)))
            //{
            //    Console.WriteLine(order.OrderID);
            //}

            Console.WriteLine(AddOrder());
        }
        /*Ex03: Write a method that finds all customers who have orders made in 1997 and shipped to Canada.*/
        public static IEnumerable<Customer> FindCustomersWithOrdersToDestination(int year, string destination)
        {
            using (var dbContext = new NorthwindEntities())
            {
                var customers = dbContext.Orders.Where(o => o.ShipCountry == destination && o.ShippedDate.Value.Year == year)
                    .Join(dbContext.Customers, (o => o.CustomerID), (c => c.CustomerID), (o, c) => c)
                    .Distinct();

                return customers.ToList();
            }
        }
        /*Ex04: Implement previous by using native SQL query and executing it through the DbContext.*/
        public static IEnumerable<Customer> FindCustomersWithOrdersToDestinationNative(int year, string destination)
        {
            using (var db = new NorthwindEntities())
            {
                string query = @"SELECT DISTINCT c.CustomerID
      ,[CompanyName]
      ,[ContactName]
      ,[ContactTitle]
      ,[Address]
      ,[City]
      ,[Region]
      ,[PostalCode]
      ,[Country]
      ,[Phone]
      ,[Fax]
FROM Customers c  JOIN Orders o
	ON c.CustomerID=o.CustomerID
WHERE YEAR(o.ShippedDate)={0} AND o.ShipCountry={1}";
                object[] parameters = { year, destination };
                var customers = db.Database.SqlQuery<Customer>(query, parameters);

                return customers.ToList();
            }
        }

        /*Ex05: Write a method that finds all the sales by specified region and period (start / end dates).*/
        public static IEnumerable<Order> SalesByPeriodAndDestination(string region, DateTime startDate, DateTime endDate)
        {
            using (var dbContext = new NorthwindEntities())
            {
                var myOrders = dbContext.Orders.Where(o => o.ShipCountry == region && o.ShippedDate <= endDate && o.ShippedDate >= startDate).Select(o => o);
                return myOrders.ToList();
            }
        }

        /*Ex09: Create a method that places a new order in the Northwind database. The order should contain several 
         order items. Use transaction to ensure the data consistency.*/
        //http://www.devart.com/dotconnect/mysql/docs/transactionsef.html
        public static bool AddOrder()
        {
            using (var dbContext = new NorthwindEntities())
            {
                dbContext.Database.Connection.Open();
                using (DbTransaction tran = dbContext.Database.Connection.BeginTransaction())
                {
                    Order order = SplitOrder("VINUT", 5, new DateTime(2014, 05, 04), new DateTime(2014, 05, 04), new DateTime(2014, 05, 04), 2, 3.2500m, "Blondel père et fils", "Åkergatan 24", "Bräcke", "NM", "87110", "USA");

                    dbContext.Orders.Add(order);
                    dbContext.SaveChanges();
                    //if order inserted successfully in the DB, continue with orderdetails
                    if (dbContext.SaveChanges() > 0)
                    {
                        if (AddOrderDetails(order.OrderID) == null)
                        {
                            tran.Rollback();
                            return false;
                        }
                        else
                        {
                            tran.Commit();
                            return true;
                        }
                    }
                    //else Rollback the transaction
                    else
                    {
                        tran.Rollback();
                        return false;
                    }

                }

            }
        }

        private static Order SplitOrder(string customerID = null, int employeeID = 0, DateTime orderDate = default(DateTime), DateTime requiredDate = default(DateTime), DateTime shippedDate = default(DateTime), int shipVia = 0, decimal freight = 0m, string shipName = null, string shipAddress = null, string shipCity = null, string shipRegion = null, string shipPostalCode = null, string shipCountry = null)
        {
            return new Order
            {
                CustomerID = customerID,
                EmployeeID = employeeID,
                OrderDate = orderDate,
                RequiredDate = requiredDate,
                ShippedDate = shippedDate,
                ShipVia = shipVia,
                Freight = freight,
                ShipName = shipName,
                ShipAddress = shipAddress,
                ShipCity = shipCity,
                ShipRegion = shipRegion,
                ShipPostalCode = shipPostalCode,
                ShipCountry = shipCountry
            };
        }

        private static List<Order_Detail> AddOrderDetails(int orderId)
        {
            List<Order_Detail> orderDetails = new List<Order_Detail>();
            Console.WriteLine("Insert each order detail in a single row with values separated by \", \" or \n add \"end\" to finish");
            string cmd = Console.ReadLine();
            while (cmd != "end")
            {
                string[] singleOrderDetail = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                //If string doesnt have all necessary values then return null
                if (singleOrderDetail.Count() != 4)
                {
                    return null;
                }
                Order_Detail detail = new Order_Detail
                {
                    OrderID = orderId,
                    ProductID = int.Parse(singleOrderDetail[0]),
                    UnitPrice = decimal.Parse(singleOrderDetail[1]),
                    Quantity = short.Parse(singleOrderDetail[2]),
                    Discount = float.Parse(singleOrderDetail[3])
                };
                orderDetails.Add(detail);

            }
            if (orderDetails.Count() < 1)
            {
                return null;
            }
            else
            {
                return orderDetails;
            }
        }
    }
}
