using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientsClinicProject.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required, MaxLength(40)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Speciality { get; set; }

        [Required, MaxLength(14), Phone]
        public string Phone { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public int ClinicId { get; set; }

        public Clinic Clinic { get; set; }

        public IEnumerable<Schedule> Schedules { get; set; }
    }
}
