
using Microsoft.AspNetCore.Identity;

namespace WebProgramalamaProjem.Models
{
    public class User:IdentityUser
    {
        
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public ICollection<Application> UserApplication { get; set; }
    }
}
