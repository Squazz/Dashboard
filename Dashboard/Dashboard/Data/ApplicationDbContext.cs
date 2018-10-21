using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Dashboard.Models;

namespace Dashboard.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationMonitor> ApplicationMonitors { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Server> Servers { get; set; }
        public DbSet<ServerIP> ServerIPs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<IdentityUser>().ToTable("AspNetUsers");
            builder.Entity<User>()
                .ToTable("AspNetUsers")
                .HasMany(u => u.Roles)
                .WithOne()
                .HasForeignKey(u => u.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // builder.Entity<UserRole>()
            //     .HasOne(ur => ur.Role)
            //     .WithMany()
            //     .HasForeignKey(ur => ur.RoleId)
            //     .IsRequired()
            //     .OnDelete(DeleteBehavior.Cascade);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
