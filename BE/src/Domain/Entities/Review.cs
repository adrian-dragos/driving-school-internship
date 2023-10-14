using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Review : BaseEntity
    {
        public string? LongDescription { get; set; }
        public string? ShortDescription { get; set; }
        public bool HasReview { get; set; }
        public virtual BookingSession BookingSession { get; set; }
    }
}
