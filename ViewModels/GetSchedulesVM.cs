using System.ComponentModel.DataAnnotations;
using System;

namespace PatientsClinicProject.ViewModels
{
    public class GetSchedulesVM
    {
        public int DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string DoctorName { get; set; }
    }
}
