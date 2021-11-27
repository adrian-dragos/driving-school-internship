using Application.Dtos.BookingSession;
using Application.DTOs.Instructor;
using Application.DTOs.Student;
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
            CreateMap<Instructor, InstructorDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}
