using BankingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.BusinessLogic.Mediator
{
    //NOTE: The "colleague class" used in this pattern is BankAccount.cs, located at BankingApp.Models
    public class ConcreteMediator: Mediator
    {
        private BankAccount AccountRon;
        private BankAccount AccountEur;

        public void SetAccountRon(BankAccount account)
        {
            this.AccountRon = account;
        }
        public void SetAccountEur(BankAccount account)
        {
            this.AccountEur = account;
        }

        public void Send(double amount, BankAccount targetAccount, double conversionRate)
        {
            if (targetAccount == AccountRon)
            {
                AccountEur.Amount -= amount;
                AccountRon.Amount += (amount * conversionRate);
            }
            else
            {
                AccountEur.Amount += (amount / conversionRate);
                AccountRon.Amount -= amount;
            }

        }

    }

}
