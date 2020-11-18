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
        public static int clientID;
        public static int accountID;
        public List<Account> GetAccount()
        {
            List<Account> result;
            using (BankContext context = new BankContext())
            {
                result = context.Accounts.Include(x => x.Client).Where(x=>x.ClientID == clientID).ToList();
                accountID = result.Select(x => x.AccountID).FirstOrDefault();
            }
            return result;
        }

        public int GetAccountID()
        {
            return accountID;
        }
        public Client ClientAuthorization(string email, string password)
        {
            Client result;
            ValidationException exception = new ValidationException();

            using (BankContext context = new BankContext())
            {
                if (!context.Clients.Any(x => x.EmailAddress.ToLower() == email.ToLower() && x.Password == password))
                {
                    exception.ValidationExceptions.Add(new Exception("You are not allowed to log in please join new account"));
                }

                if (exception.ValidationExceptions.Count > 0)
                {
                    throw exception;
                }

                result = context.Clients.Where(x => x.EmailAddress == email && x.Password == password).SingleOrDefault();
                clientID = result.ClientID;
            }
            return result;
        }
        public Account CreateAccount(string accountType)
        {

            ValidationException exception = new ValidationException();


            using (BankContext context = new BankContext())
            {

                if (exception.ValidationExceptions.Count > 0)
                {
                    throw exception;
                }

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
    }
}
