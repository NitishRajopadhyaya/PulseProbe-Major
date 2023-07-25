using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace PulseProbe.Model
{
    [PrimaryKey("BookingId")]
    public class BookingModel
    {
        public int BookingId { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public PatientModel Patient { get; set; }
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public DoctorModel Doctor { get; set; }
        public int ClinicId { get; set; }
        [ForeignKey("ClinicId")]
        public HealthCareCenterModel Clinic { get; set;}
        [MaxLength(20)]
        public string Time { get; set; }
        [MaxLength(20)]
        public string BookedDate { get; set; }
    }
}
