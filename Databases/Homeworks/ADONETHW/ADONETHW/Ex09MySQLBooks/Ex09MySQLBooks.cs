

namespace Ex09MySQLBooks
{
    /*Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL) + MySQL Workbench GUI administration tool . 
     * Create a MySQL database to store Books (title, author, publish date and ISBN). Write methods for listing all books, 
     * finding a book by name and adding a book.*/
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MySql.Data.MySqlClient;

    class Ex09MySQLBooksClass
    {
        private  const string CONN_STRING = "Server=localhost;Database=MyDB;Uid=root;Pwd=ttitto79;";
        private static MySqlConnection dbConn = new MySqlConnection(CONN_STRING);

        static void Main()
        {
            CreateDatabase();
            InsertBooks("The Thorn Birds", "Colleen McCullough", new DateTime(1977), "9844831182");
            InsertBooks("Gone with the wind", "Margaret Mitchel", new DateTime(1936), "9780816155316");
        }

        private static void InsertBooks(string p1, string p2, DateTime p3, string p4)
        {
            throw new NotImplementedException();
        }
        private static void CreateDatabase()
        {
            dbConn.Open();
            using (dbConn)
            {
                MySqlCommand CreateDBCommand = new MySqlCommand(@"
                            DROP DATABASE IF EXISTS Library;
                            CREATE DATABASE IF NOT EXISTS Library;
                            USE Library;
                            CREATE TABLE Books(
                            BookID int auto_increment,
                            Title nvarchar(100),
                            Author nvarchar(50),
                            PublishDate datetime,
                            ISBN nvarchar(20),
                            Primary key(BookID)
                            );
                             ", dbConn);
                CreateDBCommand.ExecuteNonQuery();
            }
        }
    }
}
