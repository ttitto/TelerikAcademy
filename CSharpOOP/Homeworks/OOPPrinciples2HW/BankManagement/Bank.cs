// -----------------------------------------------------------------------
// <copyright file="Bank.cs" company="">
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
    public class Bank
    {
        private List<Account> accounts=new List<Account>();

        public IEnumerable<Account> Accounts
        {
            get { return this.accounts; }
        }
    }
}
