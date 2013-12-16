using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03CompanyData
{
    /*3. A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number. 
     * Write a program that reads the information about a company and its manager and prints them on the console.*/
    class Ex03CompanyDataClass
    {
        static void Main(string[] args)
        {
            Console.Write("company name: ");
            string companyName = Console.ReadLine();
            Console.Write("company address: ");
            string address = Console.ReadLine();
            Console.Write("company phone number: ");
            string compPhoneNum=Console.ReadLine();
            Console.Write("company web site: ");
            string web=Console.ReadLine();

            Console.Write("manager's first name: ");
            string managerFName=Console.ReadLine();
            Console.Write("manager's last name: ");
            string managerLName = Console.ReadLine();
            string manager = managerFName + " " + managerLName;
            Console.Write("manager's age: ");
            byte age = byte.Parse(Console.ReadLine());
            Console.Write("manager's phone number: ");
            string managerPhoneNum = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("company name: {0}",companyName);
            Console.WriteLine("company address: {0}",address);
            Console.WriteLine("company phone number: {0}",compPhoneNum);
            Console.WriteLine("company web site: {0}",web);
            Console.WriteLine("manager's first name: {0}",managerFName);
            Console.WriteLine("manager's last name: {0}",managerLName);
            Console.WriteLine("manager's age: {0}",age);
            Console.WriteLine("manager's phone number: {0}",managerPhoneNum);

        }
    }
}
