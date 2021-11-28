using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Car
{
    public class ChangeCarAvailabilityDto : BaseEntityDto
    {
        public bool IsAvailable { get; set; }
    }
}
