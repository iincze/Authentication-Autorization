using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication( config =>
                {
                    // We check the cookie that we are Authenticated
                    config.DefaultAuthenticateScheme = "ClientCookie";

                    // When we sign in, we will deal out a cookie
                    config.DefaultSignInScheme = "ClientCookie";

                    // use to check if we are allowed to do something
                    config.DefaultChallengeScheme = "OurServer";

                })
                .AddCookie("ClientCookie")
                .AddOAuth("OurServer", config =>
                {
                    config.ClientId = "client_id";
                    config.ClientSecret = "client_secret";
                    config.CallbackPath = "/oauth/callback";
                    config.AuthorizationEndpoint = "http://localhost:55124/oauth/authorize";
                    config.TokenEndpoint = "http://localhost:55124/oauth/token";
                });

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();  
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
