using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace PatientsClinicProject.Models
{
    public class Clinic
    {
        public int Id { get; set; }

        [Required, MaxLength(40)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Addreess { get; set; }

        [Required, MaxLength(14), Phone]
        public string Phone { get; set; }

        public IEnumerable<Doctor> Doctors { get; set; }
    }
}
