using System;
using Microsoft.AspNetCore.Identity;

namespace Dashboard.Models
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool RecieveStatusEmails { get; set; }
        public bool Phone { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DeleteDate { get; set; }

        private Customer Customer { get; set; }
    }
}
