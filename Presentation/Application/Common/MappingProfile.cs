using Application.DTOs.BookingSession;
using Application.DTOs.Instructor;
using Application.DTOs.Student;
using Application.DTOs.BookingSession;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{ 
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookingSession, BookingSessionDto>().ReverseMap(); 
            CreateMap<BookingSession, ChangeBookingSessionAvailabilityDto>().ReverseMap();
            
            CreateMap<Instructor, InstructorDto>().ReverseMap();
            CreateMap<Student, InsructorDto>().ReverseMap();
           
        }
    }
}
