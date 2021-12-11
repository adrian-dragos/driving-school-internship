using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configuration.Entities
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(
                new Car
                {
                    Id = 1,
                    CarModelType = CarModelType.DaciaLogan,
                    CarGear = CarGear.Manual,
                    CarFabricationTime = new DateTime(
                        Convert.ToInt32(2015),
                        Convert.ToInt32(08),
                        1),
                    RegistrationNumber = "TM 152",
                    IsAvailable = false,
                },
                new Car
                {
                    Id = 2,
                    CarModelType = CarModelType.DaciaSandero,
                    CarGear = CarGear.Manual,
                    CarFabricationTime = new DateTime(
                        Convert.ToInt32(2017),
                        Convert.ToInt32(02),
                        1),
                    RegistrationNumber = "TM 824",
                    IsAvailable = false,
                },
                new Car
                {
                    Id = 3,
                    CarModelType = CarModelType.SkodaFabia,
                    CarGear = CarGear.Manual,
                    CarFabricationTime = new DateTime(
                        Convert.ToInt32(2016),
                        Convert.ToInt32(02),
                        1),
                    RegistrationNumber = "TM 046",
                    IsAvailable = true,
                },
                new Car
                {
                    Id = 4,
                    CarModelType = CarModelType.SkodaRoomster,
                    CarGear = CarGear.Automatic,
                    CarFabricationTime = new DateTime(
                        Convert.ToInt32(2017),
                        Convert.ToInt32(03),
                        1),
                    RegistrationNumber = "TM 055",
                    IsAvailable = false,
                },
                new Car
                {
                    Id = 5,
                    CarModelType = CarModelType.RenaultZoe,
                    CarGear = CarGear.Electric,
                    CarFabricationTime = new DateTime(
                        Convert.ToInt32(2020),
                        Convert.ToInt32(02),
                        1),
                    RegistrationNumber = "AR 552",
                    IsAvailable = false,
                }
                );

        }
    }
}
