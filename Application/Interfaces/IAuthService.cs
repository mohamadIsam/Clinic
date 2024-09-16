using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Register(RegisterModelDto model);
        Task<string> Login(LoginModelDto model);
    }
}