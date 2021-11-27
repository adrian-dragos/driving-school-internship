using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.BookingSession
{
    public class BookingSessionDto : BaseEntityDto
    {
        public DateTime StartTime { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
