using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PulseProbe.Model
{
    public class ClinicModel
    {
        public int ClinicId { get; set; }
        [MaxLength(50)]
        public string ClinicName { get; set; }
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
        public string ClinicImage { get; set; }
        public decimal Laltitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
