using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MyApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services, such as MVC or Entity Framework, here
            services.AddControllersWithViews();
            services.AddMvc(op=>op.EnableEndpointRouting=false); 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
            app.UseMvcWithDefaultRoute();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
