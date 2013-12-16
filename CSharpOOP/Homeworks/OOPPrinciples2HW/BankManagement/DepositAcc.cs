// -----------------------------------------------------------------------
// <copyright file="DepositAcc.cs" company="">
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
    public class DepositAcc :Account
    {
        public DepositAcc(Customer customer, decimal balance, decimal interestRate)
            :base(customer,balance,interestRate){}


        public void WithDrawMoney(decimal amount)
        {
            this.Balance -= amount;
        }

        public override decimal CalculateInterest(decimal interestPeriod)
        {
            if(this.Balance>0 && this.Balance<1000) return 0;
            return base.CalculateInterest(interestPeriod);
        }
    }
}
