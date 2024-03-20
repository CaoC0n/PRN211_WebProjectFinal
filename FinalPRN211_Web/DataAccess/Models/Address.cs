using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Address
    {
        public Address()
        {
            Foods = new HashSet<Food>();
            Reviews = new HashSet<Review>();
        }

        public int LocationId { get; set; }
        public string? LocationName { get; set; }
        public string? StreetAddress { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public DateTime? DatePost { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
