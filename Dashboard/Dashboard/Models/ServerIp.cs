using System.ComponentModel.DataAnnotations;
using Dashboard.Models.Enums;

namespace Dashboard.Models
{
    // ReSharper disable once InconsistentNaming
    public class ServerIP
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public ServerIpTypeEnum ServerIpType { get; set; }
        [Required]
        public string Ip { get; set; }

        public int ServerId { get; set; }
        public Server Server { get; set; }
    }
}
