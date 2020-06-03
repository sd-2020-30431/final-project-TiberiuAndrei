using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public class UserData
    {
        private User user;
        private BankAccount accountRon;
        private BankAccount accountEur;
        private double transferRon;
        private double transferEur;
        private string targetRon;
        private string targetEur;
        private double loanAmount;
        public User User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }


        }

        public BankAccount AccountRon
        {
            get
            {
                return accountRon;
            }
            set
            {
                accountRon = value;
            }

        }

        public BankAccount AccountEur
        {
            get
            {
                return accountEur;
            }
            set
            {
                accountEur = value;
            }

        }

        public double TransferRon
        {
            get
            {
                return transferRon;
            }
            set
            {
                transferRon = value;
            }

        }

        public double TransferEur
        {
            get
            {
                return transferEur;
            }
            set
            {
                transferEur = value;
            }

        }

        public string TargetRon
        {
            get
            {
                return targetRon;
            }
            set
            {
                targetRon = value;
            }

        }

        public string TargetEur
        {
            get
            {
                return targetEur;
            }
            set
            {
                targetEur = value;
            }

        }

        public double LoanAmount
        {
            get
            {
                return loanAmount;
            }
            set
            {
                loanAmount = value;
            }

        }

    }

}