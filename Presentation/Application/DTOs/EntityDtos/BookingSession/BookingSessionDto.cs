using Application.DTOs.EntityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EntityDto.BookingSession
{
    public class BookingSessionDto : BaseEntityDto
    {
        public DateTime StartTime { get; set; }
        public bool IsAvailable { get; set; } = true;
        public int InstructorId { get; set; }   
        public int StudentId { get; set; }
    }
}
