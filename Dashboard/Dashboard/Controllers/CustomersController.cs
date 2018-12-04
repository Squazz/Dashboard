using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Data;
using Dashboard.HelperMethods;
using Dashboard.Models;
using Dashboard.Models.Enums;
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

        public CustomersController(ApplicationDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        [TempData]
        public string StatusMessage { get; set; }
        
        [HttpGet]
        [AuthorizeRoles(Roles.Admin, Roles.Manager)]
        public IActionResult Edit(int? customerId)
        {
            if (customerId == null)
            {
                var userId = _userManager.GetUserId(User);

                var dbUser = _dbContext.Users.Single(x => x.Id == userId);
                List<Customer> customers = _dbContext.Customers.Where(x => x.DeleteDate.HasValue == false).ToList();

                customerId = dbUser.Customer.Id;
            }

            ManageCustomerModel model = CreateCustomerEditModel(customerId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeRoles(Roles.Admin, Roles.Manager)]
        public async Task<IActionResult> Edit(ManageCustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var customer = _dbContext.Customers.Single(x => x.Id == model.Customer.Id);

            customer.Address = model.Customer.Address;
            customer.Att = model.Customer.Att;
            customer.City = model.Customer.City;
            customer.Email = model.Customer.Email;
            customer.VATNumber = model.Customer.VATNumber;
            customer.Zip = model.Customer.Zip;
            customer.Name = model.Customer.Name;
            customer.Phone = model.Customer.Phone;

            if(model.User != null)
            {
                var user = _dbContext.Users.Single(x => x.Id == model.User.Id);
                user.Customer = customer;
                _dbContext.Update(user);                
            }

            await _dbContext.SaveChangesAsync();

            model = CreateCustomerEditModel(model.Customer.Id);

            return View(model);
        }

        [HttpGet]
        [AuthorizeRoles(Roles.Admin)]
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

        private ManageCustomerModel CreateCustomerEditModel(int? customerId)
        {
            Customer customer = _dbContext.Customers.Single(x => x.Id == customerId);
            var users = _dbContext.Users.ToList();
            var model = new ManageCustomerModel()
            {
                Customer = customer,
                Users = users,
                StatusMessage = StatusMessage
            };
            return model;
        }
    }
}
