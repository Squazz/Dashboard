using System.Collections.Generic;

namespace Dashboard.Models.ManageViewModels
{
    public class CreateUserModel
    {
        public User User { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public int CustomerId { get; set; }

        public string StatusMessage { get; set; }
    }
}
