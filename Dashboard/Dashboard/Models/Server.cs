using System.Collections.Generic;

namespace Dashboard.Models
{
    public class Server
    {
        public int Id { get; set; }
        public string FriendlyName { get; set; }

        public int CustomerId { get; set; }
        private Customer Customer { get; set; }

        public ICollection<ServerIP> ServerIPs { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
