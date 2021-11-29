using Application.DTOs.EntityDtos.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EntityDtos.Person.Instructor
{
    public class InstructorDto : PersonDto
    {
        public CarDto? CarDto { get; set; }
    }
}
