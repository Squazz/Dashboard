
namespace Dashboard.Models
{
    public class ApplicationMonitor
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public int ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}
