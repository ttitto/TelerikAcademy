namespace Ex04AddProduct
{
    /*Write a method that adds a new product in the products table in the Northwind database. 
        Use a parameterized SQL command.*/
    using System;
    using System.Data.SqlClient;
    class Ex04AddProductClass
    {
        static void Main()
        {
            AddProduct("Na baba",5,4,"5 x 400g boxes",3.6m,19521,25,35,0);
        }

        private static void AddProduct(string ProductName, int SupplierID, int CategoryID, string QuantityPerUnit, decimal UnitPrice, int UnitsInStock, int UnitsOnOrder, int ReorderLevel, int Discontinued)
        {
            SqlConnection dbConn = new SqlConnection(
                "Server=(local)\\Technolog_MSSQL;Database=Northwind; Integrated Security=true");
            dbConn.Open();

            using (dbConn)
            {
                string command = "INSERT INTO Products(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) VALUES (@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)";
                SqlCommand dbCommand = new SqlCommand(command, dbConn);
                dbCommand.Parameters.AddWithValue("@ProductName", ProductName);
                dbCommand.Parameters.AddWithValue("@SupplierID",SupplierID);
                dbCommand.Parameters.AddWithValue("@CategoryID",CategoryID);
                dbCommand.Parameters.AddWithValue("@QuantityPerUnit",QuantityPerUnit);
                dbCommand.Parameters.AddWithValue("UnitPrice", UnitPrice);
                dbCommand.Parameters.AddWithValue("@UnitsInStock", UnitsInStock);
                dbCommand.Parameters.AddWithValue("@UnitsOnOrder",UnitsOnOrder);
                dbCommand.Parameters.AddWithValue("@ReorderLevel",ReorderLevel);
                dbCommand.Parameters.AddWithValue("@Discontinued",Discontinued);

                dbCommand.ExecuteNonQuery();
            }
        }

    }
}
