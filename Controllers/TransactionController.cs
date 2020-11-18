using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone_VV.Models;
using Capstone_VV.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capstone_VV.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public static int accountCreateID;

        // Methods
        public List<Transaction> GetTransactions()
        {
            List<Transaction> result;
            using (BankContext context = new BankContext())
            {
                result = context.Transactions.Include(x => x.Account).Where(x => x.AccountID == new AccountController().GetAccountID()).ToList();
            }
            return result;
        }

        public Transaction CreateDeposit(int accountID, string transactionSource, string transactionCategory, double transactionValue, DateTime transactionDate)
        {
            ValidationException exception = new ValidationException();


            using (BankContext context = new BankContext())
            {

                if (exception.ValidationExceptions.Count > 0)
                {
                    throw exception;
                }

                Transaction newDeposit = new Transaction()
                {
                    AccountID = new AccountController().GetAccountID(),
                    TransactionSource = transactionSource,
                    TransactionCategory = transactionCategory,
                    TransactionValue = transactionValue,
                    TransactionDate = transactionDate

                };
                context.Transactions.Add(newDeposit);
                context.SaveChanges();
                return newDeposit;
            }

        }


    }
}
