using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone_VV.Models;
using Capstone_VV.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Capstone_VV.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        // Method

        public static int clientID;
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
        public List<Client> GetClient()
        {
            List<Client> results;
            using (BankContext context = new BankContext())
            {
                results = context.Clients.Where(x => x.ClientID == clientID).ToList();
            }
            return results;
        }
    }
}
