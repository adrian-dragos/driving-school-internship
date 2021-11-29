using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Person
{
    public class Student : Person
    {
        public int? ceva { get; set; }
        public virtual ICollection<BookingSession>? BookingSessions { get; set; }
    }
}
