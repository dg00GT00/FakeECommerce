using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        // public AppIdentityDbContextSeed(string certificatePath, string password)
        // {
        //     _httpClient = ConfigureHttpClient(certificatePath, password);
        // }

        // private static HttpClient ConfigureHttpClient(string certificatePath, string password)
        // {
        //     var handler = new HttpClientHandler();
        //     handler.ClientCertificates.Add(new X509Certificate2("/home/dggt/CA/client/certs/netwebappclient.pfx",
        //         "viper1081"));
        //     return new HttpClient(handler) {BaseAddress = new Uri("https://localhost:5002/fake/")};
        // }

        // private async Task<AppUser> GenerateFakeUser(string displayName)
        // {
        //     var userJson = await _httpClient.GetStringAsync("user");
        //     var user = JsonSerializer.Deserialize<dynamic>(userJson);
        //     return new AppUser
        //     {
        //         DisplayName = displayName,
        //         Email = user.Email,
        //         DisplayName = user.Email,
        //         Address = user.Address
        //     };
        // }

        public async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Bob",
                    Email = "bob@test.com",
                    UserName = "bob@test.com",
                    Address = new Address
                    {
                        FirstName = "Bob",
                        LastName = "Bobbity",
                        Street = "10 The Street",
                        City = "New York",
                        State = "NY",
                        ZipCode = "90210"
                    }
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}