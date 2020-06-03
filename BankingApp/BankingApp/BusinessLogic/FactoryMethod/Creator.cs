using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingApp.Models;

namespace BankingApp.BusinessLogic.FactoryMethod
{
    interface Creator
    {
        public abstract Transactions generateReport(int type, string sourceAccount, string targetAccount, double amount, string currency);

    }

}
