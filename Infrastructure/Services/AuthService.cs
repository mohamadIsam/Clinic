
using Application.DTOs;
using Application.Interfaces;
using Domain.Identity;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    public class AuthService(
        UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager,
    IUserRepository userRepository,
    ITokenService tokenService
    ) : IAuthService
    {

        public async Task<string> Login(LoginModelDto model)
        {
            var user = await userRepository.GetUserByEmailAsync(model.Username);
            if (user == null)
                throw new UnauthorizedAccessException();

            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, true);
            if (!result.Succeeded)
                throw new UnauthorizedAccessException();

            var token = tokenService.GenerateToken(user);
            return token;
        }

        public async Task<bool> Register(RegisterModelDto model)
        {
            var user = new ApplicationUser { Id = Guid.NewGuid(), Email = model.Email, UserName = model.Email, NormalizedEmail = model.Email.ToUpper() };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
                return true;
            return false;
        }
    }
}