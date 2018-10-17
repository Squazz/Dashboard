using System.Linq;
using System.Threading.Tasks;
using Dashboard.Data;
using Dashboard.Models;
using Dashboard.Models.ManageViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class CustomersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public CustomersController(ApplicationDbContext dbContext, 
            UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [HttpGet]
        public IActionResult Edit(int customerId)
        {
            Customer customer = _dbContext.Customers.Single(x => x.Id == customerId);
            var users = _dbContext.Users.ToList();
            var model = new ManageCustomerModel()
            {
                Customer = customer,
                Users = users,
                StatusMessage = StatusMessage
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ManageCustomerModel model)
        {
            var customer = _dbContext.Customers.Single(x => x.Id == model.Customer.Id);
            var user = _dbContext.Users.Single(x => x.Id == model.User.Id);

            user.Customer = customer;

            _dbContext.Update(user);

            await _dbContext.SaveChangesAsync();

            model.Users = customer.Users.ToList();

            return View(model);
        }
    }
}
