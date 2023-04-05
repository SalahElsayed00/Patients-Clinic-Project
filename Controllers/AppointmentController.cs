using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PatientsClinicProject.Data;
using PatientsClinicProject.Models;
using PatientsClinicProject.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsClinicProject.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AppointmentController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var appointment = _context.Appointments.Include(x=>x.Doctor)
                .OrderBy(a => a.DoctorId).ThenBy(a =>a.AppointmentDate)
                .ToList();

            var getAppointmentVM = _mapper.Map<IEnumerable<GetAppointmentVM>>(appointment);
            return View(getAppointmentVM);
        }

        [HttpGet]
        public async Task<IActionResult> GetByDoctorId(int Id)
        {
            var doctorAppointment = await _context.Appointments
                .Where(x => x.DoctorId == Id)
                .ToListAsync();

            if (doctorAppointment is null)
            {
                ViewData["DoctorNotExist"] = "this doctor not have appointment";
                return View();
            }

            var doctorAppointmentVM = _mapper.Map<IEnumerable<AppointmentDoctorVM>>(doctorAppointment);

            return View(doctorAppointmentVM);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAppointment()
        {
            AppointmentVM appointmentVM = new AppointmentVM
            {
                Doctors = await _context.Doctors.ToListAsync()
            };

            return View(appointmentVM);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment(AppointmentVM appointmentVM)
        {
            var doctors = await _context.Doctors.ToListAsync();
            if (!ModelState.IsValid)
            {
                appointmentVM.Doctors = doctors;
                return View(appointmentVM);
            }

            var doctorAppointments = _context.Schedules.FirstOrDefault(d => d.Doctor.Id == appointmentVM.DoctorId);

            if (doctorAppointments is null)
            {
                ViewData["ErrorSchedule"] = "This doctor not have Schedules";
                appointmentVM.Doctors = doctors;
                return View(appointmentVM);
            }

            if (appointmentVM.AppointmentDate.Date.DayOfWeek == DayOfWeek.Friday)
            {
                ViewData["ErrorFriday"] = "This doctor not work in friday";
                appointmentVM.Doctors = doctors;
                return View(appointmentVM);
            }

            if (appointmentVM.AppointmentDate.Hour < doctorAppointments.StartTime.Hours ||
                appointmentVM.AppointmentDate.Hour > doctorAppointments.EndTime.Hours)
            {
                ViewData["ErrorDate"] = "this time not exist";
                appointmentVM.Doctors = doctors;
                return View(appointmentVM);
            }

            var appointment = _mapper.Map<Appointment>(appointmentVM);

            await _context.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
