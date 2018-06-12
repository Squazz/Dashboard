using System.Collections.Generic;

namespace Dashboard.Models
{
    public class Server
    {
        public ICollection<ServerIP> ServerIPs { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
