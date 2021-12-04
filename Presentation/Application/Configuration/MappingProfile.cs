using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Person;
using Domain.Enums;
using Application.DTOs.EnumDtos;
using Application.DTOs.EntityDto.BookingSession;
using Application.DTOs.EntityDtos.Car;
using Application.DTOs.EntityDtos.Person.Instructor;
using Application.DTOs.EntityDtos.Person.Student;

namespace Application.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region BookingSession Mappings
            CreateMap<BookingSession, BookingSessionDto>().ReverseMap();
            CreateMap<BookingSession, ChangeBookingSessionAvailabilityDto>().ReverseMap();
            #endregion BookingSession

            #region Person Mappings
            CreateMap<Instructor, InstructorDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            #endregion Person

            #region Car Mappings
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Car, ChangeCarAvailabilityDto>().ReverseMap();
            CreateMap<CarGear, CarGearDto>().ReverseMap();
            CreateMap<CarModelType, CarModelTypeDto>().ReverseMap();
            #endregion Car
        }
    }
}
