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
    public class DoctorService(IMapper mapper, IDoctorRepository doctorRepository) : IDoctorService
    {
        public async Task AddDoctor(DoctorDto doctorDto)
        {
            var doctor = mapper.Map<Doctor>(doctorDto);
            await doctorRepository.AddAsync(doctor);
        }

        public async Task<DoctorDto> GetById(int id)
        {
            var result = await doctorRepository.GetByIdAsync(id);
            return mapper.Map<DoctorDto>(result);
        }
    }
}