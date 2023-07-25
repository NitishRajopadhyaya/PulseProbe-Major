using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PulseProbe.Model
{
    [PrimaryKey("HealthCareCenterId")]
    public class HealthCareCenterModel
    {
        public int HealthCareCenterId { get; set; }
        [MaxLength(50)]
        public string HealthCareCenterName { get; set; }
        public int LicsenceNumber { get; set; }
        public string PanNumber { get; set; }
        [MaxLength(20)]
        public string Address { get; set; }
        [MaxLength(20)]
        public string state { get; set; }
        [MaxLength(20)]
        public string District { get; set; }
        public int PhoneNumber { get; set; }
        public string Description { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [NotMapped]
        public string HealthCenterImage { get; set; }
        public decimal Laltitude { get; set; }
        public decimal Longitude { get; set; }
        public string Type { get; set; }
    }
}
