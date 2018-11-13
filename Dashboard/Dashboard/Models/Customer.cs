using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string VATNumber { get; set; }
        public string Address { get; set; }
        public string Att { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        [Phone]
        public string Phone { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Server> Servers { get; set; }
    }
}
