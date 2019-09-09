using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Reflection;

namespace Softplan.CalcTest.InterestRateApi.Infra
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            var thisAssembly = typeof(Program).Assembly;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "API",
                    Description = "API que retorna a taxa de juros",
                    Contact = new Contact
                    {
                        Name = "Luís Fernando Moraes",
                        Email = "luisfernando.pereira.moraes@gmail.com",
                        Url = "https://github.com/luisfernandomoraes"
                    }
                });

                c.MapType<decimal>(() => new Schema { Type = "number", Format = "decimal" });

                var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Softplayer Calc Test API v1");
                c.RoutePrefix = "swagger";
                c.DocumentTitle = "Softplan Code Challange Calc API v1";
                c.DocExpansion(DocExpansion.List);
            });
            return app;
        }
    }
}