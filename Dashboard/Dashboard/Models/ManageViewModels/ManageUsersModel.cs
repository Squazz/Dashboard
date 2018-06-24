using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Models.ManageViewModels
{
    public class ManageUsersModel
    {
        public List<User> Users { get; set; }
        public List<Customer> Customers { get; set; }

        public string StatusMessage { get; set; }
    }
}
