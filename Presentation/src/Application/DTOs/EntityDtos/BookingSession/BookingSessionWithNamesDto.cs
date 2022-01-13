using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EntityDtos.BookingSession
{
    public class BookingSessionWithNamesDto : BookingSessionDto
    {
        public string? StudentFirstName { get; set; }
        public string? StudentLastName { get; set; }


        public string? InstructorFirstName { get; set; }
        public string? InstructorLastName { get; set; }
    }
}
