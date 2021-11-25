﻿using Application.Dtos;
using Application.DTOs;
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
            CreateMap<Instructor, InstructorDto>().ReverseMap();
            CreateMap<BookingSession, BookingSessionDto>().ReverseMap();
        }
    }
}
