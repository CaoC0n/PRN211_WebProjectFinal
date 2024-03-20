using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int? UserId { get; set; }
        public int? LocationId { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }

        public virtual Address? Location { get; set; }
        public virtual User? User { get; set; }
    }
}
