// -----------------------------------------------------------------------
// <copyright file="MortgageAcc.cs" company="">
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
    public class MortgageAcc :Account
    {
        public MortgageAcc(Customer customer, decimal balance, decimal interestRate)
            :base(customer,balance,interestRate){}

        public override decimal CalculateInterest(decimal interestPeriod)
        {
            if (this.Customer.GetType() == typeof(Company))
            {
                decimal monthsAbove = interestPeriod - 12;
                if (monthsAbove >= 0)//the period is longer than 12 months
                {
                    return base.CalculateInterest(12) / 2 + base.CalculateInterest(monthsAbove);
                }
                else return base.CalculateInterest(interestPeriod) / 2;//the period is shorter than 12 months
            }
            else if (this.Customer.GetType() == typeof(Individual))
            {
                decimal monthsAbove = interestPeriod - 6;
                if (monthsAbove >= 0)//the period is longer than 6 months
                {
                    return  base.CalculateInterest(monthsAbove);
                }
                else return base.CalculateInterest(0);

            }
            else return base.CalculateInterest(interestPeriod);//The account is to another type of Customer
        }
    }
}
