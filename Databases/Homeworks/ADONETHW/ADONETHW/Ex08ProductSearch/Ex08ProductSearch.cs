

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
        private const string CONN_STRING = @"Server=(local)\;Database=Northwind;Integrated Security=true";
        private static SqlConnection dbConn = new SqlConnection(CONN_STRING);
        static void Main()
        {
            Console.Write("Insert searched substring: ");
            List<string> productNames = FindProducts(Console.ReadLine());
            productNames.ForEach(pr => Console.WriteLine(pr));

        }
        private static List<string> FindProducts(string searchString)
        {
            char escape = '!';
            searchString = searchString.Replace("%", escape + "%")
                                        .Replace("[", escape + "[")
                                        .Replace("]", escape + "]")
                                        .Replace("_", escape + "_").ToLower();
            if (string.IsNullOrEmpty(searchString) || string.IsNullOrWhiteSpace(searchString))
            {
                throw new ArgumentOutOfRangeException("Invalid symbols for the searched substring");
            }
            else
            {
                dbConn.Open();
                using (dbConn)
                {
                    SqlCommand dbCommand = new SqlCommand("SELECT  ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued  FROM Products  WHERE ProductName LIKE @searchString escape @escape", dbConn);
                    dbCommand.Parameters.AddWithValue("@searchString", '%' + searchString + '%');
                    dbCommand.Parameters.AddWithValue("@escape", escape);

                    SqlDataReader reader = dbCommand.ExecuteReader();
                    List<string> productNames = new List<string>();
                    while (reader.Read())
                    {
                        productNames.Add(string.Format("{0}", reader["ProductName"]));
                    }
                    return productNames;
                }
            }
        }
    }
}
