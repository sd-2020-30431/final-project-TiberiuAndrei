using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BankingApp.Models
{
    public class MailBot
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public String Username { get; set; }

        [Required]
        public string Password { get; set; }

    }

}