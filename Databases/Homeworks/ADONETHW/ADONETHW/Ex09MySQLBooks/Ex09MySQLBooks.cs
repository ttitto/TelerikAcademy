

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
        private const string CONN_STRING = "Server=localhost;Database=telerikacademy;Uid=root;Pwd=;";
        private static MySqlConnection dbConn = new MySqlConnection(CONN_STRING);

        static void Main()
        {
            CreateDatabase();
            InsertBooks("The Thorn Birds", "Colleen McCullough", new DateTime(1977, 1, 1), "9844831182");
            InsertBooks("Gone with the wind", "Margaret Mitchel", new DateTime(1936, 04, 13), "9780816155316");
            FindBookByName(Console.ReadLine());

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
        private static void InsertBooks(string bookName, string bookAuthor, DateTime publishDate, string isbn)
        {
            dbConn.Open();
            using (dbConn)
            {
                MySqlCommand insertCommand = new MySqlCommand(@"
                        USE Library;
                        INSERT INTO Books (Title, Author, PublishDate, ISBN) VALUES (@Title, @Author, @PublishDate, @ISBN);
                        ", dbConn);
                insertCommand.Parameters.AddWithValue("@Title", bookName);
                insertCommand.Parameters.AddWithValue("@Author", bookAuthor);
                insertCommand.Parameters.AddWithValue("@PublishDate", publishDate);
                insertCommand.Parameters.AddWithValue("@ISBN", isbn);
                Console.WriteLine("Affected rows {0}.", insertCommand.ExecuteNonQuery());
            }
        }
        private static void FindBookByName(string searched)
        {
            char escapeChar = '!';
            if (string.IsNullOrWhiteSpace(searched) || string.IsNullOrEmpty(searched))
            {
                throw new ArgumentOutOfRangeException("Search string can not be null, empty or whitespace!");
            }
            else
            {
                searched = searched.Replace("%", escapeChar+"%")
                                .Replace("_", escapeChar + "_")
                                .Replace("[", escapeChar + "[")
                                .Replace("]", escapeChar + "]");

                dbConn.Open();
                using (dbConn)
                {
                    MySqlCommand findCommand = new MySqlCommand(@"
                        USE Library;
                        SELECT Title, Author, PublishDate, ISBN FROM Books
                        WHERE Title like @searched escape @escape;
                        ", dbConn);
                    findCommand.Parameters.AddWithValue("@searched", '%' + searched + '%');
                    findCommand.Parameters.AddWithValue("@escape", escapeChar);
                    MySqlDataReader reader = findCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}, {1}, {2}, {3}", reader["Title"], reader["Author"], reader["PublishDate"], reader["ISBN"]);
                    }
                }
            }
        }
    }
}
