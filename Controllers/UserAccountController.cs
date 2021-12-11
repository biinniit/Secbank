using Secbank.Models;
using Secbank.Services;
using Microsoft.AspNetCore.Mvc;

namespace Secbank.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class UserAccountController : ControllerBase
    {
        public UserAccountController()
        {

        }

        // general GET method
        [HttpGet]
        public ActionResult<List<UserAccount>> GetAll()
        {
            return UserAccountService.GetAll();
        }

        // GET method with parameter (validate customer account)
        [HttpGet("{accountNumber}")]
        public ActionResult<UserAccount> Get(string accountNumber)
        {
            Console.WriteLine(accountNumber);
            var userAccount = UserAccountService.GetAll().Find(i => i.AccountNumber == long.Parse(accountNumber));

            if(userAccount == null)
                return NotFound();

            return userAccount;
        }
        
        // general POST method (add user)
        [HttpPost]
        public IActionResult Post(UserAccount userAccount)
        {
            UserAccountService.Add(userAccount.FirstName, userAccount.LastName, userAccount.Balance);
            return CreatedAtAction(nameof(Post), "id: " + UserAccountService.GetAll().Count);
        }

        // GET method (confirm fund availability)
        [HttpGet("confirm")]
        public IActionResult ConfirmBalance(long accountNumber, double amount)
        {
            var userAccount = UserAccountService.GetAll().Find(i => i.AccountNumber == accountNumber);

            if (userAccount == null)
                return NotFound();

            var hasAmount = userAccount.Balance >= (amount + amount * 0.05);

            return CreatedAtAction(nameof(ConfirmBalance), hasAmount);
        }
    }
}
