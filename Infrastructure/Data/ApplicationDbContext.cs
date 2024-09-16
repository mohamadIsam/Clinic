using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>()
            .HasOne(x => x.Doctor)
            .WithMany(x => x.Appointments);

            modelBuilder.Entity<Appointment>()
            .HasOne(x => x.Patient)
            .WithMany(x => x.Appointments);

            modelBuilder.Entity<Appointment>()
           .HasOne(x => x.Status)
           .WithMany(x => x.Appointments);

            modelBuilder.Entity<AppointmentStatus>().HasData(
                new AppointmentStatus {Id = 1, Name = "Scheduled"},
                new AppointmentStatus {Id = 2, Name = "Completed"},
                new AppointmentStatus {Id = 3, Name = "Canceled"},
                new AppointmentStatus {Id = 4, Name = "Rescheduled"}
            );
        }
    }
}