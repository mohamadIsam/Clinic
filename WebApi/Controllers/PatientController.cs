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
    public class PatientController(IPatientService patientService) : ControllerBase
    {
        [HttpGet("GetById/{patientId}")]
        public async Task<IActionResult> GetById(int patientId)
        {
            var result = await patientService.GetById(patientId);
            return Ok(result);
        }

        [HttpPost("AddPatient")]
        public async Task<IActionResult> AddPatient(PatientDto patient)
        {
            await patientService.AddPatient(patient);
            return Ok();
        }
    }
}