﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Dashboard.Models
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool RecieveStatusEmails { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        [Required]
        public override string Email { get; set; }

        public string FullName => FirstName + ", " + LastName;

        public Customer Customer { get; set; }
    }
}
