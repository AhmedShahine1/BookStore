using BookStore.Models.Repository;
using library.Models;
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
            services.AddMvc(options =>
        {
            // Disable Endpoint Routing
            options.EnableEndpointRouting = false;
        });
            services.AddSingleton<IBookStoreRepositry<Author>, AuthorRepository>();
            services.AddSingleton<IBookStoreRepositry<Book>, BookRepository>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvcWithDefaultRoute();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
            //app.UseMvcWithDefaultRoute();
            //app.UseRouting();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
