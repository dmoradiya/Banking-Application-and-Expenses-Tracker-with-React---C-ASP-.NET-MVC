using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_VV.Models
{
    public class BankContext : DbContext
    {
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connection =
                    "server=localhost;" +
                    "port=3306;" +
                    "user=root;" +
                    "database=bank_db;";

                string version = "10.4.14-MariaDB";

                optionsBuilder.UseMySql(connection, x => x.ServerVersion(version));
            }
        }

        // Model Builder stuff goes here, along with seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Model for Transaction
            modelBuilder.Entity<Transaction>(entity =>
            {
                // Collation for Source and Category
                entity.Property(e => e.TransactionSource).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.TransactionCategory).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");


                // FK for Transaction -> Account
                string keyToAccount = "FK_" + nameof(Transaction) + "_" + nameof(Account);

                entity.HasIndex(e => e.AccountID).HasName(keyToAccount);

                entity.HasOne(thisEntity => thisEntity.Account)
                .WithMany(parent => parent.Transactions)
                .HasForeignKey(thisEntity => thisEntity.AccountID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName(keyToAccount);


                    entity.HasData(
                    new Transaction()
                    {
                        TransactionID = 1,
                        AccountID = 1,
                        TransactionSource = "Allgood Engineering Inc.",
                        TransactionCategory = "Income",
                        TransactionValue = 2001.86,
                        TransactionDate = new DateTime(2020, 07, 11)
                    },
                    new Transaction()
                    {
                        TransactionID = 2,
                        AccountID = 1,
                        TransactionSource = "Axion Rental Agency",
                        TransactionCategory = "Expense_Rent",
                        TransactionValue = -1100.00,
                        TransactionDate = new DateTime(2020, 07, 29)
                    },
                    new Transaction()
                    {
                        TransactionID = 3,
                        AccountID = 1,
                        TransactionSource = "Jonathan's Car Repairs",
                        TransactionCategory = "Expense_Vehicle",
                        TransactionValue = -200.99,
                        TransactionDate = new DateTime(2020, 10, 15)
                    },
                    new Transaction()
                    {
                        TransactionID = 4,
                        AccountID = 1,
                        TransactionSource = "Superstore",
                        TransactionCategory = "Expense_Groceries",
                        TransactionValue = -71.44,
                        TransactionDate = new DateTime(2020, 10, 16)
                    },
                    new Transaction()
                    {
                        TransactionID = 5,
                        AccountID = 1,
                        TransactionSource = "Ironman Gym Membership Fee",
                        TransactionCategory = "Expense_Health",
                        TransactionValue = -30.00,
                        TransactionDate = new DateTime(2020, 10, 30)
                    },
                    new Transaction()
                    {
                        TransactionID = 6,
                        AccountID = 2,
                        TransactionSource = "Gold Hand Investments Inc.",
                        TransactionCategory = "Income_Investments",
                        TransactionValue = 750.00,
                        TransactionDate = new DateTime(2020, 04, 11)
                    },
                    new Transaction()
                    {
                        TransactionID = 7,
                        AccountID = 2,
                        TransactionSource = "Gold Hand Investments Inc.",
                        TransactionCategory = "Income_Investments",
                        TransactionValue = 750.00,
                        TransactionDate = new DateTime(2020, 05, 11)
                    },
                    new Transaction()
                    {
                        TransactionID = 8,
                        AccountID = 2,
                        TransactionSource = "Gold Hand Investments Inc.",
                        TransactionCategory = "Income_Investments",
                        TransactionValue = 750.00,
                        TransactionDate = new DateTime(2020, 06, 11)
                    },
                    new Transaction()
                    {
                        TransactionID = 9,
                        AccountID = 2,
                        TransactionSource = "Gold Hand Investments Inc.",
                        TransactionCategory = "Income_Investments",
                        TransactionValue = 750.00,
                        TransactionDate = new DateTime(2020, 07, 11)
                    },
                    new Transaction()
                    {
                        TransactionID = 10,
                        AccountID = 3,
                        TransactionSource = "Bank of Wallachia",
                        TransactionCategory = "Income",
                        TransactionValue = 4.00,
                        TransactionDate = new DateTime(2020, 08, 11)
                    },
                    new Transaction()
                    {
                        TransactionID = 11,
                        AccountID = 3,
                        TransactionSource = "Wallachia Market",
                        TransactionCategory = "Expense_Food",
                        TransactionValue = -1.00,
                        TransactionDate = new DateTime(2020, 08, 13)
                    },
                    new Transaction()
                    {
                        TransactionID = 12,
                        AccountID = 4,
                        TransactionSource = "Gold Hand Investments Inc.",
                        TransactionCategory = "Income",
                        TransactionValue = 7500.00,
                        TransactionDate = new DateTime(2020, 07, 11)
                    },
                    new Transaction()
                    {
                        TransactionID = 13,
                        AccountID = 4,
                        TransactionSource = "Gold Hand Investments Inc.",
                        TransactionCategory = "Income",
                        TransactionValue = 7500.00,
                        TransactionDate = new DateTime(2020, 08, 11)
                    },
                    new Transaction()
                    {
                        TransactionID = 14,
                        AccountID = 4,
                        TransactionSource = "Central Avionics",
                        TransactionCategory = "Expense_Recreation",
                        TransactionValue = 3000.00,
                        TransactionDate = new DateTime(2020, 08, 14)
                    },
                    new Transaction()
                    {
                        TransactionID = 15,
                        AccountID = 5,
                        TransactionSource = "Gold Hand Investments Inc.",
                        TransactionCategory = "Income_Investments",
                        TransactionValue = 43000.00,
                        TransactionDate = new DateTime(2020, 08, 20)
                    },
                    new Transaction()
                    {
                        TransactionID = 16,
                        AccountID = 5,
                        TransactionSource = "Gold Hand Investments Inc.",
                        TransactionCategory = "Income_Investments",
                        TransactionValue = 43000.00,
                        TransactionDate = new DateTime(2020, 09, 20)
                    },
                    new Transaction()
                    {
                        TransactionID = 17,
                        AccountID = 6,
                        TransactionSource = "Seven Eleven",
                        TransactionCategory = "Income",
                        TransactionValue = 1100.32,
                        TransactionDate = new DateTime(2020, 07, 11)
                    },
                    new Transaction()
                    {
                        TransactionID = 18,
                        AccountID = 6,
                        TransactionSource = "Axion Rental Agency",
                        TransactionCategory = "Expense_Rent",
                        TransactionValue = -800.00,
                        TransactionDate = new DateTime(2020, 07, 29)
                    },
                    new Transaction()
                    {
                        TransactionID = 19,
                        AccountID = 6,
                        TransactionSource = "St. Albert Transit",
                        TransactionCategory = "Expense_Vehicle",
                        TransactionValue = -41.99,
                        TransactionDate = new DateTime(2020, 10, 15)
                    },
                    new Transaction()
                    {
                        TransactionID = 20,
                        AccountID = 6,
                        TransactionSource = "Superstore",
                        TransactionCategory = "Expense_Groceries",
                        TransactionValue = -84.23,
                        TransactionDate = new DateTime(2020, 10, 16)
                    }


                    );


            });

            // Model for Account
            modelBuilder.Entity<Account>(entity =>
            {
                // Collation for AccountTYpe
                entity.Property(e => e.AccountType).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");

                // FK for Account -> Client
                string keyToClient = "FK_" + nameof(Account) + "_" + nameof(Client);
                entity.HasIndex(e => e.ClientID).HasName(keyToClient);

                entity.HasOne(thisEntity => thisEntity.Client)
                .WithMany(parent => parent.Accounts)
                .HasForeignKey(thisEntity => thisEntity.ClientID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName(keyToClient);


                     entity.HasData(
                     new Account()
                     {
                        AccountID = 1,
                        ClientID = 1,
                        AccountType = "Chequing",
                        AccountBalance = 5003.23,
                        AccountInterest = 0,
                        IsActive = true
                     },
                     new Account()
                     {
                         AccountID = 2,
                         ClientID = 1,
                         AccountType = "Savings",
                         AccountBalance = 40000.43,
                         AccountInterest = 0.03,
                         IsActive = true
                     },
                     new Account()
                     {
                         AccountID = 3,
                         ClientID = 2,
                         AccountType = "Chequing",
                         AccountBalance = 3.75,
                         AccountInterest = 0,
                         IsActive = true
                     },
                     new Account()
                     {
                         AccountID = 4,
                         ClientID = 3,
                         AccountType = "Chequing",
                         AccountBalance = 75552.23,
                         AccountInterest = 0,
                         IsActive = true
                     },
                     new Account()
                     {
                         AccountID = 5,
                         ClientID = 3,
                         AccountType = "Savings",
                         AccountBalance = 814750.99,
                         AccountInterest = 0.03,
                         IsActive = true
                     },
                     new Account()
                     {
                         AccountID = 6,
                         ClientID = 4,
                         AccountType = "Chequing",
                         AccountBalance = 753.23,
                         AccountInterest = 0,
                         IsActive = true
                     }
                     );

            });

            // Model for Client
            modelBuilder.Entity<Client>(entity =>
            {
                // Collation for emailaddress, password, phonenumber, firstname, lastname, city, province, postalcode
                entity.Property(e => e.EmailAddress).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.Password).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.PhoneNumber).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.FirstName).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.LastName).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.City).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.Province).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.PostalCode).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");


                     entity.HasData(
                     new Client()
                     {
                        ClientID = 1,
                        EmailAddress = "johndoe123@gmail.com",
                        Password = "john123",
                        PhoneNumber = "7804188874",
                        FirstName = "John",
                        LastName = "Doe",
                        DateOfBirth = new DateTime(1989, 03, 29),
                        City = "Edmonton",
                        Province = "AB",
                        PostalCode = "T8N3A4"
                     },
                    new Client()
                    {
                        ClientID = 2,
                        EmailAddress = "trevorbelmont123@gmail.com",
                        Password = "draculasux",
                        PhoneNumber = "7804442121",
                        FirstName = "Trevor",
                        LastName = "Belmont",
                        DateOfBirth = new DateTime(1880, 02, 25),
                        City = "London",
                        Province = "ON",
                        PostalCode = "Z4A2B1"
                    },
                    new Client()
                    {
                        ClientID = 3,
                        EmailAddress = "richardrich@gmail.com",
                        Password = "rich123!@#",
                        PhoneNumber = "7771115454",
                        FirstName = "Richard",
                        LastName = "Rich",
                        DateOfBirth = new DateTime(1999, 12, 03),
                        City = "Edmonton",
                        Province = "AB",
                        PostalCode = "T8N3E1"
                    },
                    new Client()
                    {
                        ClientID = 4,
                        EmailAddress = "brokeasajoke@gmail.com",
                        Password = "password123",
                        PhoneNumber = "7809198888",
                        FirstName = "Bruce",
                        LastName = "Hunter",
                        DateOfBirth = new DateTime(1979, 05, 04),
                        City = "Edmonton",
                        Province = "AB",
                        PostalCode = "T8N6Y3"
                    }

                     );


            });


        }
    }
}
