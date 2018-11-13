using System;
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var customer = _dbContext.Customers.Single(x => x.Id == model.Customer.Id);
            var user = _dbContext.Users.Single(x => x.Id == model.User.Id);

            customer.Address = model.Customer.Address;
            customer.Att = model.Customer.Att;
            customer.City = model.Customer.City;
            customer.Email = model.Customer.Email;
            customer.VATNumber = model.Customer.VATNumber;
            customer.Zip = model.Customer.Zip;
            customer.Name = model.Customer.Name;
            customer.Phone = model.Customer.Phone;

            user.Customer = customer;

            _dbContext.Update(user);

            await _dbContext.SaveChangesAsync();

            model.Users = customer.Users.ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int customerId)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Manage/ManageCustomers.cshtml");
            }

            var customer = _dbContext.Customers.Single(x => x.Id == customerId);
            
            customer.DeleteDate = DateTime.Now;

            await _dbContext.SaveChangesAsync();

            return View("~/Views/Manage/ManageCustomers.cshtml");
        }
    }
}
