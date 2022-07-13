using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using ToDoProject.Application.AutoMapper;
using ToDoProject.Infrastructure.CommandsHandlers.ToDoList;
using ToDoProject.Infrastructure.Repositories;
using ToDoProject.Persistence.Context;

namespace ToDoProject.Api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDoProject.Api", Version = "v1" });
            });

            services.AddAutoMapper(config => config.AddProfile<ToDoListMapper>());

            services.AddScoped<ToDoListRepository>();
            services.AddScoped<ToDoListItemRepository>();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(CreateToDoListCommandHandler).Assembly);

            //change options to use database, update query string in settings
            services.AddDbContext<ToDoListContext>(o => o.UseInMemoryDatabase("TODOS"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDoProject.Api v1"));
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
