using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using TransFeeCalculator.Application.Interfaces;
using TransFeeCalculator.Application.Models;
using TransFeeCalculator.Application.Services;
using TransFeeCalculator.Application.Validators;
using TransFeeCalculator.Data.Repository;
using TransFeeCalculator.Domain.IRepository;

namespace TransFeeCalculator.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Transaction API",
                    Description = "This endpoints are for the two Tasks. Each task per endpoint"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                s.IncludeXmlComments(xmlPath);
            });
            services.AddMvc().AddFluentValidation();
            services.AddTransient<IValidator<AmountDTO>, AmountDTOValidator>();
            services.AddScoped<IFeesRepository, FeesRepository>();
            services.AddScoped<ICalculateFeeService, CalculateFeeService>();
            services.AddScoped<ITransSurChargeRepository, TransSurChargeRepository>();
            services.AddScoped<ITransSurChargeService, TransSurChargeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transaction Fee Calculator");
                c.RoutePrefix = string.Empty;
            });
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
