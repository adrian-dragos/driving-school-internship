﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistance;

#nullable disable

namespace Persistance.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.BookingSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("InstructorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int?>("ReviewId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InstructorId");

                    b.HasIndex("ReviewId")
                        .IsUnique()
                        .HasFilter("[ReviewId] IS NOT NULL");

                    b.HasIndex("StudentId");

                    b.ToTable("BookingSessions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InstructorId = 1,
                            IsAvailable = false,
                            StartTime = new DateTime(2022, 1, 14, 7, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = 7
                        },
                        new
                        {
                            Id = 2,
                            InstructorId = 1,
                            IsAvailable = true,
                            StartTime = new DateTime(2022, 1, 14, 8, 30, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            InstructorId = 1,
                            IsAvailable = true,
                            StartTime = new DateTime(2022, 1, 14, 10, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            InstructorId = 1,
                            IsAvailable = true,
                            StartTime = new DateTime(2022, 1, 14, 11, 30, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            InstructorId = 1,
                            IsAvailable = true,
                            StartTime = new DateTime(2022, 1, 14, 1, 30, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            InstructorId = 1,
                            IsAvailable = true,
                            StartTime = new DateTime(2022, 1, 14, 3, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            InstructorId = 2,
                            IsAvailable = false,
                            StartTime = new DateTime(2022, 1, 11, 4, 30, 0, 0, DateTimeKind.Unspecified),
                            StudentId = 7
                        },
                        new
                        {
                            Id = 8,
                            InstructorId = 2,
                            IsAvailable = false,
                            StartTime = new DateTime(2022, 1, 16, 1, 30, 0, 0, DateTimeKind.Unspecified),
                            StudentId = 7
                        },
                        new
                        {
                            Id = 9,
                            InstructorId = 4,
                            IsAvailable = false,
                            StartTime = new DateTime(2022, 1, 12, 3, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = 7
                        },
                        new
                        {
                            Id = 10,
                            InstructorId = 5,
                            IsAvailable = true,
                            StartTime = new DateTime(2022, 1, 14, 11, 30, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CarFabricationTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CarGear")
                        .HasColumnType("int");

                    b.Property<int?>("CarModelType")
                        .HasColumnType("int");

                    b.Property<bool?>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarFabricationTime = new DateTime(2015, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CarGear = 0,
                            CarModelType = 1,
                            IsAvailable = false,
                            RegistrationNumber = "TM 152"
                        },
                        new
                        {
                            Id = 2,
                            CarFabricationTime = new DateTime(2017, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CarGear = 0,
                            CarModelType = 0,
                            IsAvailable = false,
                            RegistrationNumber = "TM 824"
                        },
                        new
                        {
                            Id = 3,
                            CarFabricationTime = new DateTime(2016, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CarGear = 0,
                            CarModelType = 3,
                            IsAvailable = true,
                            RegistrationNumber = "TM 046"
                        },
                        new
                        {
                            Id = 4,
                            CarFabricationTime = new DateTime(2017, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CarGear = 1,
                            CarModelType = 4,
                            IsAvailable = false,
                            RegistrationNumber = "TM 055"
                        },
                        new
                        {
                            Id = 5,
                            CarFabricationTime = new DateTime(2014, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CarGear = 2,
                            CarModelType = 2,
                            IsAvailable = false,
                            RegistrationNumber = "AR 552"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Person.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GearType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("HasReview")
                        .HasColumnType("bit");

                    b.Property<string>("LongDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("Domain.Entities.Person.Instructor", b =>
                {
                    b.HasBaseType("Domain.Entities.Person.Person");

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCurrentlyEmployed")
                        .HasColumnType("bit");

                    b.HasIndex("CarId")
                        .IsUnique()
                        .HasFilter("[CarId] IS NOT NULL");

                    b.ToTable("Instructors", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthday = new DateTime(1982, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mihai.ionascu23@gmail.com",
                            FirstName = "Mihai",
                            GearType = "Mecanică",
                            LastName = "Ionascu",
                            Password = "Instructor1",
                            PhoneNumber = "+40 742 950 144",
                            CarId = 4,
                            IsCurrentlyEmployed = true
                        },
                        new
                        {
                            Id = 2,
                            Birthday = new DateTime(1992, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "cristian.ceb@gmail.com",
                            FirstName = "Cristian",
                            GearType = "Automată",
                            LastName = "Ceboatari",
                            Password = "Instructor1",
                            PhoneNumber = "+40 715 675 614",
                            CarId = 2,
                            IsCurrentlyEmployed = true
                        },
                        new
                        {
                            Id = 3,
                            Birthday = new DateTime(1988, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "radu.mazur88@gmail.com",
                            FirstName = "Radu",
                            GearType = "Automată",
                            LastName = "Mazur",
                            Password = "Instructor1",
                            PhoneNumber = "+40 722 101 021",
                            CarId = 5,
                            IsCurrentlyEmployed = true
                        },
                        new
                        {
                            Id = 4,
                            Birthday = new DateTime(1978, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "dionis.agapii@gmail.com",
                            FirstName = "Dionis",
                            GearType = "Automată",
                            LastName = "Agapii",
                            Password = "Instructor1",
                            PhoneNumber = "+40 751 551 100",
                            CarId = 1,
                            IsCurrentlyEmployed = true
                        },
                        new
                        {
                            Id = 5,
                            Birthday = new DateTime(1996, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "condur.denis515@gmail.com",
                            FirstName = "Denis",
                            GearType = "Automată",
                            LastName = "Codur",
                            Password = "Instructor1",
                            PhoneNumber = "+40 712 229 545",
                            CarId = 3,
                            IsCurrentlyEmployed = true
                        });
                });

            modelBuilder.Entity("Domain.Entities.Person.Student", b =>
                {
                    b.HasBaseType("Domain.Entities.Person.Person");

                    b.ToTable("Students", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 6,
                            Birthday = new DateTime(2000, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "adrian.dragos28@gmail.com",
                            FirstName = "Adrian",
                            GearType = "Mecanică",
                            LastName = "Dragos",
                            Password = "Student1",
                            PhoneNumber = "+40 060 066 144"
                        },
                        new
                        {
                            Id = 7,
                            Birthday = new DateTime(2003, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "grosu.marin41@gmail.com",
                            FirstName = "Marin",
                            GearType = "Automată",
                            LastName = "Grosu",
                            Password = "User1",
                            PhoneNumber = "+40 614 411 421"
                        },
                        new
                        {
                            Id = 8,
                            Birthday = new DateTime(1999, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ionut.remetea18@gmail.com",
                            FirstName = "Ionut",
                            GearType = "Mecanică",
                            LastName = "Remetea",
                            Password = "Student1",
                            PhoneNumber = "+40 232 525 151"
                        },
                        new
                        {
                            Id = 9,
                            Birthday = new DateTime(2002, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "alexandru.lungu2002@gmail.com",
                            FirstName = "Alexandru",
                            GearType = "Mecanică",
                            LastName = "Lungu",
                            Password = "Student1",
                            PhoneNumber = "+40 513 153 531"
                        },
                        new
                        {
                            Id = 10,
                            Birthday = new DateTime(2003, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "paul.rus2003@gmail.com",
                            FirstName = "Paul",
                            GearType = "Mecanică",
                            LastName = "Rus",
                            Password = "Student1",
                            PhoneNumber = "+40 474 366 386"
                        });
                });

            modelBuilder.Entity("Domain.Entities.BookingSession", b =>
                {
                    b.HasOne("Domain.Entities.Person.Instructor", "Instructors")
                        .WithMany("BookingSessions")
                        .HasForeignKey("InstructorId");

                    b.HasOne("Domain.Entities.Review", "Review")
                        .WithOne("BookingSession")
                        .HasForeignKey("Domain.Entities.BookingSession", "ReviewId");

                    b.HasOne("Domain.Entities.Person.Student", "GetStudents")
                        .WithMany("BookingSessions")
                        .HasForeignKey("StudentId");

                    b.Navigation("GetStudents");

                    b.Navigation("Instructors");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("Domain.Entities.Person.Instructor", b =>
                {
                    b.HasOne("Domain.Entities.Car", "Car")
                        .WithOne("Instructor")
                        .HasForeignKey("Domain.Entities.Person.Instructor", "CarId");

                    b.HasOne("Domain.Entities.Person.Person", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Person.Instructor", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Domain.Entities.Person.Student", b =>
                {
                    b.HasOne("Domain.Entities.Person.Person", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Person.Student", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Domain.Entities.Review", b =>
                {
                    b.Navigation("BookingSession")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Person.Instructor", b =>
                {
                    b.Navigation("BookingSessions");
                });

            modelBuilder.Entity("Domain.Entities.Person.Student", b =>
                {
                    b.Navigation("BookingSessions");
                });
#pragma warning restore 612, 618
        }
    }
}
