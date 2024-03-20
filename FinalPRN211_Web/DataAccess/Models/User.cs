using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            Reviews = new HashSet<Review>();
        }

        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public int? Status { get; set; }
        public int? Role { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
