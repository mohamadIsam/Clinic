using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AppointmentController(IAppointmentService appointmentService) : ControllerBase
    {

        [HttpGet("GetTodayAppointments")]
        public async Task<IActionResult> GetTodayAppointments()
        {
            var result = await appointmentService.GetTodayAppointments();
            return Ok(result);
        }

        [HttpPost("AddAppointment")]
        public async Task<IActionResult> AddAppointment(AppointmentDto appointment)
        {
            await appointmentService.AddAppointment(appointment);
            return Ok();
        }

        [HttpPut("CancelAppointment")]
        public async Task<IActionResult> CancelAppointment(int appointmentId, string reason)
        {
            await appointmentService.CancelAppointment(appointmentId, reason);
            return Ok();
        }

        [HttpGet("FilterByDate")]
        public async Task<IActionResult> FilterByDate(DateTime startDate, DateTime endDate)
        {
            var result = await appointmentService.FindAppointmentsByDate(startDate, endDate);
            return Ok(result);
        }

        [HttpGet("FilterByName")]
        public async Task<IActionResult> FilterByName(string name)
        {
            var result = await appointmentService.FindAppointmentsByPatientName(name);
            return Ok(result);
        }

    }
}