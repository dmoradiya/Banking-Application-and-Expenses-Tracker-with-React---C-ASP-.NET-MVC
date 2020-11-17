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

        
        public static int clientCreateID;
       

        public Client CreateClient(string email, string password, string phone, string fname, string lname, DateTime dateOfBirth, string address, string city, string province, string postalCode)
        {
            Client result;
           
            ValidationException exception = new ValidationException();


            using (BankContext context = new BankContext())
            {
               
                if (exception.ValidationExceptions.Count > 0)
                {
                    throw exception;
                }

                Client newClient = new Client()
                {
                   EmailAddress = email,
                   Password = password,
                   PhoneNumber = phone,
                   FirstName = fname,
                   LastName = lname,
                   DateOfBirth = dateOfBirth,
                   Address = address,
                   City = city,
                   Province = province,
                   PostalCode = postalCode

                };
                context.Clients.Add(newClient);
                context.SaveChanges();

                result = context.Clients.Where(x => x.EmailAddress == email && x.Password == password).SingleOrDefault();
                clientCreateID = result.ClientID;

                return newClient;
            }
        }

        public int GetClientCreateID()
        {
            return clientCreateID;
        }
       
    }
}
