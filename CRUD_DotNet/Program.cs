using CRUD_DotNet.Context;
using Microsoft.EntityFrameworkCore;
using System;
using CRUD_DotNet.Services;
using CRUD_DotNet.Services.Interfaces;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace CRUD_DotNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var defaultCulture = new CultureInfo("pt-BR");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            };

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));


            //Adicionar os servicos aqui em baixo

            builder.Services.AddScoped<IEstadoServices,EstadoServices >();

            var app = builder.Build();
            app.UseRequestLocalization(localizationOptions);

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
