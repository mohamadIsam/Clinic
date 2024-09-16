using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class PatientService(IMapper mapper, IPatientRepository patientRepository) : IPatientService
    {
        public async Task AddPatient(PatientDto patientDto)
        {
            var result = mapper.Map<Patient>(patientDto);
            await patientRepository.AddAsync(result);
        }

        public async Task<PatientDto> GetById(int id)
        {
            var result = await patientRepository.GetByIdAsync(id);
            return mapper.Map<PatientDto>(result);
        }
    }
}