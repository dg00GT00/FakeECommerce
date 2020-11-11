using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed : IDisposable
    {
        private readonly HttpClient _httpClient;

        public AppIdentityDbContextSeed()
        {
            _httpClient = new HttpClient {BaseAddress = new Uri("https://localhost:5002/fake/")};
        }

        private async Task<AppUser> GenerateFakeUser(string displayName)
        {
            var userJson = await _httpClient.GetStringAsync("user");
            var user = JsonSerializer.Deserialize<dynamic>(userJson);
            return new AppUser
            {
                DisplayName = displayName,
                Email = user.Email,
                UserName = user.Email,
                Address = user.Address
            };
        }

        public async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = await GenerateFakeUser("Bob");
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}