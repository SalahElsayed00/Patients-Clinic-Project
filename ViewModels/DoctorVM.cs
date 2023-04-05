using PatientsClinicProject.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientsClinicProject.ViewModels
{
    public class DoctorVM
    {
        [Required, StringLength(40)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Speciality { get; set; }

        [Required, StringLength(14), Phone]
        public string Phone { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public int ClinicId { get; set; }

        public IEnumerable<Clinic> Clinics { get; set; }
    }
}
