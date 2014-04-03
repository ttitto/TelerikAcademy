namespace Ex03CategoriesProductNames
{
    /*Write a program that retrieves from the Northwind database all product categories and the names of the
     * products in each category. Can you do this with a single SQL query (with table join)?*/
    using System;
    using System.Data.SqlClient;
    class Ex03CategoriesProductNamesClass
    {
        static void Main()
        {
            SqlConnection dbCon = new SqlConnection(
                "Server=(local)\\;Database=Northwind;Integrated Security=true");
            dbCon.Open();

            string command = "SELECT cat.CategoryName, p.ProductName FROM Categories cat JOIN Products p	ON cat.CategoryID=p.CategoryID GROUP BY cat.CategoryName,p.ProductName";
            SqlCommand dbCommand = new SqlCommand(command, dbCon);
            using(dbCon)
            {
                SqlDataReader reader = dbCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0} -- {1}",reader["CategoryName"], reader["ProductName"]);
                }
            }
        }
    }
}
