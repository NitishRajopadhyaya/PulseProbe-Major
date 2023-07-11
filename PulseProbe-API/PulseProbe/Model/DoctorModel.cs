using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PulseProbe.Model
{
    [PrimaryKey("DoctorId")]
    public class DoctorModel
    {
        
        public int DoctorId { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(20)]
        public string NMCNumber { get; set; }
        //public string Certificate { get; set; }
        [MaxLength(20)]
        public string Degree { get; set; }
        [MaxLength(20)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string  Email { get; set; }
        public int PhoneNumber { get; set; }
        [MaxLength(100)]
        public string Speciality { get; set; }
        [MaxLength(50)]
        public string Qualification { get; set; }
        [MaxLength(10)]
        public string Gender { get; set; }
        public string Description { get; set; }

    }
}
