
namespace Ex01DAOClass
{
    /*Create a DAO class with static methods which provide functionality for inserting, modifying 
     * and deleting customers. Write a testing class.*/
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EntityFrameworkDemo.Data;
    using System.Data.Entity.Validation;
    using System.Diagnostics;

    class Program
    {
        static void Main()
        {
            DAO.UpdateCustomerContact("ALFKI", "Dinko Cherkezov");
            DAO.InsertCustomer("CHOEX","Chochoven Express");
            DAO.DeleteCustomer("CHOEX");
        }
    }
}
