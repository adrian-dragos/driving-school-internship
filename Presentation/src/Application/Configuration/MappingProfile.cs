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
using Application.DTOs.EntityDtos.Car;
using Application.DTOs.EntityDtos.Person.Instructor;
using Application.DTOs.EntityDtos.Person.Student;
using Application.DTOs.EntityDtos.BookingSession;
using Application.DTOs.EntityDtos.Review;

namespace Application.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region BookingSession Mappings
            CreateMap<BookingSession, BookingSessionDto>().ReverseMap();
            CreateMap<BookingSession, BookinSessionInstructorNameCarDto>().ReverseMap();
            CreateMap<BookingSession, BookingSessionWithNamesDto>().ReverseMap();
            CreateMap<BookingSession, CreateBookingSessionDto>().ReverseMap();
            CreateMap<BookingSession, ChangeBookingSessionAvailabilityDto>().ReverseMap();
            #endregion BookingSession

            #region Instructor Mappings
            CreateMap<Instructor, InstructorDto>().ReverseMap();
            CreateMap<Instructor, CreateInstructorDto>().ReverseMap();
            CreateMap<Instructor, ChangeInstructorCarDto>().ReverseMap();
            CreateMap<Instructor, ChangeInstructorEmploymentStatusDto>().ReverseMap();
            #endregion Instructor

            #region Student Mappings
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, CreateStudentDto>().ReverseMap();
            CreateMap<Student, UpdateStudentProfileDto>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            #endregion Student

            #region Car Mappings
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Car, ChangeCarAvailabilityDto>().ReverseMap();
            CreateMap<Car, CreateCarDto>().ReverseMap();
            CreateMap<CarGear, CarGearDto>().ReverseMap();
            CreateMap<CarModelType, CarModelTypeDto>().ReverseMap();
            #endregion Car

            #region Review Mappings
            CreateMap<Review, ReviewDto>().ReverseMap();
            #endregion Review
        }
    }
}
