using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        private ApplicationContext _context;
        public CarRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
