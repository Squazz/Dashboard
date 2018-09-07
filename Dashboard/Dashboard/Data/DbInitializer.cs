using System;
using System.Collections.Generic;
using Dashboard.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.Migrate();

            if (context.Customers.Any())
            {
                return; // Database has been seeded
            }

            var customers = new List<Customer>
            {
                new Customer()
                {
                    CreateDate = DateTime.Now,
                    Name = "Tapemasters Inc."
                },
                new Customer()
                {
                    CreateDate = DateTime.Now,
                    Name = "Colibo A/S."
                },
            };
            context.AddRange(customers);

            context.SaveChanges();
        }
    }
}
