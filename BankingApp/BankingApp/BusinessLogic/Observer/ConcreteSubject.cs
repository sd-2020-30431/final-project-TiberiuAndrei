using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BankingApp.Models;

namespace BankingApp.BusinessLogic.Observer
{
    //The "Observer" class used in this pattern is User.cs, located at BankingApp.Models
    public class ConcreteSubject
    {
        private readonly DatabaseConnectionManager _dcm;

        public ConcreteSubject(DatabaseConnectionManager dcm)
        {
            _dcm = dcm;
        }

        private List<User> ObserverList;
        public ConcreteSubject()
        {
            ObserverList = new List<User>();
        }

        public void Attach(User observer)
        {
            ObserverList.Add(observer);
        }

        public void Detach(User observer)
        {
            ObserverList.Remove(observer);
        }

        public void Notify()
        {
            MailBot mailBot = _dcm.MailBot.Where(x => (x.Id == 1)).FirstOrDefault();
            foreach (User o in ObserverList)
            {
                o.Update(o.Email, mailBot);

            }

        }

    }

}
