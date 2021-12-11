using Domain.Entities.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configuration.Entities
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasData(
                new Student
                {
                    Id = 6,
                    FirstName = "Adrian",
                    LastName = "Dragos",
                    Email = "adrian.dragos28@gmail.com",
                    PhoneNumber = "+40 060 066 144",
                    Birthday = new DateTime(2000, 08, 28)
                },
                new Student
                {
                    Id = 7,
                    FirstName = "Marin",
                    LastName = "Grosu",
                    Email = "grosu.marin41@gmail.com",
                    PhoneNumber = "+40 614 411 421",
                    Birthday = new DateTime(2003, 04, 18)
                },
                new Student
                {
                    Id = 8,
                    FirstName = "Ionut",
                    LastName = "Remetea",
                    Email = "ionut.remetea18@gmail.com",
                    PhoneNumber = "+40 232 525 151",
                    Birthday = new DateTime(1999, 05, 21)
                },
                new Student
                {
                    Id = 9,
                    FirstName = "Alexandru",
                    LastName = "Lungu",
                    Email = "alexandru.lungu2002@gmail.com",
                    PhoneNumber = "+40 513 153 531",
                    Birthday = new DateTime(2002, 03, 07)
                },
                new Student
                {
                    Id = 10,
                    FirstName = "Paul",
                    LastName = "Rus",
                    Email = "paul.rus2003@gmail.com",
                    PhoneNumber = "+40 474 366 386",
                    Birthday = new DateTime(2003, 08, 01)
                }
                );
        }
    }
}
