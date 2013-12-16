// -----------------------------------------------------------------------
// <copyright file="Customer.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace BankManagement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
   public abstract class Customer
    {
       private string name;

       protected string Name
       {
           get { return this.name;}
           set
           {
               if(value==null) throw new ArgumentException("Name can not be null!");
               this.name = value;
           }
       }

       //Constructor
       protected Customer(string name)
       {
           this.Name = name;
       }
    }
}
