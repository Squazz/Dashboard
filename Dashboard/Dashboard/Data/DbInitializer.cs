
using Dashboard.Models;

namespace Dashboard.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            context.SaveChanges();
        }
    }
}
