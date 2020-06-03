using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankingApp.Models;

namespace BankingApp.Models
{
    public class DatabaseConnectionManager : DbContext
    {
        public DatabaseConnectionManager(DbContextOptions<DatabaseConnectionManager> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<LoanRequests> LoanRequests { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<MailBot> MailBot { get; set; }

    }
}
