using big_wallet.Models;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace big_wallet.Infrastructure
{
    public class WalletDbContext : DbContext
    {
        public WalletDbContext(DbContextOptions<WalletDbContext> options)
         : base(options)
        {
        }

        // Adicione DbSets para suas entidades, exemplo:
        public DbSet<User> User { get; set; }
        public DbSet<Coin> Coin { get; set; }
        public DbSet<Models.Transaction> Transaction { get; set; }
        public DbSet<Wallet> Wallet { get; set; }

    }
}
