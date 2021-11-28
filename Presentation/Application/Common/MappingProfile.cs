using Application.DTOs.BookingSession;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.User.Instructor;
using Application.DTOs.User.Student;
using Domain.Entities.User;
using Application.DTOs;

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

        }
    }
}
