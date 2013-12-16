// -----------------------------------------------------------------------
// <copyright file="LoanAcc.cs" company="">
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
    public class LoanAcc : Account
    {
        public LoanAcc(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate) { }

        public override decimal CalculateInterest(decimal interestPeriod)
        {
            if (this.Customer.GetType() == typeof(Individual)) return base.CalculateInterest(interestPeriod - 3<0?0:interestPeriod - 3);
            else if (this.Customer.GetType() == typeof(Company)) return base.CalculateInterest(interestPeriod - 2);
            else return base.CalculateInterest(interestPeriod);
        }
    }


}
