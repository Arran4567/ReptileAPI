using Microsoft.AspNetCore.Identity;
using ReptileAPI.Models;

namespace ReptileAPI.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public virtual List<Animal> Animals { get; set; }
    }
}
