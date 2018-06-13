using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class Server
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FriendlyName { get; set; }

        public int CustomerId { get; set; }
        private Customer Customer { get; set; }

        public ICollection<ServerIP> ServerIPs { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
