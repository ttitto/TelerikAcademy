
namespace MySQLConnection
{
    using MySql.Data.MySqlClient;
    using System;
    class MySQLConnectionDemoClass
    {
        static void Main(string[] args)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Database=telerikacademy;Uid=root;Pwd=ttitto79;Encrypt=true;");
            con.Open();
            using (con)
            {
                MySqlCommand command = new MySqlCommand("SELECT FirstName, LastName FROM Employees",con);
                MySqlDataReader reader=command.ExecuteReader();
                while(reader.Read())
                {
                   Console.WriteLine("{0} {1}",reader["FirstName"],reader["LastName"]);
                }
            }

        }
    }
}
