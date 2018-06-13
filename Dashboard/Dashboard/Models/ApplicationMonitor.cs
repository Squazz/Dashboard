
using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class ApplicationMonitor
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }

        public int ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}
