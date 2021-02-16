using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindByUserClaimPrincipalWithAddressAsync(this UserManager<AppUser> input,
            ClaimsPrincipal user)
        {
            var email = user.Claims?.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value;

            return await input.Users
                .Include(appUser => appUser.Address)
                .SingleOrDefaultAsync(appUser => appUser.Email == email);
        }

        public static async Task<AppUser> FindByEmailFromClaimPrincipal(this UserManager<AppUser> input,
            ClaimsPrincipal user)
        {
            var email = user.Claims?.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value;
            return await input.Users.SingleOrDefaultAsync(appUser => appUser.Email == email);
        }
    }
}