using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Linq;

namespace Infastructure.Data
{
    public class AccountOwnerDbContext : DbContext
    {
        public AccountOwnerDbContext(DbContextOptions<AccountOwnerDbContext> options) : base(options)
        {
            // Seed Data
            SeedCustomers();
            SeedAccountTypes();
            SeedTransactionTypes();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountTransaction> AccountTransactions { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }

        /// <summary>
        /// Load Customers 
        /// </summary>
        public void SeedCustomers()
        {
            if(this.Customers.Count() == 0)
            {
                List<Customer> customers = new()
                    {
                        new Customer("Arisha", "Barron", 1),
                        new Customer("Brenden", "Gibson", 2),
                        new Customer("Rhoda", "Church", 3),
                        new Customer("Georgina", "Hazel", 4)
                    };
                    
                Customers.AddRange(customers);
                this.SaveChanges();
            }
        }
        /// <summary>
        /// Load Account Types
        /// </summary>
        public void SeedAccountTypes()
        {
            if(this.AccountTypes.Count() == 0)
            {
                List<AccountType> accountTypes = new()
                {
                    new AccountType(nameof(Core.Constants.AccountType.CHEQUE), (int)Core.Constants.AccountType.CHEQUE),
                    new AccountType(nameof(Core.Constants.AccountType.SAVINGS), (int)Core.Constants.AccountType.SAVINGS)
                };
                AccountTypes.AddRange(accountTypes);
                this.SaveChanges();
            }
            
        }
        /// <summary>
        /// Load Transaction Types
        /// </summary>
        public void SeedTransactionTypes()
        {
            if(this.TransactionTypes.Count() == 0)
            {                
                List<TransactionType> transactionTypes = new()
                {
                    new TransactionType(nameof(Core.Constants.TransactionType.DEPOSIT), (int)Core.Constants.TransactionType.DEPOSIT),
                    new TransactionType(nameof(Core.Constants.TransactionType.TRANSFER), (int)Core.Constants.TransactionType.TRANSFER),
                    new TransactionType(nameof(Core.Constants.TransactionType.WITHDRAWAL), (int)Core.Constants.TransactionType.WITHDRAWAL)
                };

                TransactionTypes.AddRange(transactionTypes);
                this.SaveChanges();
            }
        }

    }
}