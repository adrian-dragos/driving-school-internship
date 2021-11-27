using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.DTOs.User.Student
{
    public class StudentDto : UserDto
    {
        public int? BookingSessionId { get; set; }
    }
}
