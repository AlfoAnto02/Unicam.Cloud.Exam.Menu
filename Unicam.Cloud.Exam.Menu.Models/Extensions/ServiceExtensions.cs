using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Cloud.Exam.Menu.Models.Context;
using Unicam.Cloud.Exam.Menu.Models.Repositories;

namespace Unicam.Cloud.Exam.Menu.Models.Extensions {
    public static class ServiceExtensions {
        public static IServiceCollection AddModelsServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<MyDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("MyDBContext"));
            });
            services.AddScoped<DishRepository>();
            services.AddScoped<DishTypeRepository>();

            return services;
        }
    }
}
