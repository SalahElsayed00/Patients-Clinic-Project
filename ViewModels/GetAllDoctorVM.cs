using PatientsClinicProject.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientsClinicProject.ViewModels
{
    public class GetAllDoctorVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        [Display(Name = "Clinic Name")]
        public string ClinicName { get; set; }
    }
}
