using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> FilterByDate(DateTime startDate, DateTime endDate)
        {
            return await _context.Appointments
            .Where(x => x.AppointmentDate.Date >= startDate.Date && x.AppointmentDate.Date <= endDate.Date)
            .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> FilterByName(string name)
        {
            return await _context.Appointments
            .Include(x => x.Patient)
            .Where(x => x.Patient.Name.Contains(name)).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetTodayAppointments()
        {
            return await _context.Appointments
            .Where(x => x.AppointmentDate.Date == DateTime.Today.Date).ToListAsync();
        }
    }
}