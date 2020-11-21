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

        
        public Client CreateClient(string email, string password, string phone, string fname, string lname, string dateOfBirth, string address, string city, string province, string postalCode)
        {
            Client result;
           
            ValidationException exception = new ValidationException();

            email =  StringValidation("Email", email);
            password = StringValidation("Password", password);
            phone = StringValidation("Phone", phone);
            fname = StringValidation("Name", fname);
            lname = StringValidation("Name", lname);
            dateOfBirth = StringValidation("DateOfBirth", dateOfBirth);
            address = StringValidation("Address", address);
            city = StringValidation("Name", city);
            province = StringValidation("Province", province);
            postalCode = StringValidation("PostalCode", postalCode);

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
                   DateOfBirth = DateTime.Parse(dateOfBirth),
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
        public string StringValidation(string inputType, string input)
        {
            ValidationException exception = new ValidationException();

            input = !string.IsNullOrWhiteSpace(input) ? input.Trim() : null;

           
            using (BankContext context = new BankContext())
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    exception.ValidationExceptions.Add(new Exception("Please Submit All the Field"));
                }
                else if (inputType == "Email")
                {
                    if (context.Clients.Any(x => x.EmailAddress.ToUpper() == input.ToUpper()))
                    {
                        exception.ValidationExceptions.Add(new Exception("Email Already Exists"));
                    }
                    else
                    {
                        // Citation start : Regex for Email
                        // Link : https://stackoverflow.com/questions/43689934/regex-to-match-email
                        Regex rgx = new Regex(@"^[\w.-]+@(?=[a-z\d][^.]*\.)[a-z\d.-]*[^.]$");
                        // Citation End

                        if (!rgx.IsMatch(input))
                        {
                            exception.ValidationExceptions.Add(new Exception("Please Enter Valid Email Address"));
                        }
                        else
                        {
                            return input;
                        }

                    }
                }
                else if (inputType == "Password")
                {
                    // Citation start : Regex for password
                    // Link : https://stackoverflow.com/questions/46068378/regex-for-complex-password
                    Regex rgx = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()]).{8,}$");
                    // Citation End

                    if (!rgx.IsMatch(input))
                    {
                        exception.ValidationExceptions.Add(new Exception("Please Enter Valid PassWord. Your Password should be at least 8 character long and combination of Uppercase, Lowercase, Number and Special Character"));
                    }
                    else
                    {
                        return input;
                    }
                }
                else if (inputType == "Phone")
                {
                    // Citation start : Regex for Phone
                    // Link : https://stackoverflow.com/questions/18091324/regex-to-match-all-us-phone-number-formats
                    Regex rgx = new Regex(@"^\(?\d{3}\)?-? *\d{3}-? *-?\d{4}$");
                    // Citation End

                    if (!rgx.IsMatch(input))
                    {
                        exception.ValidationExceptions.Add(new Exception("Please Enter Valid PhoneNumber"));
                    }
                    else
                    {
                        return input;
                    }
                }
                else if (inputType == "Name")
                {
                    // Citation start : Regex for First and LastName 
                    // Link : https://stackoverflow.com/questions/51262557/regex-for-first-name
                    Regex rgx = new Regex(@"^([a-zA-Z]+?)([-\s'][a-zA-Z]+)*?$");
                    // Citation End
                    if (!rgx.IsMatch(input))
                    {
                        exception.ValidationExceptions.Add(new Exception("Please Enter Valid Name"));
                    }
                    else
                    {
                        return input;
                    }
                }
                else if (inputType == "DateOfBirth")
                {
                    if (DateTime.Parse(input) >= DateTime.Today)
                    {
                        exception.ValidationExceptions.Add(new Exception("Please Enter Valid Date of Birth"));
                    }
                    else
                    {
                        return input;
                    }
                }
                else if (inputType == "Address")
                {
                    if (input.Length > 150)
                    {
                        exception.ValidationExceptions.Add(new Exception("Maximum length allow for address is 150 Characters only"));
                    }
                    else
                    {
                        return input;
                    }
                }
                else if (inputType == "Province")
                {
                    if (input.Length > 2 )
                    {
                        exception.ValidationExceptions.Add(new Exception("Please Enter Valid Province"));
                    }
                    else
                    {
                        return input;
                    }
                }
                else if (input == "PostalCode")
                {
                    
                    Regex rgx = new Regex(@"^([a-zA-Z]\d[a-zA-Z]( )?\d[a-zA-Z]\d)$");
                    if (!rgx.IsMatch(input))
                    {
                        exception.ValidationExceptions.Add(new Exception("Please Enter Valid Postal Code"));
                    }
                    else
                    {
                        return input;
                    }
                }
               
            }

           

            if (exception.ValidationExceptions.Count > 0)
            {
                throw exception;
            }

            return input;
        }

    }
}
