using Application.DTOs.EntityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EntityDto.BookingSession
{
    public class ChangeBookingSessionAvailabilityDto : BaseEntityDto
    {
        public bool IsAvailable { get; set; }
    }
}
