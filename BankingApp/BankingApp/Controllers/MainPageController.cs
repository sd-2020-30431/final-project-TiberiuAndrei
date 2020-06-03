using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankingApp.Models;
using BankingApp.BusinessLogic.FactoryMethod;
using BankingApp.BusinessLogic.Observer;
using BankingApp.BusinessLogic.Mediator;

namespace BankingApp.Controllers
{
    public class MainPageController : Controller
    {
        public static UserData userData;

        private readonly DatabaseConnectionManager _dcm;

        public MainPageController(DatabaseConnectionManager dcm)
        {
            _dcm = dcm;
        }

        public static void SetModel(UserData _userData)
        {
            userData = _userData;
        }
        public IActionResult Index()
        {
            return View("~/Views/MainPage/Index.cshtml", userData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IndexPostRon(UserData _userData)
        {
            userData.TransferRon = _userData.TransferRon;
            userData.TargetRon = _userData.TargetRon;

            var count = _dcm.BankAccount.Count(x => (x.AccountName == userData.TargetRon));

            if (count != 0)
            {
                count = _dcm.BankAccount.Count(x => (x.AccountName == userData.TargetRon && x.Currency.Equals("RON")));
                if (count == 0)
                {
                    ViewData["message"] = "Can not transfer RON in EUR account";
                    return View("~/Views/MainPage/Index.cshtml", userData);
                }
                BankAccount targetAccount = _dcm.BankAccount.Where(x => (x.AccountName == userData.TargetRon)).FirstOrDefault();

                targetAccount.Amount += userData.TransferRon;

                _dcm.BankAccount.Update(targetAccount);

                BankAccount sourceAccount = _dcm.BankAccount.Where(x => (x.Id == userData.AccountRon.Id)).FirstOrDefault();

                sourceAccount.Amount -= userData.TransferRon;

                _dcm.BankAccount.Update(sourceAccount);

                _dcm.SaveChanges();

                userData.AccountRon = _dcm.BankAccount.Where(x => (x.Id == userData.AccountRon.Id)).FirstOrDefault();

                ViewData["successMessage"] = userData.TransferRon + " RON has been successfully transfered";

                ReportGenerator rg = new ReportGenerator();
                Transactions transaction = rg.generateReport(0, sourceAccount.AccountName, targetAccount.AccountName, userData.TransferRon, "RON");
                _dcm.Transactions.Add(transaction);
                _dcm.SaveChanges();

                //Uncomment to send mails
                /*ConcreteSubject cs = new ConcreteSubject();
                cs.Attach(userData.User);
                cs.Notify();*/

                return View("~/Views/MainPage/Index.cshtml", userData);
            }
            else
            {
                ViewData["message"] = "Inexisting target account";
                return View("~/Views/MainPage/Index.cshtml", userData);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IndexPostEur(UserData _userData)
        {
            userData.TransferEur = _userData.TransferEur;
            userData.TargetEur = _userData.TargetEur;

            var count = _dcm.BankAccount.Count(x => (x.AccountName == userData.TargetEur));

            if (count != 0)
            {
                count = _dcm.BankAccount.Count(x => (x.AccountName == userData.TargetEur && x.Currency.Equals("EUR")));
                if (count == 0)
                {
                    ViewData["message"] = "Can not transfer EUR in RON account";
                    return View("~/Views/MainPage/Index.cshtml", userData);
                }
                BankAccount targetAccount = _dcm.BankAccount.Where(x => (x.AccountName == userData.TargetEur)).FirstOrDefault();

                targetAccount.Amount += userData.TransferEur;

                _dcm.BankAccount.Update(targetAccount);

                BankAccount sourceAccount = _dcm.BankAccount.Where(x => (x.Id == userData.AccountEur.Id)).FirstOrDefault();

                sourceAccount.Amount -= userData.TransferEur;

                _dcm.BankAccount.Update(sourceAccount);

                _dcm.SaveChanges();

                userData.AccountEur = _dcm.BankAccount.Where(x => (x.Id == userData.AccountEur.Id)).FirstOrDefault();

                ViewData["successMessage"] = userData.TransferEur + " EUR has been successfully transfered";

                ReportGenerator rg = new ReportGenerator();
                Transactions transaction = rg.generateReport(0, sourceAccount.AccountName, targetAccount.AccountName, userData.TransferRon, "EUR");
                _dcm.Transactions.Add(transaction);
                _dcm.SaveChanges();

                //Uncomment to send mails
                /*ConcreteSubject cs = new ConcreteSubject();
                cs.Attach(userData.User);
                cs.Notify();*/

                return View("~/Views/MainPage/Index.cshtml", userData);
            }
            else
            {
                ViewData["message"] = "Inexisting target account";
                return View("~/Views/MainPage/Index.cshtml", userData);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConvertRon(UserData _userData)
        {
            userData.TransferRon = _userData.TransferRon;

            ConcreteMediator cm = new ConcreteMediator();
            cm.SetAccountRon(userData.AccountRon);
            cm.SetAccountEur(userData.AccountEur);

            cm.Send(userData.TransferRon, userData.AccountEur, 4.85);

            _dcm.BankAccount.Update(userData.AccountRon);
            _dcm.BankAccount.Update(userData.AccountEur);
            _dcm.SaveChanges();
            ViewData["successMessage"] = userData.TransferRon + " RON successfully transfered to EUR account";
            return View("~/Views/MainPage/Index.cshtml", userData);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConvertEur(UserData _userData)
        {
            userData.TransferEur = _userData.TransferEur;

            ConcreteMediator cm = new ConcreteMediator();
            cm.SetAccountRon(userData.AccountRon);
            cm.SetAccountEur(userData.AccountEur);

            cm.Send(userData.TransferEur, userData.AccountRon, 4.85);

            _dcm.BankAccount.Update(userData.AccountRon);
            _dcm.BankAccount.Update(userData.AccountEur);
            _dcm.SaveChanges();
            ViewData["successMessage"] = userData.TransferEur + " EUR successfully transfered to RON account";
            return View("~/Views/MainPage/Index.cshtml", userData);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RequestLoan(UserData _userData)
        {
            LoanRequests lr = new LoanRequests();
            lr.Amount = _userData.LoanAmount;
            lr.Uid = userData.User.Id;
            _dcm.LoanRequests.Add(lr);
            _dcm.SaveChanges();

            ViewData["successMessage"] = _userData.LoanAmount + " RON successfully requested";
            return View("~/Views/MainPage/Index.cshtml", userData);

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult ViewTransactions()
        {
            IEnumerable<Transactions> transactions = _dcm.Transactions.Where(x => x.SourceAccount.Equals(userData.AccountRon.AccountName) || x.TargetAccount.Equals(userData.AccountRon.AccountName)
                                                      || x.SourceAccount.Equals(userData.AccountEur.AccountName) || x.TargetAccount.Equals(userData.AccountEur.AccountName)).AsEnumerable();
            return View("~/Views/MainPage/ViewTransactions.cshtml", transactions);

        }

    }

}