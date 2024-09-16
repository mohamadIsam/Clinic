using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IDoctorService
    {
        Task<DoctorDto> GetById(int id);
        Task AddDoctor(DoctorDto doctor);
    }
}