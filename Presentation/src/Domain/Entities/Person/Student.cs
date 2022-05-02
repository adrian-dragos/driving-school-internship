using Domain.Entities.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Person
{
    public class Student : Person
    {
        public virtual ICollection<BookingSession>? BookingSessions { get; set; }
        // for now
        public CarGear? GearTypeEnum { get; set; }
    }
}
