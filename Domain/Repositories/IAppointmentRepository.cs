using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IAppointmentRepository : IBaseRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> FilterByDate(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Appointment>> FilterByName(string name);
        Task<IEnumerable<Appointment>> GetTodayAppointments();
    }
}