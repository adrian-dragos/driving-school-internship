using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BookingSession
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public bool IsAvailable { get; set; } = false;
        public virtual ICollection<Instructor>? Insturctors { get; set; }
        public virtual ICollection<Student>? Students { get; set; }
        public static readonly int SessionDurationMin = 90;
        
        public BookingSession()
        {

        }

        //public BookingSession(DateTime stratTime, int instructorId, int sudentId)
        //{
        //    StratTime = stratTime;
        //    InstructorId = instructorId;
        //    SudentId = sudentId;
        //    IsAvailable = true;
        //}
    }
}
