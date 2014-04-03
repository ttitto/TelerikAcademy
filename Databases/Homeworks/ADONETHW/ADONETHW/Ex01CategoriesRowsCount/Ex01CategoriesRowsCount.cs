namespace Ex01CategoriesRowsCount
{
    /*Write a program that retrieves from the Northwind sample database in MS SQL Server the number of  rows in the Categories table.*/
    using System;
    using System.Data.SqlClient;

    class Ex01CategoriesRowsCountClass
    {
        static void Main()
        {
            SqlConnection dbCon = new SqlConnection(
                "Server=.\\;Database=Northwind;Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand dbCommand = new SqlCommand(
                    "SELECT COUNT(*) FROM Categories",dbCon);
                int categoriesCount = (int)dbCommand.ExecuteScalar();
                Console.WriteLine(categoriesCount);
            }
        }
    }
}
