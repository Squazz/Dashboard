using Dashboard.Models.Enums;
using System.Collections.Generic;

namespace Dashboard.Models.ManageViewModels
{
    public class ManageUsersModel
    {
        public List<User> Users { get; set; }
        public List<Customer> Customers { get; set; }
        public List<RoleEnums> Roles { get; set; }

        public string StatusMessage { get; set; }
    }
}
