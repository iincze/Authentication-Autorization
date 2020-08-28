using MeloManager.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MeloManager
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(
                    options => options.UseSqlServer(
                        _config.GetConnectionString("EmployeeDBConnection")
                    ));

            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>();

            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();

            //services.AddScoped<IEmployeeRepository, MockEmployeeRepository>();
            // services.AddTransient<IEmployeeRepository, MockEmployeeRepository>();
            //services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>(); 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Errors/Exception");
                //app.UseStatusCodePagesWithRedirects("/Error/{0}");
                //app.UseStatusCodePagesWithReExecute("/Error/{0}");


                //  app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
                //app.UseStatusCodePagesWithRedirects("/Errors/Error/{0}");
                //  app.UseStatusCodePagesWithReExecute("/Errors/Error/{0}");
                app.UseStatusCodePagesWithReExecute("/Errors/Error", "?statusCode={0}");
                //app.UseExceptionHandler("/Errors/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseMvcWithDefaultRoute();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello bello");
            //});
        }
    }
}
