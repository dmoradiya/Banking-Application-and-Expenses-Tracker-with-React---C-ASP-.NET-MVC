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

                // ------------------------
                // Seed Data Goes Here
               /* 
                    entity.HasData(
                    new Transaction(),
                    new Transaction()
                    );
               */
                // -----------------------

            });

            // Model for Account
            modelBuilder.Entity<Account>(entity =>
            {
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
                     { }
                     );

            });

            // Model for Client
            modelBuilder.Entity<Client>(entity =>
            {
                // Collation for username, password, firstname, lastname, emailaddress, city, province, postalcode
                entity.Property(e => e.Password).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.FirstName).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.LastName).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.EmailAddress).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.City).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.Province).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.PostalCode).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");


                     entity.HasData(
                     new Client()
                     {
                        ClientID = 1,
                        EmailAddress = "johndoe123@gmail.com",
                        Password = "john123",
                        PhoneNumber = 7804188874,
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
                        PhoneNumber = 7804442121,
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
                        Password = "rich123",
                        PhoneNumber = 7771115454,
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
                        Password = "broke123",
                        PhoneNumber = 7809198888,
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
