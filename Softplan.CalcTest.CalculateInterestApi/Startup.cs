using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Softplan.CalcTest.CalculateInterestApi.Application;
using Softplan.CalcTest.CalculateInterestApi.Domain;
using Softplan.CalcTest.CalculateInterestApi.Infra;

namespace Softplan.CalcTest.CalculateInterestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerDocumentation();

            services.AddScoped<IServiceAddressFactory, ServiceAddressFactory>();
            services.AddScoped<IHttpInterestRateRepository, HttpInterestRateRepository>();
            services.AddScoped<ICompoundInterestService, CompoundInterestService>();
            
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerDocumentation();
            app.UseMvc();
        }
    }
}
