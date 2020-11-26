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
                result = context.Transactions.Include(x => x.Account).Where(x => x.AccountID == int.Parse(id) && x.IsTransactionActive == true && x.Account.IsActive == true).ToList();
            }
            return result;
        }

        public Transaction CreateDeposit(string accountID, string transactionSource, string transactionValue)
        {

            accountID = new ClientController().StringValidation("Dropdown", accountID);
            transactionSource = new ClientController().StringValidation("Dropdown",transactionSource);
            transactionValue = new ClientController().StringValidation("TransactionValue", transactionValue);

            // Update Account Balance in AccountController
            new AccountController().DepositBalance(accountID, transactionValue);

            using (BankContext context = new BankContext())
            {
                Transaction newDeposit = new Transaction()
                {
                    AccountID = int.Parse(accountID),
                    TransactionSource = transactionSource,
                    TransactionCategory = "Deposit",
                    TransactionValue = double.Parse(transactionValue),
                    TransactionDate = DateTime.Today,
                    IsTransactionActive = true

                };
                context.Transactions.Add(newDeposit);
                context.SaveChanges();
                               
                return newDeposit;
            }

        }
        public Transaction CreateWithdraw(string accountID, string transactionValue, string transactionDate, string transactionSource = "Bill Payment", string transactionCategory = "Withdraw")
        {
           

            accountID = new ClientController().StringValidation("Dropdown", accountID);
            transactionCategory = new ClientController().StringValidation("Dropdown", transactionCategory);
            transactionSource = new ClientController().StringValidation("Dropdown", transactionSource);
            transactionValue = new ClientController().StringValidation("TransactionValue", transactionValue);
            transactionDate = new ClientController().StringValidation("TransactionDate", transactionDate);

            // Update Account Balance In AccountController
            new AccountController().WithdrawBalance(accountID, transactionValue);

            if (transactionSource == "Bill Payment")
            {
                new AccountController().CashbackBalance(accountID, transactionValue);
            }

            using (BankContext context = new BankContext())
            {
               
                Transaction newWithdraw = new Transaction()
                {
                    AccountID = int.Parse(accountID),
                    TransactionSource = transactionSource,
                    TransactionCategory = transactionCategory,
                    TransactionValue = double.Parse(transactionValue),
                    TransactionDate = DateTime.Parse(transactionDate),
                    IsTransactionActive = true

                };
                context.Transactions.Add(newWithdraw);
                context.SaveChanges();

                return newWithdraw;
            }

        }
        // Close Transaction 
        public List<Transaction> CloseTransaction(string accountID)
        {
            List<Transaction> result;

            accountID = new ClientController().StringValidation("Dropdown", accountID);

            using (BankContext context = new BankContext())
            {
                result = context.Transactions.Include(x => x.Account).Where(x => x.Account.AccountID == int.Parse(accountID)).ToList();

                foreach (Transaction transaction in result)
                {
                    transaction.IsTransactionActive = false;
                }
                
                context.SaveChanges();
                return result;
            }
        }

    }
}
