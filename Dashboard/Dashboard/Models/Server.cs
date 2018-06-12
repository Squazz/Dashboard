using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Models
{
    public class Server
    {
        public ICollection<ServerIP> ServerIPs { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
