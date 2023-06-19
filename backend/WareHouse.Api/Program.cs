using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using WareHouse.Api;
using WareHouse.Persistence;

namespace WareHouse
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var app = CreateHostBuilder(args).Build();


            try
            {
                using var scope = app.Services.CreateScope();
                var db = scope.ServiceProvider.GetService<ApplicationDbContext>();
                await db.Database.MigrateAsync();
                await SeedData.AddDefaultDepartmentsAsync(db);
                await SeedData.AddDefaultProductsAsync(db);
            }
            catch (Exception)
            {
                throw;
            }

            await app.RunAsync();




            //var builder = WebApplication.CreateBuilder(args);

            //    builder.Services.AddControllers();
            //    builder.Services.AddEndpointsApiExplorer();
            //    builder.Services.AddSwaggerGen();

            //    var app = builder.Build();

            //    if (app.Environment.IsDevelopment())
            //    {
            //        app.UseSwagger();
            //        app.UseSwaggerUI();
            //    }

            //    app.UseHttpsRedirection();

            //    app.UseAuthorization();

            //    app.MapControllers();

            //    app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args)
              .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}