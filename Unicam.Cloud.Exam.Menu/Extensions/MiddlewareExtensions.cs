using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Unicam.Cloud.Exam.Menu.Application.Factories;

namespace Unicam.Cloud.Exam.Menu.Web.Extensions {
    public static class MiddlewareExtensions {
        public static WebApplication? AddWebMiddlewares(this WebApplication? app) {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c=> {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Menu API v1");
            });

            app.UseExceptionHandler(appError => {
                appError.Run(async context => {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null) {
                        var res = ResponseFactory
                            .WithError(contextFeature.Error);
                        await context.Response.WriteAsJsonAsync(
                            res
                            );
                    }
                });
            });

            app.MapControllers();
            return app;
        }
    }
}
