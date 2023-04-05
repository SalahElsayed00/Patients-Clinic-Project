using System.ComponentModel.DataAnnotations;
using System;

namespace PatientsClinicProject.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        [Required]
        public int DayOfWeek { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }
    }
}
