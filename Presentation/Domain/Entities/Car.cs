using Domain.Entities.Common;
using Domain.Entities.User;
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
        public bool? IsAvaibale { get; set; }
        
        public int? InstructorId { get; set; }  
        public virtual Instructor? Instructor {get; set; }
    }
}
