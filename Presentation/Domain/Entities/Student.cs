using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }

        public int? BookingSessionId { get; set; }

        public virtual BookingSession? GetBookingSessions { get; set; }
    }
}
