using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public static class ApplicationService
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile))
                    .AddMediatR(typeof(AssemblyMarker).Assembly);
            return services;
        }
    }
}
