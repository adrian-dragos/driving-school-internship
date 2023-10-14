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
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructors");
            builder.HasData(
                    new Instructor
                    {
                        Id = 1,
                        FirstName = "Mihai",
                        LastName = "Ionascu",
                        Email = "mihai.ionascu23@gmail.com",
                        Password = "Instructor1",
                        PhoneNumber = "+40 742 950 144",
                        Birthday = new DateTime(1982, 02, 27),
                        IsCurrentlyEmployed = true,
                        CarId = 4,
                        GearType = "Mecanică"
                    },
                    new Instructor
                    {
                        Id = 2,
                        FirstName = "Cristian",
                        LastName = "Ceboatari",
                        Email = "cristian.ceb@gmail.com",
                        Password = "Instructor1",
                        PhoneNumber = "+40 715 675 614",
                        Birthday = new DateTime(1992, 12, 25),
                        IsCurrentlyEmployed = true,
                        CarId = 2,
                        GearType = "Automată"
                    },
                    new Instructor
                    {
                        Id = 3,
                        FirstName = "Radu",
                        LastName = "Mazur",
                        Email = "radu.mazur88@gmail.com",
                        PhoneNumber = "+40 722 101 021",
                        Password = "Instructor1",
                        Birthday = new DateTime(1988, 08, 17),
                        IsCurrentlyEmployed = true,
                        CarId = 5,
                        GearType = "Automată"
                    },
                    new Instructor
                    {
                        Id = 4,
                        FirstName = "Dionis",
                        LastName = "Agapii",
                        Email = "dionis.agapii@gmail.com",
                        Password = "Instructor1",
                        PhoneNumber = "+40 751 551 100",
                        Birthday = new DateTime(1978, 11, 01),
                        IsCurrentlyEmployed = true,
                        CarId = 1,
                        GearType = "Automată"
                    },
                    new Instructor
                    {
                        Id = 5,
                        FirstName = "Denis",
                        LastName = "Codur",
                        Email = "condur.denis515@gmail.com",
                        PhoneNumber = "+40 712 229 545",
                        Password = "Instructor1",
                        Birthday = new DateTime(1996, 05, 15),
                        IsCurrentlyEmployed = true,
                        CarId = 3,
                        GearType = "Automată"
                    }
                );
        }
    }
}
