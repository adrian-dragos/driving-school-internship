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

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InstructorId");

                    b.HasIndex("StudentId");

                    b.ToTable("BookingSessions");
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

                    b.Property<int?>("InstructorId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsAvaibale")
                        .HasColumnType("bit");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InstructorId")
                        .IsUnique()
                        .HasFilter("[InstructorId] IS NOT NULL");

                    b.ToTable("Cars");
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

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Person.Instructor", b =>
                {
                    b.HasBaseType("Domain.Entities.Person.Person");

                    b.ToTable("Instructors", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Person.Student", b =>
                {
                    b.HasBaseType("Domain.Entities.Person.Person");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.BookingSession", b =>
                {
                    b.HasOne("Domain.Entities.Person.Instructor", "Instructors")
                        .WithMany("BookingSessions")
                        .HasForeignKey("InstructorId");

                    b.HasOne("Domain.Entities.Person.Student", "GetStudents")
                        .WithMany("BookingSessions")
                        .HasForeignKey("StudentId");

                    b.Navigation("GetStudents");

                    b.Navigation("Instructors");
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.HasOne("Domain.Entities.Person.Instructor", "Instructor")
                        .WithOne("Car")
                        .HasForeignKey("Domain.Entities.Car", "InstructorId");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Domain.Entities.Person.Instructor", b =>
                {
                    b.HasOne("Domain.Entities.Person.Person", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Person.Instructor", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Person.Student", b =>
                {
                    b.HasOne("Domain.Entities.Person.Person", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Person.Student", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Person.Instructor", b =>
                {
                    b.Navigation("BookingSessions");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Domain.Entities.Person.Student", b =>
                {
                    b.Navigation("BookingSessions");
                });
#pragma warning restore 612, 618
        }
    }
}