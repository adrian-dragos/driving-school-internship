using Application.DTOs.EntityDtos.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EntityDtos.Person.Instructor
{
    public class CreateInstructorDto
    {
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public int? CarId { get; set; }
        public bool IsCurrentlyEmployed { get; set; } = false;
    }
}
