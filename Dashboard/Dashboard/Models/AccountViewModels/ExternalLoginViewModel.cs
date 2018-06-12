using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
