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

                // ------------------------
                // Seed Data Goes Here
                /* 
                     entity.HasData(
                     new Account(),
                     new Account()
                     );
                */
                // -----------------------
            });

            // Model for Client
            modelBuilder.Entity<Client>(entity =>
            {
                // Collation for username, password, firstname, lastname, emailaddress, city, province, postalcode
                entity.Property(e => e.UserName).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.Password).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.FirstName).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.LastName).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.EmailAddress).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.City).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.Province).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");
                entity.Property(e => e.PostalCode).HasCharSet("utf8mb4").HasCollation("utf8mb4_general_ci");

                // ------------------------
                // Seed Data Goes Here
                /* 
                     entity.HasData(
                     new Client(),
                     new Client()
                     );
                */
                // -----------------------

            });


        }
    }
}
