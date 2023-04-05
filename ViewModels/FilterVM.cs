using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsClinicProject.ViewModels
{
    public class FilterVM
    {
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
    }
}