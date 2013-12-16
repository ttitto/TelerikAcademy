using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankManagement
{
    interface IAccounting
    {
         void DepositMoney(decimal amount);
         decimal CalculateInterest(decimal interestPeriod);
    }
}
