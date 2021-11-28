using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.User;
using Domain.Enums;
using Application.DTOs.EnumDtos;
using Application.DTOs.EntityDto.BookingSession;
using Application.DTOs.EntityDtos.Car;
using Application.DTOs.EntityDtos.User.Instructor;
using Application.DTOs.EntityDtos.User.Student;

namespace Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookingSession, BookingSessionDto>().ReverseMap(); 
            CreateMap<BookingSession, ChangeBookingSessionAvailabilityDto>().ReverseMap();
            
            CreateMap<Instructor, InstructorDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();

            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Car, ChangeCarAvailabilityDto>().ReverseMap();
            CreateMap<CarGear, CarGearDto>().ReverseMap();
            CreateMap<CarModelType, CarModelTypeDto>().ReverseMap();

        }
    }
}
