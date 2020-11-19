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


        // Methods
        public List<Transaction> GetTransactions(string id)
        {
            List<Transaction> result;
            using (BankContext context = new BankContext())
            {
                result = context.Transactions.Include(x => x.Account).Where(x => x.AccountID == int.Parse(id)).ToList();
            }
            return result;
        }

        public Transaction CreateDeposit(string accountID, string transactionSource, string transactionCategory, string transactionValue)
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
                    AccountID = int.Parse(accountID),
                    TransactionSource = transactionSource,
                    TransactionCategory = transactionCategory,
                    TransactionValue = double.Parse(transactionValue),
                    TransactionDate = DateTime.Today

                };
                context.Transactions.Add(newDeposit);
                context.SaveChanges();
                               
                return newDeposit;
            }

        }

        

    }
}
