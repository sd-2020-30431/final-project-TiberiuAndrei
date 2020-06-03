using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankingApp.Models;
using BankingApp.Controllers;
using System.Web;

namespace BankingApp.Controllers
{
    public class LogInController : Controller
    {

        private readonly DatabaseConnectionManager _dcm;

        public LogInController(DatabaseConnectionManager dcm)
        {
            _dcm = dcm;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(User user)
        {
            var count = _dcm.User.Count(x => (x.Username == user.Username && x.Password == user.Password));
            User query_user = _dcm.User.Where(x => (x.Username == user.Username && x.Password == user.Password)).FirstOrDefault();

            BankAccount accountRon = _dcm.BankAccount.Where(x => (x.UserId == query_user.Id && x.Currency.Equals("RON"))).FirstOrDefault();

            BankAccount accountEur = _dcm.BankAccount.Where(x => (x.UserId == query_user.Id && x.Currency.Equals("Eur"))).FirstOrDefault();

            UserData user_data = new UserData();
            user_data.User = query_user;
            user_data.AccountRon = accountRon;
            user_data.AccountEur = accountEur;

            if (count == 1)
            {
                MainPageController.SetModel(user_data);
                MainPageController mpc = new MainPageController(_dcm);
                //mpc.SetModel(user_data);
                return mpc.Index();
            }
            else
            {
                ViewData["message"] = "Invalid Username or Password";
                //return RedirectToAction("Index", "LogIn");
                //Response.Redirect("https://localhost:44386/LogIn/Index");
                return View();
            }

            //var sol = _dcm.User.Where(x => (x.Username == user.Username && x.Password == user.Password)).FirstOrDefault<User>();
        }

    }
}