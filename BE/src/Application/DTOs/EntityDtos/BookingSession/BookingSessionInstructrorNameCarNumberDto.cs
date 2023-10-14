using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EntityDtos.BookingSession
{
    public class BookingSessionInstructrorNameCarNumberDto : BaseEntityDto
    {
        public DateTime StartTime { get; set; }
        public bool IsAvailable { get; set; } = true;
        public int? InstructorId { get; set; }
        public string? InstructorFirstName { get; set; }
        public string? InstructorLastName { get; set; }
        public string? InstructorPhoneNumber { get; set; }
        public string? CarNumber { get; set; }
       
    }
}
