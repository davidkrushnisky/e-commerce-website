using System.ComponentModel.DataAnnotations;

namespace ECommercePlateform.Models
{
    public class User
    {
        public int UserId { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string RoleId { get; set; }

        //1-to-1
        //public Role Role { get; set; }
        //1-to-many
        public ICollection<Order> Orders { get; set; }
    }
}
