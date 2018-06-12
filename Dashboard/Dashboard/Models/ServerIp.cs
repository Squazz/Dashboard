using Dashboard.Models.Enums;

namespace Dashboard.Models
{
    // ReSharper disable once InconsistentNaming
    public class ServerIP
    {
        public int Id { get; set; }
        public ServerIpTypeEnum ServerIpType { get; set; }
        public string Ip { get; set; }
    }
}
