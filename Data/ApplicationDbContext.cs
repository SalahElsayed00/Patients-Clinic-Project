using Microsoft.EntityFrameworkCore;
using PatientsClinicProject.Models;
using System.Numerics;
using System.Xml;

namespace PatientsClinicProject.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasIndex(e => e.Phone)
                .IsUnique();
        }
    }
}
