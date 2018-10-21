using Microsoft.AspNetCore.Identity;

namespace Dashboard.Models
{
  public class UserRole : IdentityUserRole<string>
  {
    public int Id { get; set; }
    public virtual IdentityRole<string> Role { get; set; }
  }
}