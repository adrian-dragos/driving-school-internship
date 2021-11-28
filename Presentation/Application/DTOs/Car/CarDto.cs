using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Car
{
    public class CarDto : BaseEntityDto
    {
        //public CarModelType? CarModelType;
        //public CarGear? CarGear { get; set; }
        public DateTime? carFabricationTime { get; set; }
        public string? RegistrationNumber { get; set; }
        public bool? IsAvaibale { get; set; }
    }
}
