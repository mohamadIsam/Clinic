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
    public class DoctorController(IDoctorService doctorService) : ControllerBase
    {

        [HttpGet("GetById/{doctorId}")]
        public async Task<IActionResult> GetById(int doctorId)
        {
            var result = await doctorService.GetById(doctorId);
            return Ok(result);
        }

        [HttpPost("AddDoctor")]
        public async Task<IActionResult> AddDoctor(DoctorDto doctor)
        {
            await doctorService.AddDoctor(doctor);
            return Ok();
        }
    }
}