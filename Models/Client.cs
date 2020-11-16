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
        // Username varchar(50) NOT NULL
        // Password varchar(50) NOT NULL
        // FirstName varchar(50) NOT NULL
        // LastName varchar(50) NOT NULL
        // DateOfBirth date NOT NULL
        // EmailAddress varchar(100) NOT NULL
        // City varchar(100) NOT NULL
        // Province varchar(50) NOT NULL
        // PostalCode varchar(50) NOT NULL

    }
}
