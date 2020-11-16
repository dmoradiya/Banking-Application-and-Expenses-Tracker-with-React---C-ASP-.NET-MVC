using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_VV.Models
{
    [Table("Account")]

    public class Account
    {
        public Account()
        {
            Transactions = new HashSet<Transaction>();
        }

        // PK - AccountID - int(10) NOT NULL
        [Key]
        [Column(TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountID { get; set; }

        // FK - ClientID - int(10) NOT NULL
        [Column(TypeName = "int(10)")]
        [Required]
        public int ClientID { get; set; }

        // AccountType int(2) NOT NULL
        [Column(TypeName = "int(2)")]
        [Required]
        public int AccountType { get; set; }

        // AccountBalance double(15) NOT NULL
        [Column(TypeName = "double(15)")]
        [Required]
        public string AccountBalance { get; set; }

        // AccountInterest double(15) NOT NULL
        [Column(TypeName = "double(15)")]
        [Required]
        public string AccountInterest { get; set; }

        // IsActive bool NOT NULL
        [Column(TypeName = "bool")]
        [Required]
        public string IsActive { get; set; }

        // FK Child Reference to Client
        [ForeignKey(nameof(ClientID))]
        [InverseProperty(nameof(Models.Client.Accounts))]
        public virtual Client Client { get; set; }

        // FK Parent Reference to Borrows
        [InverseProperty(nameof(Models.Transaction.Account))]
        public virtual ICollection<Transaction> Transactions { get; set; }


    }
}
