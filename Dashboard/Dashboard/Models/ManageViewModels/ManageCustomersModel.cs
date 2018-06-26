using System.Collections.Generic;

namespace Dashboard.Models.ManageViewModels
{
    public class ManageCustomersModel
    {
        public List<Customer> Customers { get; set; }

        public string StatusMessage { get; set; }
    }
}
