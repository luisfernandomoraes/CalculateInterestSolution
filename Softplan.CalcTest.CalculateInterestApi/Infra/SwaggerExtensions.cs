﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace Softplan.CalcTest.CalculateInterestApi.Infra
{

    /// <summary>
    /// Classe responsável por adicionar o middleware do Swagger na aplicação.
    /// </summary>
    public static class SwaggerExtensions
    {
        /// <summary>
        /// Registra o serviço do Swagger no container da aplicação.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            var thisAssembly = typeof(Program).Assembly;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "API",
                    Description = "API para cálculo de juros",
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

        /// <summary>
        /// Habilita a UI do Swagger.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
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
