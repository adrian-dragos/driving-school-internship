using Application.DTOs.EntityDtos.Person.Instructor;
using Application.DTOs.EnumDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EntityDtos.Car
{
    public class CarDto : BaseEntityDto
    {
        public CarModelTypeDto? CarModelType;
        public CarGearDto? CarGear { get; set; }
        public DateTime? CarFabricationTime { get; set; }
        public string? RegistrationNumber { get; set; }
        public bool? IsAvailable { get; set; }
        public InstructorDto? Instructor { get; set; }
    }
}
