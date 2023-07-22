using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PulseProbe.Model
{
    [PrimaryKey("ScheduleId")]
    
    public class TimeScheduleModel
    {
        public int ScheduleId { get; set; }
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public virtual DoctorModel? Doctor{ get; set; } 
        //public DoctorModel Doctor { get; set; }
        public int ClinicId { get; set; }
        [MaxLength(30)]
        public string? StartingTime { get; set; }
        [MaxLength(30)]
        public string? EndingTime { get; set; }
    }
}
