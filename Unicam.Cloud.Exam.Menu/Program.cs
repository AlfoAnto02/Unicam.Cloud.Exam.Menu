using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Unicam.Cloud.Exam.Menu.Application.Abstractions.Services;
using Unicam.Cloud.Exam.Menu.Application.Extensions;
using Unicam.Cloud.Exam.Menu.Application.Factories;
using Unicam.Cloud.Exam.Menu.Application.Services;
using Unicam.Cloud.Exam.Menu.Models.Context;
using Unicam.Cloud.Exam.Menu.Models.Extensions;
using Unicam.Cloud.Exam.Menu.Models.Repositories;
using Unicam.Cloud.Exam.Menu.Web.Extensions;
using Unicam.Cloud.Exam.Menu.Web.Results;

namespace Unicam.Cloud.Exam.Menu {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container and controllers to the container
            builder.Services
                .AddWebServices()
                .AddModelsServices(builder.Configuration)
                .AddApplicationServices();       
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
           

            var app = builder.Build();

            //Extension Method 
            app.AddWebMiddlewares();
            

            app.Run();
        }
    }
}
