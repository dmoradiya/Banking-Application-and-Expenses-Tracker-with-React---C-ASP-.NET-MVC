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
            using (BankContext context = new BankContext())
            {
                result = context.Accounts.Include(x => x.Client).Where(x=>x.ClientID == new ClientController().GetClientID() && x.IsActive == true).ToList();
            }
            return result;
        }
             
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
                    AccountInterest = 0.00,
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
                if (result.AccountBalance < double.Parse(transactionValue))
                {
                    exception.ValidationExceptions.Add(new Exception("You Do Not have enough Balance to Withdraw OR Bill Payment"));
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

        // Close Account 
        public Account CloseAccount(string accountID)
        {
            Account result;

            accountID = new ClientController().StringValidation("Dropdown", accountID);

            using (BankContext context = new BankContext())
            {

                result = context.Accounts.Where(x => x.AccountID == int.Parse(accountID)).SingleOrDefault();
               
                result.IsActive = false;
                context.SaveChanges();
                return result;
            }
        }
    }
}
