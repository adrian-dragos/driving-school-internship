using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Person
{
    public class Instructor : Person
    {
        public int? CarId { get; set; }
        public virtual Car? Car { get; set; }
        public virtual ICollection<BookingSession>? BookingSessions { get; set; }
    }
}
