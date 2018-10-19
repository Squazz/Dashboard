using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Dashboard.Models.ManageViewModels
{
    public class ManageUsersModel
    {
        public List<User> Users { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Tuple<string, string>> Roles { get; set; }
        public List<IdentityUserRole<string>> UserRoles { get; set; }

        public string StatusMessage { get; set; }
    }
}
