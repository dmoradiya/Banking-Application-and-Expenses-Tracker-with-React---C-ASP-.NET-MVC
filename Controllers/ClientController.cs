using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

            StringValidation("Email", email);
            StringValidation("Password", password);

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

        // String Validation
        public void StringValidation(string inputType, string input)
        {
            ValidationException exception = new ValidationException();

            input = !string.IsNullOrWhiteSpace(input) ? input.Trim() : null;

            if (string.IsNullOrWhiteSpace(input))
            {
                exception.ValidationExceptions.Add(new Exception($"{input} is not provided"));
            }
            using (BankContext context = new BankContext())
            {
                if (inputType == "Email")
                {
                    if (context.Clients.Any(x => x.EmailAddress.ToUpper() == input.ToUpper()))
                    {
                        exception.ValidationExceptions.Add(new Exception("Email Already Exists"));
                    }
                    else
                    {
                        Regex rgx = new Regex(@"^[\w.-]+@(?=[a-z\d][^.]*\.)[a-z\d.-]*[^.]$");

                        if (!rgx.IsMatch(input))
                        {
                            exception.ValidationExceptions.Add(new Exception("Please Enter Valid Email Address"));
                        }

                    }
                }
                else if (inputType == "Password")
                {
                    Regex rgx = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()]).{8,}$");
                    if (!rgx.IsMatch(input))
                    {
                        exception.ValidationExceptions.Add(new Exception("Please Enter Valid PassWord. Your Password should be at least 8 character long and combination of Uppercase, Lowercase, Number and Special Character"));
                    }
                }
            }



            if (exception.ValidationExceptions.Count > 0)
            {
                throw exception;
            }


        }

    }
}
