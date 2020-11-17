using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone_VV.Models;
using Capstone_VV.Models.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone_VV.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BankAPIController : ControllerBase
    {
        [HttpGet("Client")]
        public ActionResult<IEnumerable<Client>> Client_GET()
        {
            return new ClientController().GetClient();
        }
        [HttpPost("Login")]
        public ActionResult<Client> Login_POST(string email, string password)
        {
            ActionResult<Client> result;
            try
            {
                result = new ClientController().ClientAuthorization(email, password);
            }
            catch (ValidationException e)
            {
                string error = "Error(s) During Login: " +
                    e.ValidationExceptions.Select(x => x.Message)
                    .Aggregate((x, y) => x + ", " + y);

                result = BadRequest(error);
            }
            catch (Exception)
            {
                result = StatusCode(500, "Unknown error occurred, please try again later.");
            }
            return result;

        }
        [HttpPost("CreateClient")]
        public ActionResult<Client> CreateClient_POST(string email, string password, string phone, string fname, string lname, DateTime dateOfBirth, string address, string city, string province, string postalCode)
        {
            ActionResult<Client> result;
            try
            {
                result = new ClientController().CreateClient(email, password, phone, fname, lname, dateOfBirth, address, city, province, postalCode);
            }
            catch (ValidationException e)
            {
                string error = "Error(s) During Creation: " +
                    e.ValidationExceptions.Select(x => x.Message)
                    .Aggregate((x, y) => x + ", " + y);

                result = BadRequest(error);
            }
            catch (Exception)
            {
                result = StatusCode(500, "Unknown error occurred, please try again later.");
            }
            return result;

        }

        [HttpPost("CreateAccount")]
        public ActionResult<Account> CreateAccount_POST(string accountType)
        {
            ActionResult<Account> result;
            try
            {
                result = new AccountController().CreateAccount(accountType);
            }
            catch (ValidationException e)
            {
                string error = "Error(s) During Creation: " +
                    e.ValidationExceptions.Select(x => x.Message)
                    .Aggregate((x, y) => x + ", " + y);

                result = BadRequest(error);
            }
            catch (Exception)
            {
                result = StatusCode(500, "Unknown error occurred, please try again later.");
            }
            return result;

        }

    }
}
