﻿using Domain.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IInstructorRepository : IBaseRepository<Instructor>
    {
        Task CreateInstructor(Instructor instructor);

        public Task<Instructor> GetInstructorByEmail(string email);
    }
}
