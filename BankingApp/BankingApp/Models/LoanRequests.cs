using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BankingApp.Models
{
    public class LoanRequests
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long Uid { get; set; }
        [Required]
        public double Amount { get; set; }

    }
}
