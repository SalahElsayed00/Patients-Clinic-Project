using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientsClinicProject.Data;
using PatientsClinicProject.Models;
using PatientsClinicProject.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsClinicProject.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DoctorController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var doctors = _context.Doctors
                .Include(x => x.Clinic)
                .OrderBy(x => x.ClinicId)
                .ThenBy(x => x.Name)
                .ThenBy(x => x.Speciality)
                .ToList();

            var allDoctors = _mapper.Map<IEnumerable<GetAllDoctorVM>>(doctors);
            return View(allDoctors);
        }

        [HttpGet]
        public async Task<IActionResult> CreateDoctor()
        {
            var doctorVM = new DoctorVM
            {
                Clinics = await _context.Clinics.ToListAsync(),
            };
            return View(doctorVM);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(DoctorVM doctorVM)
        {
            var clinics = await _context.Clinics.ToListAsync();
            if (!ModelState.IsValid)
            {
                doctorVM.Clinics = clinics;
                return View(doctorVM);
            }

            var findByPhoneNumber = await _context.Doctors.FirstOrDefaultAsync(x => x.Phone == doctorVM.Phone);

            if (findByPhoneNumber is not null)
            {
                ViewData["DoctorExist"] = "this doctor already register";
                doctorVM.Clinics = clinics;
                return View(doctorVM);
            }

            var doctor = _mapper.Map<Doctor>(doctorVM);
            await _context.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction("CreateSchedules", "Schedule");
        }

    }
}
