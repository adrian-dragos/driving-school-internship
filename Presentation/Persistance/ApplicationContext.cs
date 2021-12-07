using Domain.Entities;
using Domain.Entities.Person;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class ApplicationContext : DbContext
    {
        public DbSet<BookingSession> BookingSessions { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }

        //public ApplicationContext()
        //{

        //}
        //private readonly string _connectionString = @"Server=DESKTOP-912OTND;Database=Test1;Trusted_Connection=True;";
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_connectionString);
        //}
    }
}
