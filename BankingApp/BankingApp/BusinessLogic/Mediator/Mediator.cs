using BankingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.BusinessLogic.Mediator
{
    interface Mediator
    {
        public abstract void Send(double amount, BankAccount targetAccount, double conversionRate);

    }

}
