using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string VATNumber { get; set; }
        public string Address { get; set; }
        public string Att { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime DeleteDate { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Server> Servers { get; set; }
    }
}
