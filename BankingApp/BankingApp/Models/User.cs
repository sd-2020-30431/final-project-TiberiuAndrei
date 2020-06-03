using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BankingApp.BusinessLogic;

namespace BankingApp.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public String Username { get; set; }

        [Required]
        public String Password { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String First_name { get; set; }

        [Required]
        public String Last_name { get; set; }

        [Required]
        public String Address { get; set; }

        [Required]
        public String CNP { get; set; }

        [Required]
        public int Type { get; set; }

        public void Update(string umail, MailBot mailBot)
        {
            string message = "Your account has been processed in a new transaction";
            MailManager mailManager = new MailManager();
            mailManager.sendMail(mailBot.Username, mailBot.Password, umail, "New Items Expired", message);

        }

    }

}