using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Cloud.Exam.Menu.Application.Abstractions.Services;
using Unicam.Cloud.Exam.Menu.Application.Services;

namespace Unicam.Cloud.Exam.Menu.Application.Extensions {
    public static class ServiceExtensions {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
            services.AddScoped<IDishService, DishService>();
            services.AddScoped<IDishTypeService, DishTypeService>();


            //Add FluentValidation for validation of the requests.

            services.AddValidatorsFromAssembly(AppDomain.CurrentDomain
                .GetAssemblies()
                .SingleOrDefault(assembly => assembly.GetName().Name == "Unicam.Cloud.Exam.Menu.Application"));
            services.AddFluentValidationAutoValidation();

            return services;
        }
    }
}
