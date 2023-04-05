using PatientsClinicProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace PatientsClinicProject.ViewModels
{
    public class GetAppointmentVM
    {
        public string PatientName { get; set; }
        public byte age { get; set; }
        public string PhoneNumber { get; set; }
        public string DoctorName { get; set; }
        public string Speciality { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int VisitLength { get; set; }


    }
}
