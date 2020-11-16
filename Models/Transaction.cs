using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_VV.Models
{
    [Table("Transaction")]


    public class Transaction
    {

        // PK - TransactionID - int(10) NOT NULL
        [Key]
        [Column(TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionID { get; set; }

        // FK - AccountID - int(10) NOT NULL
        [Column(TypeName = "int(10)")]
        [Required]
        public int AccountID { get; set; }

        // TransactionSource varchar(50) NOT NULL
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string TransactionSource { get; set; }


        // TransactionCategory varchar(30) NOT NULL
        [Column(TypeName = "varchar(30)")]
        [Required]
        public string TransactionCategory { get; set; }

        // TransactionValue double(10) NOT NULL
        [Column(TypeName = "double(10)")]
        [Required]
        public double TransactionValue { get; set; }


        // TransactionDate date NOT NULL
        [Column(TypeName = "date")]
        [Required]
        public DateTime TransactionDate { get; set; }

        // FK Child Reference to Account
        [ForeignKey(nameof(AccountID))]
        [InverseProperty(nameof(Models.Account.Transactions))]

        public virtual Account Account { get; set; }

        public Transaction(int transactionID, int accountID, string transactionSource, string transactionCategory, double transactionValue, DateTime transactionDate)
        {
            TransactionID = transactionID;
            AccountID = accountID;
            TransactionSource = transactionSource;
            TransactionCategory = transactionCategory;
            TransactionValue = transactionValue;
            TransactionDate = transactionDate;
        }
        public Transaction()
        { }
    }
}
