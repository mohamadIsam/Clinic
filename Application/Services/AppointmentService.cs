using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;

namespace Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task AddAppointment(AppointmentDto appointmentDto)
        {
            var appointment = _mapper.Map<Appointment>(appointmentDto);
            await _appointmentRepository.AddAsync(appointment);
        }

        public async Task CancelAppointment(int appointmentId, string reason)
        {
            if (appointmentId == 0 && reason == null)
                throw new Exception("invalid-request");
            var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);
            appointment.StatusId = (int)AppointmentStatusEnum.Canceled;
            await _appointmentRepository.UpdateAsync(appointment);
        }

        public async Task<IEnumerable<AppointmentDto>> FindAppointmentsByDate(DateTime startDate, DateTime endDate)
        {
            var result = await _appointmentRepository.FilterByDate(startDate, endDate);
            return _mapper.Map<IEnumerable<AppointmentDto>>(result);
        }

        public async Task<IEnumerable<AppointmentDto>> FindAppointmentsByPatientName(string name)
        {
            var result = await _appointmentRepository.FilterByName(name);
            return _mapper.Map<IEnumerable<AppointmentDto>>(result);
        }

        public async Task<IEnumerable<AppointmentDto>> GetTodayAppointments()
        {
            var result = await _appointmentRepository.GetTodayAppointments();
            return _mapper.Map<IEnumerable<AppointmentDto>>(result);
        }
    }
}