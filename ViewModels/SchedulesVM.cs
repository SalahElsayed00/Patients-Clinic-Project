using PatientsClinicProject.Models;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace PatientsClinicProject.ViewModels
{
    public class SchedulesVM
    {
        [Required]
        public int DayOfWeek { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        public int DoctorId { get; set; }

        public IEnumerable<Doctor> Doctors { get; set; }
    }
}
