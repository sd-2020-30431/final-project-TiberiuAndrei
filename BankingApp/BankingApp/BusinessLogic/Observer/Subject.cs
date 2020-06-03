using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingApp.Models;

namespace BankingApp.BusinessLogic.Observer
{
    interface Subject
    {
        public abstract void Attach(User observer);

        public abstract void Detach(User observer);

        public abstract void Notify();

    }

}
