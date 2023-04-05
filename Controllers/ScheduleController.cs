using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientsClinicProject.Data;
using PatientsClinicProject.Models;
using PatientsClinicProject.ViewModels;
using System.Globalization;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PatientsClinicProject.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ScheduleController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var schedules = _context.Schedules.Include(x => x.Doctor)
                .OrderBy(a => a.DoctorId).ThenBy(a => a.StartTime)
                .ToList();

            var AllSchedulesVM = _mapper.Map<IEnumerable<GetSchedulesVM>>(schedules);
            return View(AllSchedulesVM);
        }

        [HttpGet]
        public async Task<IActionResult> CreateSchedules()
        {
            SchedulesVM schedulesVM = new SchedulesVM
            {
                Doctors = await _context.Doctors.ToListAsync()
            };
            return View(schedulesVM);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchedules(SchedulesVM schedulesVM) 
        {
            if (!ModelState.IsValid)
            {
                schedulesVM.Doctors = await _context.Doctors.ToListAsync();
                return View(schedulesVM);
            }

            var doctorSchedule = _mapper.Map<Schedule>(schedulesVM);

            await _context.AddAsync(doctorSchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
