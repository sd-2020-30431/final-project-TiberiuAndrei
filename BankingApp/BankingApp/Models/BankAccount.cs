using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BankingApp.Models
{
    public class BankAccount
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string AccountName { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string Cvv { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public string CardType { get; set; }

        [Required]
        public long UserId { get; set; }

    }
}