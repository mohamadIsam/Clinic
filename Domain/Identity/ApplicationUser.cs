using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Domain.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
    }
}
