

namespace Ex06ExcelDBConnection
{
    /*Ex06: Create an Excel file with 2 columns: name and score:
Write a program that reads your MS Excel file through the OLE DB data provider and displays the name and score row by row.
     * 
     * Ex07: Implement appending new rows to the Excel file.*/

    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Ex06ExcelDBConnectionClass
    {
        static void Main()
        {
            OleDbConnection dbConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\ScoresDB.xlsx;Extended Properties=""Excel 12.0 Xml;HDR=YES"";");
            dbConn.Open();
            ExtractData(dbConn);
            ImportData(dbConn, "Todor Stoyanov", 23);
            ExtractData(dbConn);
            dbConn.Close();
        }

        private static void ImportData(OleDbConnection dbConn, string nm, int Scr)
        {
            
                OleDbCommand dbCommand = new OleDbCommand("INSERT INTO [Scores$A1:B] (Name, Score) VALUES (@Name, @Score)", dbConn);
                OleDbParameter parName = new OleDbParameter("@Name", nm);
                OleDbParameter parScore = new OleDbParameter("@Score", Scr);
                dbCommand.Parameters.Add(parName);
                dbCommand.Parameters.Add(parScore);
                dbCommand.ExecuteNonQuery();
            
        }

        private static void ExtractData(OleDbConnection dbConn)
        {
            
                OleDbCommand dbCommand = new OleDbCommand("SELECT Name, Score FROM [Scores$A1:B]", dbConn);
                OleDbDataReader reader = dbCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0} {1}", reader["Name"], reader["Score"]);
                }
            
        }
    }
}
