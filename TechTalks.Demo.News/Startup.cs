using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TechTalks.Demo.News.Core;

[assembly: ApiController]

namespace TechTalks.Demo.News
{
    public sealed class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBusinessLogic();

            services.AddControllers();
            services.AddAutoMapper(GetType().Assembly);
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("demo", new OpenApiInfo
                {
                    Title = "TechTalks News Demo API",
                    Version = "demo"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/demo/swagger.json", "demo");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
