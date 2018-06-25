using Microsoft.AspNetCore.Authorization;

namespace Dashboard.HelperMethods
{
    // http://tech-journals.com/jonow/2011/05/19/avoiding-magic-strings-in-asp-net-mvc-authorize-filters
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params string[] roles) : base()
        {
            Roles = string.Join(",", roles);
        }
    }
}
