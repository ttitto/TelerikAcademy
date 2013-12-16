// -----------------------------------------------------------------------
// <copyright file="Account.cs" company="">
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
    public abstract class Account :IAccounting
    {
        protected Customer customer;
        private decimal balance;
        private decimal interestRate;//monthly baseg ,ex. 8,25% yearly/12=0.6875 % per month

        public Customer Customer
        {
            get { return this.customer; }
            set
            {
                if (value == null) throw new ArgumentNullException("Customer can not be null!");
                this.customer = value;
                ;
            }
        }
        public decimal Balance
        {
            get { return this.balance; }
            set {
                this.balance = value;
                ;
            }
        }
        public decimal InterestRate
        {
            get { return this.interestRate;}
            set { this.interestRate=value;}
        }
        //Constructor
        public Account(Customer customer, decimal balance, decimal interestRate) 
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public void DepositMoney(decimal amount)
        {
            this.Balance += amount;
        }

        public virtual decimal CalculateInterest(decimal interestPeriod)//in months
        {
            return this.Balance * this.InterestRate * interestPeriod/100;
        }
    }
}
