using System.Collections.Generic;

namespace Dashboard.Models
{
    public class Application
    {
        public int Id { get; set; }
        public string FriendlyName { get; set; }

        public int ServerId { get; set; }
        public Server Server { get; set; }

        public ICollection<ApplicationMonitor> ApplicationMonitors { get; set; }
    }
}
