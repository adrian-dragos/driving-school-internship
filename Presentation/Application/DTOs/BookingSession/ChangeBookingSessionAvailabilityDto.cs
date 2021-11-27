using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.BookingSession
{
    public class ChangeBookingSessionAvailabilityDto : BaseEntityDto
    {
        public bool IsAvailable { get; set; }
    }
}
