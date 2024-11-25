using IMTIRED.Components;
using IMTIRED.Models;
using IMTIRED.Services;
using IMTIRED.Utilities;
using Microsoft.EntityFrameworkCore;

namespace IMTIRED
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddDbContext<TlS2302374webContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"),
                new MySqlServerVersion(new Version(8, 0, 29))));

            // Add services to the container (use Scoped for UserSession)
            builder.Services.AddScoped<CustomerService>();
            builder.Services.AddScoped<RoomService>();
            builder.Services.AddScoped<RoombookingService>();
            builder.Services.AddScoped<AttractionService>();
            builder.Services.AddScoped<TicketService>();
            builder.Services.AddScoped<TicketbookingService>();
            builder.Services.AddScoped<UserSession>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
