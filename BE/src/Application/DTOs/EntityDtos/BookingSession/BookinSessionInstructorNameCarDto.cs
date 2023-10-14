using Application.DTOs.EnumDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EntityDtos.BookingSession
{
    public class BookinSessionInstructorNameCarDto : BookingSessionDto
    {
        public string? InstructorFirstName { get; set; }
        public string? InstructorLastName { get; set; }
        public CarGearDto? CarGear { get; set; }
        public CarModelTypeDto? CarModel { get; set; }
    }
}
