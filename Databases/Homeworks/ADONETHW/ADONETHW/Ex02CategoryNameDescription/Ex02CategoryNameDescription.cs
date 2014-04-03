namespace Ex02CategoryNameDescription
{
    /*Write a program that retrieves the name and description of all categories in the Northwind DB.*/
    using System;
    using System.Data.SqlClient;
    class Ex02CategoryNameDescriptionClass
    {
        static void Main()
        {
            SqlConnection dbCon = new SqlConnection(
                "Server=(local)\\;Database=Northwind;Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand dbCommand = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbCon);

               SqlDataReader reader= dbCommand.ExecuteReader();
               while (reader.Read())
               {
                   Console.WriteLine("{0} - {1}",reader["CategoryName"],reader["Description"]);
               }
            }

        }
    }
}
