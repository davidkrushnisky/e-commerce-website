using Microsoft.AspNetCore.Identity;

namespace ECommercePlateform.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UsernameChangeLimit { get; set; } = 10;
        public byte[]? ProfilePicture { get; set; }

        //1-to-1
        //public Role Role { get; set; }
        //1-to-many
        public ICollection<Order> Orders { get; set; }

    }
}
