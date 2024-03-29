﻿using Domain.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        public Task<Student> GetStudentByEmail(string email);
    }
}
