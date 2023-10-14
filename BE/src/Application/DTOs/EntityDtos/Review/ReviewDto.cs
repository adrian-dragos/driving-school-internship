using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EntityDtos.Review
{
    public class ReviewDto : BaseEntityDto
    {
        public string? LongDescription { get; set; }
        public string? ShortDescription { get; set; }
        public bool HasReview { get; set; }
        public string? InstructorFirstName { get; set; }
        public string? InstructorLastName { get; set; }
        public DateTime? StartTime { get; set; }
        public string? CarName { get; set; }
    }
}
