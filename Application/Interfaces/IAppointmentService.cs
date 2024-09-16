using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDto>> GetTodayAppointments();
        Task AddAppointment(AppointmentDto appointment);
        Task CancelAppointment(int appointmentId, string reason);
        Task<IEnumerable<AppointmentDto>> FindAppointmentsByDate(DateTime startDate, DateTime endDate);
        Task<IEnumerable<AppointmentDto>> FindAppointmentsByPatientName(string name);
    }
}