namespace Ex05ExtractImages
{
    /*Write a program that retrieves the images for all categories in the Northwind database and stores 
     *them as JPG files in the file system.*/
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    class Ex05ExtractImagesClass
    {
        private const string CONNECTION_STRING = "Server=(local)\\Technolog_MSSQL; Database=Northwind; Integrated Security=true";
        static void Main()
        {
            List<int> myIds = GetImageId();
            List<byte[]> myBinaryImages = ExtractImagesFromDB(myIds);
            myIds.ForEach(id => Console.WriteLine(id));
            SaveToDiscAsJPG(myBinaryImages);
        }



        private static List<int> GetImageId()
        {
            SqlConnection myConn = new SqlConnection(CONNECTION_STRING);
            myConn.Open();
            List<int> myIds = new List<int>();
            SqlCommand cmdGetImageId = new SqlCommand("SELECT CategoryID FROM Categories", myConn);
            using (myConn)
            {
                SqlDataReader reader = cmdGetImageId.ExecuteReader();
                while (reader.Read())
                {
                    myIds.Add((int)reader["CategoryID"]);
                }
            }
            return myIds;
        }

        private static List<byte[]> ExtractImagesFromDB(List<int> myIds)
        {
            SqlConnection myConn = new SqlConnection(CONNECTION_STRING);
            myConn.Open();
            List<byte[]> myBinaryImages = new List<byte[]>();
            using (myConn)
            {
                SqlCommand cmdExtractImages = new SqlCommand(" SELECT  Picture FROM Categories WHERE CategoryID=@id", myConn);
                SqlParameter param = new SqlParameter("@id", SqlDbType.Int);
                cmdExtractImages.Parameters.Add(param);
                for (int i = 0; i < myIds.Count; i++)
                {
                    param.Value = myIds[i];
                    myBinaryImages.Add((byte[])cmdExtractImages.ExecuteScalar());

                }
            }
            return myBinaryImages;
        }
        private static void SaveToDiscAsJPG(List<byte[]> binaryImages)
        {
            string fileEextension = ".jpg";
            for (int imageNum = 0; imageNum < binaryImages.Count; imageNum++)
            {

                FileStream fs = File.OpenWrite(@"..\..\imageFromDB"+(imageNum+1)+fileEextension);

                using (fs)
                {
                    fs.Write(binaryImages[imageNum], 0, binaryImages[imageNum].Length);
                }
                Console.WriteLine("File saved!");
            }
        }
    }
}
