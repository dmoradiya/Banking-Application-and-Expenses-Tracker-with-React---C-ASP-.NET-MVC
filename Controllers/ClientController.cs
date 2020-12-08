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


        // Method

        public static int clientID;
        public static int clientCreateID;

        public Client ClientAuthorization(string email, string password) /*Takes in Email and Password from login page, compares if those values exist in the database and match. If not, throw an exception.*/
        {
            Client result;
            ValidationException exception = new ValidationException();

            using (BankContext context = new BankContext())            {
               
                if (string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(password) || (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password)))
                {
                    exception.ValidationExceptions.Add(new Exception("Email and Password are Required"));
                }
               
                else if (!context.Clients.Any(x => x.EmailAddress.ToLower() == email.ToLower()))
                {
                    exception.ValidationExceptions.Add(new Exception("The email and/or password you entered was incorrect. Please try again."));
                }

                if (exception.ValidationExceptions.Count > 0)
                {
                    throw exception;
                }
                // Verify Password with the Database
                result = context.Clients.Where(x => x.EmailAddress.ToLower() == email.ToLower()).SingleOrDefault();
                bool verified = BCrypt.Net.BCrypt.Verify(password, result.Password);

                if (verified)
                {
                    clientID = result.ClientID;
                }
                else
                {
                    exception.ValidationExceptions.Add(new Exception("Wrong Password!. Please try again."));
                }
                if (exception.ValidationExceptions.Count > 0)
                {
                    throw exception;
                }
            }
            return result;
        }
        public int GetClientID() /*Returns the clientID for the Client that logs in, used in AccountController*/
        {
            return clientID;
        }
        public Client CreateClient(string email, string password, string phone, string fname, string lname, string dateOfBirth, string address, string city, string province, string postalCode) /*Takes in a list of variables used to generate a new client.*/
        {
            Client result;
            /*Trim white space and validated output*/
            email =  StringValidation("Email", email); 
            password = StringValidation("Password", password);
            phone = StringValidation("Phone", phone);
            fname = StringValidation("Name", fname);
            lname = StringValidation("Name", lname);
            dateOfBirth = StringValidation("DateOfBirth", dateOfBirth);
            address = StringValidation("Address", address);
            city = StringValidation("City", city);
            province = StringValidation("Province", province);
            postalCode = StringValidation("PostalCode", postalCode);

            using (BankContext context = new BankContext())
            {
                Client newClient = new Client() /*Creates a new client using variables above*/
                {
                   EmailAddress = email,
                   Password = BCrypt.Net.BCrypt.HashPassword(password), /*Hashing password through Bcrypt.net-next*/
                    PhoneNumber = phone,
                   FirstName = fname,
                   LastName = lname,
                   DateOfBirth = DateTime.Parse(dateOfBirth),
                   Address = address,
                   City = city,
                   Province = province,
                   PostalCode = postalCode

                };
                context.Clients.Add(newClient); /*Adds a new Client to the database*/
                context.SaveChanges(); 

                result = context.Clients.Where(x => x.EmailAddress == email).SingleOrDefault();
                bool verified = BCrypt.Net.BCrypt.Verify(password, result.Password);
                if (verified)
                {
                    clientCreateID = result.ClientID;
                }
                

                return newClient;
            }
        }

        public int GetClientCreateID() /*We need an associated ClientID in order to create Accounts.*/
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
               
                if (inputType == "Email")
                {
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        exception.ValidationExceptions.Add(new Exception("Email is Required"));
                    }
                    else if (context.Clients.Any(x => x.EmailAddress.ToUpper() == input.ToUpper()))
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
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        exception.ValidationExceptions.Add(new Exception("Password is Required"));
                    }
                    else if (!rgx.IsMatch(input))
                    {
                        exception.ValidationExceptions.Add(new Exception("Please Enter Valid Password. Your Password should be at least 8 characters long and also be a combination of Uppercase, Lowercase, Numbers and Special Characters"));
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
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        exception.ValidationExceptions.Add(new Exception("Phone Number is Required"));
                    }
                    else if (!rgx.IsMatch(input))
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
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        exception.ValidationExceptions.Add(new Exception("First Name and Last Name is Required"));
                    }
                    else if (!rgx.IsMatch(input))
                    {
                        exception.ValidationExceptions.Add(new Exception("Please Enter Valid Name"));
                    }
                    else
                    {
                        return input;
                    }
                }
                else if (inputType == "TransactionValue")
                {

                    // Citation start : Regex for Transaction Value positve double numbers only
                    // Link : https://stackoverflow.com/questions/9107673/validate-float-number-using-regex-in-c-sharp
                    Regex rgx = new Regex(@"^[0-9]*(?:\.[0-9]+)?$");
                    // Citation End
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        exception.ValidationExceptions.Add(new Exception("Transaction Value is Required"));
                    }
                    else if (!rgx.IsMatch(input))
                    {
                        exception.ValidationExceptions.Add(new Exception("Please Enter Valid Transaction Value"));
                    }
                    else
                    {
                        return input;
                    }
                }
                else if (inputType == "PostalCode")
                {

                    Regex rgx = new Regex(@"^([a-zA-Z]\d[a-zA-Z]( )?\d[a-zA-Z]\d)$");
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        exception.ValidationExceptions.Add(new Exception("Postal Code is Required"));
                    }
                    else if (!rgx.IsMatch(input))
                    {
                        exception.ValidationExceptions.Add(new Exception("Please Enter Valid Postal Code"));
                    }
                    else
                    {
                        return input;
                    }
                }
                else if (inputType == "DateOfBirth")
                {
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        exception.ValidationExceptions.Add(new Exception("Date Of Birth is Required"));
                    }
                    else if (DateTime.Parse(input) > DateTime.Today)
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
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        exception.ValidationExceptions.Add(new Exception("Address is Required"));
                    }
                    else if (input.Length > 150)
                    {
                        exception.ValidationExceptions.Add(new Exception("Maximum length allow for address is 150 Characters only"));
                    }
                    else
                    {
                        return input;
                    }
                }
                else if (inputType == "City")
                {
                    // Citation start : Regex for First and LastName 
                    // Link : https://stackoverflow.com/questions/51262557/regex-for-first-name
                    Regex rgx = new Regex(@"^([a-zA-Z]+?)([-\s'][a-zA-Z]+)*?$");
                    // Citation End
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        exception.ValidationExceptions.Add(new Exception("City is Required"));
                    }
                    else if (!rgx.IsMatch(input))
                    {
                        exception.ValidationExceptions.Add(new Exception("Please Enter Valid City"));
                    }
                    else
                    {
                        return input;
                    }
                }
                else if (inputType == "Province")
                {
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        exception.ValidationExceptions.Add(new Exception("Province is Required"));
                    }
                    else
                    {
                        return input;
                    }
                }
               
                else if (inputType == "Dropdown")
                {
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        exception.ValidationExceptions.Add(new Exception("Please Select from Drop-Down List"));
                    }
                    else
                    {
                        return input;
                    }
                }
               
                else if (inputType == "TransactionDate")
                {
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        exception.ValidationExceptions.Add(new Exception("Transaction Date is Required"));
                    }
                    else if (DateTime.Parse(input) < DateTime.Today)
                    {
                        exception.ValidationExceptions.Add(new Exception("Please Enter Valid Transaction Date"));
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
