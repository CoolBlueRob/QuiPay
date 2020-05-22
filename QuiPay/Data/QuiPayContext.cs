using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuiPay.DbModels;

namespace QuiPay.Data
{
    public class QuiPayContext : DbContext
    {
        public QuiPayContext (DbContextOptions<QuiPayContext> options)
            : base(options)
        {
        }

        public DbSet<QuiPay.DbModels.Account> Account { get; set; }

        public DbSet<QuiPay.DbModels.Currency> Currency { get; set; }

        public DbSet<QuiPay.DbModels.ExchangeRate> ExchangeRate { get; set; }

        public DbSet<QuiPay.DbModels.Member> Member { get; set; }

        public DbSet<QuiPay.DbModels.MemberDetails> MemberDetails { get; set; }

        public DbSet<QuiPay.DbModels.Payment> Transaction { get; set; }
    }
}
