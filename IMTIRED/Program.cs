﻿using Microsoft.EntityFrameworkCore;
using IMTIRED.Components;
using IMTIRED.Services;
using IMTIRED.Utilities;
using IMTIRED.Models;


namespace IMTIRED
{
    //scaffold code:
    //scaffold-dbcontext name="MySqlConnection" pomelo.entityframeworkcore.mysql -outputdir Models -force​
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

            builder.Services.AddScoped<CustomerService>();
            builder.Services.AddScoped<RoomService>();
            builder.Services.AddScoped<RoombookingService>();
            builder.Services.AddScoped<AttractionService>();
            builder.Services.AddScoped<TicketService>();
            builder.Services.AddScoped<TicketbookingService>();

            builder.Services.AddSingleton<UserSession>();


            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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