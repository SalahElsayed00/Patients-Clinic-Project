using PatientsClinicProject.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;
using System;

namespace PatientsClinicProject.ViewModels
{
    public class AppointmentVM
    {
        [Required, StringLength(100), Display(Name = "Patient ame")]
        public string PatientName { get; set; }

        [Required]
        public byte age { get; set; }

        [Required, StringLength(14), Phone, Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required, Display(Name = "Doctors")]
        public int DoctorId { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }

        [Required, StringLength(100)]
        public string Speciality { get; set; }

        [Required,Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; } = DateTime.Now;

        [DefaultValue(30), Display(Name = "Visit Length")]
        public int VisitLength { get; set; }

        public string Description { get; set; }
    }
}
