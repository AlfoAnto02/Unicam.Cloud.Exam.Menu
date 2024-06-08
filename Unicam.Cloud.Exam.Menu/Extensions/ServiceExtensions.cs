using Microsoft.OpenApi.Models;
using Unicam.Cloud.Exam.Menu.Web.Results;

namespace Unicam.Cloud.Exam.Menu.Web.Extensions {
    public static class ServiceExtensions {
        public static IServiceCollection AddWebServices(this IServiceCollection services) {

            services.AddControllers()
               .ConfigureApiBehaviorOptions(opt => {
                   opt.InvalidModelStateResponseFactory = (context) => {
                       return new BadRequestResultFactory(context);
                   };
               });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo 
                {
                    Title = "Unicam.Cloud.Exam",
                    Version = "v1",
                    Contact = new OpenApiContact {
                        Name = "Alfonso Antognozzi",
                        Email = string.Empty,
                        Url = new Uri("https://unicamcloudexammenuwebapp.azurewebsites.net"),
                    },
                });
            });
            return services;
        }
    }
}
