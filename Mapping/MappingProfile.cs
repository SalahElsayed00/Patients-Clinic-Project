using AutoMapper;
using PatientsClinicProject.Models;
using PatientsClinicProject.ViewModels;
using System.Collections.Generic;

namespace PatientsClinicProject.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AppointmentVM,Appointment>();
            CreateMap<Appointment, AppointmentDoctorVM>();
            CreateMap<SchedulesVM, Schedule>();
            CreateMap<Appointment, GetAppointmentVM>();
            CreateMap<Schedule, GetSchedulesVM>();
            CreateMap<Doctor, DoctorVM>().ReverseMap();
            CreateMap<Doctor, GetAllDoctorVM>();
        }
    }
}
