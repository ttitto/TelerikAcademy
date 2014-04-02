

namespace Ex08ProductSearch
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    /*Write a program that reads a string from the console and finds all products that contain this string. Ensure you handle correctly characters like ', %, ", \ and _.*/
    class Ex08ProductSearchClass
    {
        static void Main()
        {
            Console.Write("Insert searched substring: ");
            string searchString = Console.ReadLine().Replace(@"\",@"[\]").Replace(@"%",@"[%]").Replace(@"_",@"[_]");
            SqlConnection dbConn = new SqlConnection("Server=(local)\\Technolog_MSSQL;Database=Northwind;Integrated Security=true");
            dbConn.Open();
            using (dbConn)
            {
                SqlCommand dbCommand=new SqlCommand("SELECT  ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued  FROM Products  WHERE ProductName LIKE @searchString", dbConn);
                SqlParameter searchParam=new SqlParameter("@searchString",searchString);
                dbCommand.Parameters.Add(searchParam);
                SqlDataReader reader = dbCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0}", reader["ProductName"]);
                }
            }
        }
    }
}
