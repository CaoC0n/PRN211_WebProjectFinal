using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Food
    {
        public int FoodId { get; set; }
        public int? LocationId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }
        public int? Price { get; set; }
        public string? ServerTime { get; set; }
        public DateTime? DatePost { get; set; }

        public virtual Address? Location { get; set; }
    }
}
