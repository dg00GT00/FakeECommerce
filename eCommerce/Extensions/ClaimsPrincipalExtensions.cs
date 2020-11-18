using System.Linq;
using System.Security.Claims;

namespace eCommerce.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string RetrieveEmailFromPrincipal(this ClaimsPrincipal user)
        {
            return user?.Claims?.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value;
        }
    }
}