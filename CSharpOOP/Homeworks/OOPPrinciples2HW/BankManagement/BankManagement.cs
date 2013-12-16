using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankManagement
{
    /* A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage accounts. 
     * Customers could be individuals or companies.
	All accounts have customer, balance and interest rate (monthly based). 
     * Deposit accounts are allowed to deposit and with draw money. 
     * Loan and mortgage accounts can only deposit money.
All accounts can calculate their interest amount for a given period (in months). In the common case its is calculated as follows: number_of_months * interest_rate.
Loan accounts have no interest for the first 3 months if are held by individuals and for the first 2 months if are held by a company.
Deposit accounts have no interest if their balance is positive and less than 1000.
Mortgage accounts have ½ interest for the first 12 months for companies and no interest for the first 6 months for individuals.
Your task is to write a program to model the bank system by classes and interfaces. You should identify the classes, interfaces, base classes and abstract actions and implement the calculation of the interest functionality through overridden methods.*/
    class BankManagementClass
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            Customer me = new Individual("Pesho");
            Customer myCompany = new Company("M Trade");

            Account myDepositAcc = new DepositAcc(me,2015m,0.55m);
            Account myLoanAcc = new LoanAcc(me, -2400.36m, 0.6875m);
            Account myMortgageAcc = new MortgageAcc(me,-25050m,0.600m);

            Account myCompDepositAcc = new DepositAcc(myCompany, 2015m, 0.55m);
            Account myCompLoanAcc = new LoanAcc(myCompany, -2400.36m, 0.6875m);
            Account myCompMortgageAcc = new MortgageAcc(myCompany, -25050m, 0.600m);

            Console.WriteLine("Deposit accounts:");
            Console.WriteLine(myDepositAcc.CalculateInterest(11));
            Console.WriteLine(myCompDepositAcc.CalculateInterest(11));

            Console.WriteLine(myDepositAcc.CalculateInterest(14));
            Console.WriteLine(myCompDepositAcc.CalculateInterest(14));

            Console.WriteLine("Loan accounts: ");
            Console.WriteLine("4 months");
            Console.WriteLine( myLoanAcc.CalculateInterest(4));
            Console.WriteLine(myCompLoanAcc.CalculateInterest(4));
            Console.WriteLine("3 months");
            Console.WriteLine(myLoanAcc.CalculateInterest(3));
            Console.WriteLine(myCompLoanAcc.CalculateInterest(3));
            Console.WriteLine("2 months");
            Console.WriteLine(myLoanAcc.CalculateInterest(2));
            Console.WriteLine(myCompLoanAcc.CalculateInterest(2));

            Console.WriteLine("Mortgage accounts: ");
            Console.WriteLine("3 months");
            Console.WriteLine(myMortgageAcc.CalculateInterest(3));
            Console.WriteLine(myCompMortgageAcc.CalculateInterest(3));
            Console.WriteLine("8 months");
            Console.WriteLine(myMortgageAcc.CalculateInterest(8));
            Console.WriteLine(myCompMortgageAcc.CalculateInterest(8));
            Console.WriteLine("14 months");
            Console.WriteLine(myMortgageAcc.CalculateInterest(14));
            Console.WriteLine(myCompMortgageAcc.CalculateInterest(14));
            Console.WriteLine("Deposit 300 to my loan account. Interest for 4 months:");
            myLoanAcc.DepositMoney(300);
            Console.WriteLine( myLoanAcc.CalculateInterest(4));
           ;
        }
    }
}
