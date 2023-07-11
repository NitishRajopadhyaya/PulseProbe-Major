﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PulseProbe.Model
{
    [PrimaryKey("PatientId")]
    public class PatientModel
    {
        public int PatientId { get; set; }
        [MaxLength(50,ErrorMessage ="Name cannot Exceed 50 characters")]
        public string PatientFirstName { get; set; }
        [MaxLength(50, ErrorMessage = "Name cannot Exceed 50 characters")]
        public string PatientLastName { get; set; }
        [Range(0,100,ErrorMessage ="Invalid ,only Number can be stored")]
        public int Age { get; set; }
        [MaxLength(50, ErrorMessage = "Gender cannot Exceed 10 characters")]
        public string Gender { get; set; }
        [MaxLength(50, ErrorMessage = "Address cannot Exceed 50 characters")]
        public string Address { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage ="Phone Number should contain 10 digits")]
        public int PhoneNumber { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string BirthDate { get; set; }
        public string PatientImage { get; set; }

    }
}
