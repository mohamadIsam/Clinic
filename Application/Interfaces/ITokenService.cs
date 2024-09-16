
using Domain.Identity;

namespace Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(ApplicationUser user);
        bool ValidateToken(string token);

    }
}