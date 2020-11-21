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

        public static int transactionCreateID;

        // Methods

        public List<Transaction> GetTransactions(string id)
        {
            ValidationException exception = new ValidationException();
            List<Transaction> result;
            using (BankContext context = new BankContext())
            {
                result = context.Transactions.Include(x => x.Account).Where(x => x.AccountID == int.Parse(id) && x.Account.IsActive == true).ToList();
            }
            return result;
        }

        public Transaction CreateDeposit(string accountID, string transactionSource, string transactionValue)
        {

            accountID = new ClientController().StringValidation("Dropdown", accountID);
            transactionSource = new ClientController().StringValidation("Dropdown",transactionSource);
            transactionValue = new ClientController().StringValidation("TransactionValue", transactionValue);

            using (BankContext context = new BankContext())
            {


                Transaction newDeposit = new Transaction()
                {
                    AccountID = int.Parse(accountID),
                    TransactionSource = transactionSource,
                    TransactionCategory = "Deposit",
                    TransactionValue = double.Parse(transactionValue),
                    TransactionDate = DateTime.Today

                };
                context.Transactions.Add(newDeposit);
                context.SaveChanges();
                               
                return newDeposit;
            }

        }
        public Transaction CreateWithdraw(string accountID, string transactionValue, string transactionDate, string transactionSource = "Bill Payment", string transactionCategory = "Withdraw")
        {


            accountID = new ClientController().StringValidation("Dropdown", accountID);
            transactionValue = new ClientController().StringValidation("TransactionValue", transactionValue);
            transactionDate = new ClientController().StringValidation("TransactionDate", transactionDate);
            transactionSource = new ClientController().StringValidation("Dropdown", transactionSource);
            transactionCategory = new ClientController().StringValidation("Dropdown", transactionCategory);
            

            using (BankContext context = new BankContext())
            {


                Transaction newWithdraw = new Transaction()
                {
                    AccountID = int.Parse(accountID),
                    TransactionSource = transactionSource,
                    TransactionCategory = transactionCategory,
                    TransactionValue = -double.Parse(transactionValue),
                    TransactionDate = DateTime.Parse(transactionDate)

                };
                context.Transactions.Add(newWithdraw);
                context.SaveChanges();

                return newWithdraw;
            }

        }

    }
}
