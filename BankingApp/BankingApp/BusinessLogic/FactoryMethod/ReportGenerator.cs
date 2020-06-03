using BankingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.BusinessLogic.FactoryMethod
{
    //NOTE: The "product class" used in this desing pattern is Transations.cs from BankingApp.Models
    public class ReportGenerator : Creator
    {
        public Transactions generateReport(int type, string sourceAccount, string targetAccount, double amount, string currency)
        {
            Transactions transaction = new Transactions(type, sourceAccount, targetAccount, amount, currency);
            return transaction;
        }
    }
}
