using System.Collections.Generic;

namespace Dashboard.Models.ManageViewModels
{
    public class ManageCustomerModel
    {
        public Customer Customer { get; set; }
        public List<User> Users { get; set; }
        public User User { get; set; }

        public string StatusMessage { get; set; }
    }
}
