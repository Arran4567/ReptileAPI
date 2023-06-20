using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ReptileAPI.Authentication
{
    public class RolesAttribute : AuthorizeAttribute
    {
        public RolesAttribute(params string[] roles)
        {
            Roles = String.Join(",", roles);
        }
    }
}
