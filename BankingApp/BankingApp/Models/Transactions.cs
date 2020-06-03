using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BankingApp.Models
{
    public class Transactions
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public string SourceAccount { get; set; }
        [Required]
        public string TargetAccount { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public string Currency { get; set; }

        public Transactions()
        {

        }

        public Transactions(int Type, string SourceAccount, String TargetAccount, double Amount, string Currency)
        {
            this.Type = Type;
            this.SourceAccount = SourceAccount;
            this.TargetAccount = TargetAccount;
            this.Amount = Amount;
            this.Currency = Currency;

        }

    }

}