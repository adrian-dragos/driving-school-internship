using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? BookingSessionId { get; set; }
        public virtual BookingSession? GetBookingSessions { get; set; }

        public Instructor()
        {

        }

        public Instructor(string name)
        {
            Name = name;
        }
    }
}
