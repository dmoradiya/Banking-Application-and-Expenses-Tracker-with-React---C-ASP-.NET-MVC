using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone_VV.Models
{
    [Table("Client")]

    public class Client
    {
        public Client()
        {
            Accounts = new HashSet<Account>();
        }

        // PK - ClientID - int(10) NOT NULL
        [Key]
        [Column(TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientID { get; set; }

        // EmailAddress varchar(100) NOT NULL
        [Column(TypeName = "varchar(100)")]
        [Required]
        public string EmailAddress { get; set; }

        // Password varchar(50) NOT NULL
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Password { get; set; }

        // PhoneNumber int(15) NOT NULL
        [Column(TypeName = "char(15)")]
        public string PhoneNumber { get; set; }

        // FirstName varchar(50) NOT NULL
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string FirstName { get; set; }

        // LastName varchar(50) NOT NULL
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string LastName { get; set; }

        // DateOfBirth date NOT NULL
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        // City varchar(100) NOT NULL
        [Column(TypeName = "varchar(100)")]
        [Required]
        public string City { get; set; }

        // Province varchar(50) NOT NULL
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Province { get; set; }

        // PostalCode varchar(50) NOT NULL
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string PostalCode { get; set; }

        // FK Parent reference to Accounts
        [InverseProperty(nameof(Models.Account.Client))]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
