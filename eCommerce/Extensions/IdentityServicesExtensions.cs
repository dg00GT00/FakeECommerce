using Core.Entities.Identity;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Extensions
{
    public static class IdentityServicesExtensions
    {
        /// <summary>
        /// Identity services to user implementation
        /// </summary>
        /// <param name="s">the service collection</param>
        /// <returns>the service collection</returns>
        public static IServiceCollection AddIdentityServices(this IServiceCollection s)
        {
            var builder = s.AddIdentityCore<AppUser>();
            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddEntityFrameworkStores<AppIdentityDbContext>();
            builder.AddSignInManager<SignInManager<AppUser>>();

            s.AddAuthentication(); // Authentication to SignInManager 

            return s;
        }
    }
}