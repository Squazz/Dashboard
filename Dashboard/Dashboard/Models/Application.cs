using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class Application
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FriendlyName { get; set; }

        [Required]
        public int ServerId { get; set; }
        public Server Server { get; set; }

        public ICollection<ApplicationMonitor> ApplicationMonitors { get; set; }
    }
}
