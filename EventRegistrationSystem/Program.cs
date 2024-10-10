using EventRegistrationSystem.Models.Data;
using EventRegistrationSystem.Models.Entity;
using EventRegistrationSystem.Repository.Interface;
using EventRegistrationSystem.Repository.Service;
using Microsoft.EntityFrameworkCore;

namespace EventRegistrationSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

            builder.Services.AddDbContext<EventDbContext>(options => options.UseSqlServer(ConnectionString));
            builder.Services.AddScoped<IEvent, EventService>();
            builder.Services.AddScoped<IRegistrationEvent, RegistrationEventsService>();
            builder.Services.AddLogging(config =>
            {
                config.AddConsole(); // Logs to the console
                config.AddDebug();   // Logs to the Debug output window
                                     // You can add other log providers here
            });
            builder.Services.AddScoped<IEmail,EmailService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
