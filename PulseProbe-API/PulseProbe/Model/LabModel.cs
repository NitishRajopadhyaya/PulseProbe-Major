using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PulseProbe.Model
{
    [PrimaryKey("LabId")]
    public class LabModel
    {
        public int LabId { get; set; }
        [MaxLength(50)]
        public string LabName { get; set; }
        public int LicsenceNumber { get; set; }
        [MaxLength(20)]
        public string Address { get; set; }
        [MaxLength(20)]
        public string Province { get; set; }
        [MaxLength(20)]
        public string District { get; set; }
        public int PhoneNumber { get; set; }
        public string Description { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        public string Image { get; set; }
    }
}
