using Busines.Users;
using DataAcces.DataSixdegreesit;
using Entities.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Configurations
{
    public static class Repositories
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserService>(x=>new UserDTO(x.GetService<PruebaSDContext>()));
            return services;
        }
    }
}
