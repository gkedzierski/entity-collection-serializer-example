namespace EntityCollectionSerializerExample
{
    using System;
    using System.Collections.Generic;
    using EntityCollectionSerializerExample.Data;
    using EntityCollectionSerializerExample.Entities;
    using EntityCollectionSerializerExample.Enums;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

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
            services.AddDbContext<ApplicationDbContext>(context =>
                context.UseSqlServer(Configuration.GetConnectionString("Default"))
            );

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            context.Database.EnsureCreated();
            context.Users.AddRange(new List<User>
            {
                new User {Id = Guid.NewGuid(), UserRoles = new List<UserRole> {UserRole.Manager}},
                new User {Id = Guid.NewGuid(), UserRoles = new List<UserRole> {UserRole.Member, UserRole.Contributor}},
                new User {Id = Guid.NewGuid(), UserRoles = new List<UserRole> {UserRole.Guest}},
            });
            context.SaveChanges();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
