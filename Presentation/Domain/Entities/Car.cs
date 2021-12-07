using Domain.Entities.Common;
using Domain.Entities.Person;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Car : BaseEntity
    {
        public CarModelType? CarModelType { get; set; }
        public CarGear? CarGear { get; set; }
        public DateTime? CarFabricationTime { get; set; }
        public string? RegistrationNumber { get; set; }
        public bool? IsAvailable { get; set; }
        public Instructor? Instructor { get; set; }
    }
}
