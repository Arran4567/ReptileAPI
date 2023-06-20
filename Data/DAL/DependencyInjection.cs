using Microsoft.Extensions.DependencyInjection;
using ReptileAPI.Data.DAL.WorkUnits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReptileAPI.Data.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWorkUnits(this IServiceCollection services)
        {
            //services.AddTransient<ExampleWorkUnit>();
            services.AddTransient<AnimalWorkUnit>();
            return services;
        }
    }
}
