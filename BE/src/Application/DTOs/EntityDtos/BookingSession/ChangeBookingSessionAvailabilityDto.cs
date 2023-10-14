using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EntityDtos.BookingSession
{
    public class ChangeBookingSessionAvailabilityDto
    {
        public bool IsAvailable { get; set; }
        public int? StudentId { get; set; }
    }
}
