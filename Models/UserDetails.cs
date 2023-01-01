using Microsoft.AspNetCore.Identity;

namespace AlbumProject.Models
{
    public class UserDetails : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }

}
