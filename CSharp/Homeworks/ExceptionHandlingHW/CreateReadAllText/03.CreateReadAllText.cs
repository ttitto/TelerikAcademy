using System;
using System.IO;
using System.Security;

namespace CreateReadAllText
{/*Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini),
  * reads its contents and prints it on the console. Find in MSDN how to use System.IO.File.ReadAllText(…).
  * Be sure to catch all possible exceptions and print user-friendly error messages.*/
    class CreateReadAllTextClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert the file path incl. filename and extension: ");
            try
            {
                string filePath = Console.ReadLine();
                string FileContent = File.ReadAllText(filePath);
                Console.WriteLine(FileContent);
            }
            catch (ArgumentException)//Includes ArgumentNullException and ArgumentOutOfRangeException
            {
                Console.WriteLine("The file path is invalid!");
            }
            catch (IOException)//Includes PathTooLong, DirectoryNotFound and FileNotFoundException
            {
                Console.WriteLine("The inserted path is either too long or the directory and the file are not found!");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You are not authorized to access the file!");
            }
            catch (SecurityException)
            {
                Console.WriteLine("Security error has been detected!");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Reading of the file is not supported!");
            }
            catch (OutOfMemoryException)
            {

            } Console.WriteLine("There is not enough memory to continue the execution of a program!");
        }
    }
}
