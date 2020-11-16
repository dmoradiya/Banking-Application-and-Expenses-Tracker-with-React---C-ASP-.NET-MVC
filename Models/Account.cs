using System;
using System.Collections.Generic;
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
        // FK - ClientID - int(10) NOT NULL
        // AccountType int(2) NOT NULL
        // AccountBalance double(15) NOT NULL
        // AccountInterest double(15) NOT NULL
        // IsActive bool NOT NULL


    }
}
