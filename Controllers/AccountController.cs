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

        // Methods

        public List<Account> GetAccount() /*Displays the account(s) based on associated ClientID*/
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
                    AccountBalance = 0.00,
                    Cashback = 0.00,
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
            int clientID = new ClientController().GetClientID(); // We need a ClientID to associate with a new Account
            accountType = new ClientController().StringValidation("Dropdown", accountType);

            using (BankContext context = new BankContext())
            {
                if (context.Accounts.Any(x => x.ClientID == clientID && x.AccountType == accountType && x.IsActive == false))
                {
                    exception.ValidationExceptions.Add(new Exception($"Your {accountType} account has been De-Activated. Please Contact Customer Service to Re-Activate your account!"));
                }
                else if (context.Accounts.Count(x => x.ClientID == clientID && x.IsActive == true ) >= 2)
                {
                    exception.ValidationExceptions.Add(new Exception($"You already have both account types"));
                }
                else if (context.Accounts.Any(x => x.ClientID == clientID && x.AccountType == accountType))
                {
                    exception.ValidationExceptions.Add(new Exception($"You already have {accountType} account. Please select a different account type!"));
                }
                if (exception.ValidationExceptions.Count > 0)
                {
                    throw exception;
                }

                Account newAccount = new Account()
                {
                    ClientID = clientID,
                    AccountType = accountType,
                    AccountBalance = 0.00,
                    Cashback = 0.00,
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
                if ( result.AccountBalance < double.Parse(transactionValue))
                {
                    exception.ValidationExceptions.Add(new Exception("Your Balance is too low to do that! Please make a Deposit to increase your Balance!"));
                }

                if (exception.ValidationExceptions.Count > 0)
                {
                    throw exception;
                }
                result.AccountBalance -= double.Parse(transactionValue);
                
                context.SaveChanges();
                return result;
            }
        }
        // Update Cashback Balance
        public Account CashbackBalance(string accountID, string transactionValue)
        {
            Account result;

            /*Trims whitespace and performs validation*/
            accountID = new ClientController().StringValidation("Dropdown", accountID);
            transactionValue = new ClientController().StringValidation("TransactionValue", transactionValue); 

            using (BankContext context = new BankContext())
            {

                result = context.Accounts.Where(x => x.AccountID == int.Parse(accountID)).SingleOrDefault();
               // 5% Cashback on every Bill Payment
                result.Cashback += double.Parse(transactionValue) * 0.05;

                context.SaveChanges();
                return result;
            }
        }

        // Close Account - Sets isActive bool to 0 for both account and associated transactions!
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
