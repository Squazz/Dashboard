using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Dashboard.Models
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public bool RecieveStatusEmails { get; set; }
        public bool Phone { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime DeleteDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => FirstName + ", " + LastName;

        public int CustomerId { get; set; }
        private Customer Customer { get; set; }
    }
}
