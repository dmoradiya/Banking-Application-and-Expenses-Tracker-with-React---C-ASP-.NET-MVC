using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json")
               .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("BankDBConnection"));          
           
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
                .WithMany(paHousing => paHousing.Transactions)
                .HasForeignKey(thisEntity => thisEntity.AccountID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName(keyToAccount);


                entity.HasData(
                new Transaction()
                {
                    TransactionID = 1,
                    AccountID = 1,
                    TransactionSource = "Bank",
                    TransactionCategory = "Deposit",
                    TransactionValue = 2001.86,
                    TransactionDate = new DateTime(2020, 07, 11),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 2,
                    AccountID = 1,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Housing",
                    TransactionValue = 1100.00,
                    TransactionDate = new DateTime(2020, 07, 29),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 3,
                    AccountID = 1,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Other",
                    TransactionValue = 200.00,
                    TransactionDate = new DateTime(2020, 10, 15),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 4,
                    AccountID = 1,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Food",
                    TransactionValue = 50.00,
                    TransactionDate = new DateTime(2020, 10, 16),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 5,
                    AccountID = 1,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Health",
                    TransactionValue = 30.00,
                    TransactionDate = new DateTime(2020, 10, 30),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 6,
                    AccountID = 1,
                    TransactionSource = "ATM",
                    TransactionCategory = "Deposit",
                    TransactionValue = 430.00,
                    TransactionDate = new DateTime(2020, 04, 11),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 7,
                    AccountID = 1,
                    TransactionSource = "ATM",
                    TransactionCategory = "Deposit",
                    TransactionValue = 110.00,
                    TransactionDate = new DateTime(2020, 05, 11),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 8,
                    AccountID = 1,
                    TransactionSource = "Bank",
                    TransactionCategory = "Deposit",
                    TransactionValue = 320.00,
                    TransactionDate = new DateTime(2020, 06, 11),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 9,
                    AccountID = 1,
                    TransactionSource = "Bank",
                    TransactionCategory = "Deposit",
                    TransactionValue = 750.00,
                    TransactionDate = new DateTime(2020, 07, 11),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 10,
                    AccountID = 2,
                    TransactionSource = "ATM",
                    TransactionCategory = "Withdraw",
                    TransactionValue = 50.00,
                    TransactionDate = new DateTime(2020, 08, 11),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 11,
                    AccountID = 2,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Food",
                    TransactionValue = 10.00,
                    TransactionDate = new DateTime(2020, 08, 13),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 12,
                    AccountID = 3,
                    TransactionSource = "Bank",
                    TransactionCategory = "Deposit",
                    TransactionValue = 7500.00,
                    TransactionDate = new DateTime(2020, 07, 11),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 13,
                    AccountID = 3,
                    TransactionSource = "Bank",
                    TransactionCategory = "Deposit",
                    TransactionValue = 7500.00,
                    TransactionDate = new DateTime(2020, 08, 11),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 14,
                    AccountID = 3,
                    TransactionSource = "Bank",
                    TransactionCategory = "Withdraw",
                    TransactionValue = 3000.00,
                    TransactionDate = new DateTime(2020, 08, 14),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 15,
                    AccountID = 3,
                    TransactionSource = "Bank",
                    TransactionCategory = "Deposit",
                    TransactionValue = 43750.00,
                    TransactionDate = new DateTime(2020, 08, 20),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 16,
                    AccountID = 3,
                    TransactionSource = "Bank",
                    TransactionCategory = "Deposit",
                    TransactionValue = 22100.00,
                    TransactionDate = new DateTime(2020, 09, 20),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 17,
                    AccountID = 4,
                    TransactionSource = "ATM",
                    TransactionCategory = "Deposit",
                    TransactionValue = 1100.32,
                    TransactionDate = new DateTime(2020, 07, 11),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 18,
                    AccountID = 4,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Housing",
                    TransactionValue = 800.00,
                    TransactionDate = new DateTime(2020, 07, 29),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 19,
                    AccountID = 4,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Utilities",
                    TransactionValue = 41.99,
                    TransactionDate = new DateTime(2020, 10, 15),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 20,
                    AccountID = 4,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Internet",
                    TransactionValue = 84.23,
                    TransactionDate = new DateTime(2020, 07, 16),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 21,
                    AccountID = 4,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Housing",
                    TransactionValue = 1750.00,
                    TransactionDate = new DateTime(2020, 07, 15),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 22,
                    AccountID = 4,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Food",
                    TransactionValue = 750,
                    TransactionDate = new DateTime(2020, 07, 15),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 23,
                    AccountID = 4,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Transportation",
                    TransactionValue = 750,
                    TransactionDate = new DateTime(2020, 07, 15),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 24,
                    AccountID = 4,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Utilities",
                    TransactionValue = 500,
                    TransactionDate = new DateTime(2020, 07, 15),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 25,
                    AccountID = 4,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Debt Payments",
                    TransactionValue = 500,
                    TransactionDate = new DateTime(2020, 07, 15),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 26,
                    AccountID = 4,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Savings",
                    TransactionValue = 250,
                    TransactionDate = new DateTime(2020, 07, 16),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 27,
                    AccountID = 4,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Clothing",
                    TransactionValue = 125,
                    TransactionDate = new DateTime(2020, 07, 16),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 28,
                    AccountID = 4,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Health",
                    TransactionValue = 125,
                    TransactionDate = new DateTime(2020, 07, 16),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 29,
                    AccountID = 4,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Other",
                    TransactionValue = 250,
                    TransactionDate = new DateTime(2020, 07, 16),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 30,
                    AccountID = 4,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Internet",
                    TransactionValue = 60,
                    TransactionDate = new DateTime(2020, 08, 16),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 31,
                    AccountID = 4,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Housing",
                    TransactionValue = 1750.00,
                    TransactionDate = new DateTime(2020, 08, 15),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 32,
                    AccountID = 4,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Food",
                    TransactionValue = 850,
                    TransactionDate = new DateTime(2020, 08, 15),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 33,
                    AccountID = 4,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Transportation",
                    TransactionValue = 900,
                    TransactionDate = new DateTime(2020, 08, 15),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 34,
                    AccountID = 4,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Utilities",
                    TransactionValue = 500,
                    TransactionDate = new DateTime(2020, 08, 15),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 35,
                    AccountID = 4,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Debt Payments",
                    TransactionValue = 400,
                    TransactionDate = new DateTime(2020, 08, 15),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 36,
                    AccountID = 4,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Savings",
                    TransactionValue = 250,
                    TransactionDate = new DateTime(2020, 08, 16),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 37,
                    AccountID = 4,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Clothing",
                    TransactionValue = 110,
                    TransactionDate = new DateTime(2020, 08, 16),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 38,
                    AccountID = 4,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Health",
                    TransactionValue = 125,
                    TransactionDate = new DateTime(2020, 08, 16),
                    IsTransactionActive = true
                },
                new Transaction()
                {
                    TransactionID = 39,
                    AccountID = 4,
                    TransactionSource = "Bill Payment",
                    TransactionCategory = "Other",
                    TransactionValue = 250,
                    TransactionDate = new DateTime(2020, 08, 16),
                    IsTransactionActive = true
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
                .WithMany(paHousing => paHousing.Accounts)
                .HasForeignKey(thisEntity => thisEntity.ClientID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName(keyToClient);


                entity.HasData(
                new Account()
                {
                    AccountID = 1,
                    ClientID = 1,
                    AccountType = "Chequing",
                    AccountBalance = 2189.43,
                    Cashback = 10.02,
                    AccountDate = new DateTime(2018, 10, 02),
                    IsActive = true
                },
                new Account()
                {
                    AccountID = 2,
                    ClientID = 1,
                    AccountType = "Savings",
                    AccountBalance = 20550.43,
                    Cashback = 23.58,
                    AccountDate = new DateTime(2018, 10, 02),
                    IsActive = true
                },
                new Account()
                {
                    AccountID = 3,
                    ClientID = 2,
                    AccountType = "Chequing",
                    AccountBalance = 144.00,
                    Cashback = 5.80,
                    AccountDate = new DateTime(2018, 09, 12),
                    IsActive = true
                },
                new Account()
                {
                    AccountID = 4,
                    ClientID = 3,
                    AccountType = "Chequing",
                    AccountBalance = 77850.00,
                    Cashback = 100.07,
                    AccountDate = new DateTime(2018, 05, 28),
                    IsActive = true
                },
                new Account()
                {
                    AccountID = 5,
                    ClientID = 4,
                    AccountType = "Chequing",
                    AccountBalance = 174.10,
                    Cashback = 45.00,
                    AccountDate = new DateTime(2018, 11, 17),
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
                entity.Property(e => e.Address).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.City).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.Province).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.PostalCode).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");


                entity.HasData(
                new Client()
                {
                    ClientID = 1,
                    EmailAddress = "johndoe123@gmail.com",
                    Password = "$2a$11$VA8lRhjgEsQvSrmoeWzyo.2U3j.LTkqpxcYwJZgf4aX5zGMifwrde",
                    PhoneNumber = "7804188874",
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(1989, 03, 29),
                    Address = "154 South Gate Blwd",
                    City = "Edmonton",
                    Province = "AB",
                    PostalCode = "T8N3A4"
                },
               new Client()
               {
                   ClientID = 2,
                   EmailAddress = "trevorbelmont123@gmail.com",
                   Password = "$2a$11$95Aao/mZ8sq7dimAwqRoS.ZWdK0Id7X6cqigHuz9kMl./rGbPzhKy",
                   PhoneNumber = "7804442121",
                   FirstName = "Trevor",
                   LastName = "Belmont",
                   DateOfBirth = new DateTime(1880, 02, 25),
                   Address = "1010 White Ave",
                   City = "London",
                   Province = "ON",
                   PostalCode = "Z4A2B1"
               },
               new Client()
               {
                   ClientID = 3,
                   EmailAddress = "richardrich@gmail.com",
                   Password = "$2a$11$vzGYLnnCNrh1ua6.fKhyBuCrpaPKbkC9kMd49Xh.n7EuZtZBmrUpq",
                   PhoneNumber = "7771115454",
                   FirstName = "Richard",
                   LastName = "Rich",
                   DateOfBirth = new DateTime(1999, 12, 03),
                   Address = "2 Century Drive",
                   City = "Edmonton",
                   Province = "AB",
                   PostalCode = "T8N3E1"
               },
               new Client()
               {
                   ClientID = 4,
                   EmailAddress = "brokeasajoke@gmail.com",
                   Password = "$2a$11$ROC9MfwZPA1V2OflUsXNsusWjyMyWWKymHI4Spi2fMqFYuIH1Aivm",
                   PhoneNumber = "7809198888",
                   FirstName = "Bruce",
                   LastName = "Hunter",
                   DateOfBirth = new DateTime(1979, 05, 04),
                   Address = "145 Gateway DR",
                   City = "Edmonton",
                   Province = "AB",
                   PostalCode = "T8N6Y3"
               }

                );


            });


        }
    }
}
