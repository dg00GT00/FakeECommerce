using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity
{
    [Table("AppUser", Schema = "Dev")]
    public class AppUser : IdentityUser
    {
        public string? DisplayName { get; set; }
        public Address? Address { get; set; }
    }
}