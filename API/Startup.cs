using System;
using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using MediatR;
using MicroserviceDemo.Data.DBContext;
using MicroserviceDemo.Data.Repository;
using MicroserviceDemo.Domain;
using MicroserviceDemo.Services.Command;
using MicroserviceDemo.Services.Handlers;
using MicroserviceDemo.Services.Query;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MicroserviceDemo
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<MovieContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("MovieContext")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(FindAllMovieQuery).Assembly);
            services.AddTransient<IRequestHandler<FindAllMovieQuery, IEnumerable<MovieDto>>, FindAllMovieHandler>();
            services.AddTransient<IRequestHandler<AddMoviesCommand, bool>, AddMovieHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
