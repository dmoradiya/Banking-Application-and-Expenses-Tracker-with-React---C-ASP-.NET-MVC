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
    
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Methods

        public List<Account> GetAccount()
        {
            List<Account> result;

            ValidationException exception = new ValidationException();

            using (BankContext context = new BankContext())
            {
                result = context.Accounts.Include(x => x.Client).Where(x=>x.ClientID == new ClientController().GetClientID() && x.IsActive == true).ToList();
            }
            return result;
        }
        
        // Create New Account For New Client
        public Account CreateAccount(string accountType)
        {

            accountType = new ClientController().StringValidation("Dropdown", accountType);
            using (BankContext context = new BankContext())
            {


                Account newAccount = new Account()
                {
                    ClientID = new ClientController().GetClientCreateID(),
                    AccountType = accountType,
                    AccountBalance = "$0.00",
                    Cashback = "$0.00",
                    AccountDate = DateTime.Today,
                    IsActive = true

                };
                context.Accounts.Add(newAccount);
                context.SaveChanges();
                return newAccount;
            }
        }

        // Add Account For Existing Client
        public Account AddAccount(string accountType)
        {
            ValidationException exception = new ValidationException();
            int clientID = new ClientController().GetClientID();
            accountType = new ClientController().StringValidation("Dropdown", accountType);

            using (BankContext context = new BankContext())
            {
                if (context.Accounts.Any(x => x.ClientID == clientID && x.AccountType == accountType && x.IsActive == false))
                {
                    exception.ValidationExceptions.Add(new Exception($"Your {accountType} account is in Inactive Status. Please Contact Customer Service to Re-Activate"));
                }
                else if (context.Accounts.Count(x => x.ClientID == clientID && x.IsActive == true ) >= 2)
                {
                    exception.ValidationExceptions.Add(new Exception($"You already have all the Accounts"));
                }
                else if (context.Accounts.Any(x => x.ClientID == clientID && x.AccountType == accountType))
                {
                    exception.ValidationExceptions.Add(new Exception($"You already have {accountType} account. Please Choose different account"));
                }
                if (exception.ValidationExceptions.Count > 0)
                {
                    throw exception;
                }

                Account newAccount = new Account()
                {
                    ClientID = clientID,
                    AccountType = accountType,
                    AccountBalance = "$0.00",
                    Cashback = "$0.00",
                    AccountDate = DateTime.Today,
                    IsActive = true

                };
                context.Accounts.Add(newAccount);
                context.SaveChanges();
                return newAccount;
            }
        }

        // Update Deposit Balance
        public Account DepositBalance(string accountID, string transactionValue)
        {
            Account result;
            
            accountID = new ClientController().StringValidation("Dropdown", accountID);
            transactionValue = new ClientController().StringValidation("TransactionValue", transactionValue);

            using (BankContext context = new BankContext())
            {

                result = context.Accounts.Where(x => x.AccountID == int.Parse(accountID)).SingleOrDefault();
                result.AccountBalance += double.Parse(transactionValue);
                context.SaveChanges();
                return result;
            }
        }
        // Update Withdraw Balance
        public Account WithdrawBalance(string accountID, string transactionValue)
        {
            Account result;

            ValidationException exception = new ValidationException();

            accountID = new ClientController().StringValidation("Dropdown", accountID);
            transactionValue = new ClientController().StringValidation("TransactionValue", transactionValue);

            using (BankContext context = new BankContext())
            {
                                
                result = context.Accounts.Where(x => x.AccountID == int.Parse(accountID)).SingleOrDefault();
                double parsedAccountBalance = double.Parse(result.AccountBalance);
                double parsedTransactionValue = double.Parse(transactionValue);
                if ( parsedAccountBalance < parsedTransactionValue)
                {
                    exception.ValidationExceptions.Add(new Exception("You Do Not have enough Balance to Withdraw OR Bill Payment"));
                }

                if (exception.ValidationExceptions.Count > 0)
                {
                    throw exception;
                }
                parsedTransactionValue -= parsedTransactionValue;
                parsedTransactionValue.ToString("C");
                context.SaveChanges();
                return result;
            }
        }

        // Close Account 
        public Account CloseAccount(string accountID)
        {
            Account result;

            accountID = new ClientController().StringValidation("Dropdown", accountID);

            new TransactionController().CloseTransaction(accountID);

            using (BankContext context = new BankContext())
            {

                result = context.Accounts.Include(x=>x.Transactions).Where(x => x.AccountID == int.Parse(accountID)).SingleOrDefault();
                result.IsActive = false;
                context.SaveChanges();
                return result;
            }
        }
    }
}
