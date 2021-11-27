using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class BookingSessionDto
    {
        public DateTime StartTime { get; set; }
        public bool IsAvailable { get; set; } = false;
    }
}
