using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace PatientsClinicProject.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string PatientName { get; set; }

        [Required]
        public byte age { get; set; }

        [Required, MaxLength(14), Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        [Required, MaxLength(100)]
        public string Speciality { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [DefaultValue(30)]
        public int VisitLength { get; set; }

        public string Description { get; set; }
    }
}
