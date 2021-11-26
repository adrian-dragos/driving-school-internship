using Application.Interfaces;
using Domain.Entities;
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
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }

        private readonly string _connectionString = @"Server=DESKTOP-912OTND;Database=Test1;Trusted_Connection=True;";

        //public ApplicationContext(DbContextOptions<ApplicationContext> options)
        //: base(options)
        //{
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
