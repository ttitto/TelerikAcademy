using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace SQLConnectionDemo
{
    class SQLConnectionDemo
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(
                "Server=.\\TECHNOLOG_MSSQL; " +
              "Database=TelerikAcademy; " +
              "Integrated Security=true");

            con.Open();
            using (con)
            {
                SqlCommand command = new SqlCommand(@"Select FirstName, LastName, Salary FROM Employees", con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0} {1} {2}", reader["FirstName"], reader["LastName"],reader["Salary"]);
                }
            }
        }
    }
}
