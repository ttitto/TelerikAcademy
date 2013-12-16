using System;
using System.Net;
using System.IO;

namespace DownloadSaveFile
{
    class DownloadSaveFileClass
    {/*Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg)
      * and stores it the current directory. Find in Google how to download files in C#.
      * Be sure to catch all exceptions and to free any used resources in the finally block.*/
        static void Main()
        {
            WebClient wbClnt = new WebClient();
            try
            {
                Console.Write("Insert the URL of the file to be downloaded: ");
                string URL = Console.ReadLine();
                //the filename is extracted from the URL and the file is saved in the current directory
                wbClnt.DownloadFile(URL, Directory.GetCurrentDirectory() + Path.GetFileName(URL));
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)//Includes ArgumentOutOfRangeException
                {
                    Console.WriteLine("The format of the URL is not valid! " + ex.Message);
                    Main();
                }
                if (ex is WebException)
                {
                    Console.WriteLine("The URL doesn't exist! " + ex.Message);
                    Main();
                }
                if (ex is NotSupportedException)
                {
                    Console.WriteLine("The invoked functionality is not supported! " + ex.Message);
                    Main();
                }
                if (ex is UnauthorizedAccessException)
                {
                    Console.WriteLine("You are not authorized to access the URL or the local directory!" + ex.Message);
                    Main();
                }
                if (ex is OutOfMemoryException)
                {
                    Console.WriteLine("There are not enough ressources to execute your program on this workstation!" + ex.Message);
                    Main();
                }
                if (ex is IOException)
                {
                    Console.WriteLine("The file couldn't be downloaded and saved.!" + ex.Message);
                    Main();
                }
                else throw;
            }
            finally
            {
                wbClnt.Dispose();
                Main();
            }

        }
    }
}
