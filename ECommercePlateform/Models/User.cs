﻿namespace ECommercePlateform.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string RoleId { get; set; }
        public ICollection<int> OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
