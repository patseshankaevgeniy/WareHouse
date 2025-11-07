using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using WareHouse.Api.Dtos.AutoMappers;
using WareHouse.Api.Infrastructure.Middleware;
using WareHouse.Application;
using WareHouse.Persistence;

namespace WareHouse.Api;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(_configuration)
            .CreateLogger();

        Log.Information("Starting up");
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Application dependencies
        services.AddApplicationDependencies()
                .AddPersistenceDependencies(_configuration);

        // Api configuration
        services.AddControllers();
        services.AddCors(opt => opt.AddDefaultPolicy(b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

        // Mappers
        services.AddAutoMapper(typeof(DepartmentDtoAutoMapper), typeof(ProductDtoAutoMapper), typeof(WorkerDtoAutoMapper));

        // Swagger Configurarion
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1.0", new OpenApiInfo
            {
                Title = "Warehouse Api",
                Version = "v1.0"
            });
            //options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            //{
            //    Name = "Authorization",
            //    Type = SecuritySchemeType.ApiKey,
            //    Scheme = "Bearer",
            //    BearerFormat = "JWT",
            //    In = ParameterLocation.Header,
            //    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
            //});
            //options.AddSecurityRequirement(new OpenApiSecurityRequirement
            //{
            //     {
            //        new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference
            //                {
            //                    Type = ReferenceType.SecurityScheme,
            //                    Id = "Bearer"
            //                }
            //            },
            //            new string[] {}
            //     }
            //});
        });
    }

    public void Configure(IApplicationBuilder builder, ILoggerFactory loggerFactory)
    {
        loggerFactory.AddSerilog();

        builder
            .UseSwagger()
            .UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("../swagger/v1.0/swagger.json", "Api v1.0");
                options.RoutePrefix = "docs";
            })
            .UseHttpsRedirection()
            .UseMiddleware<CustomExceptionHandlerMiddleware>()
            .UseRouting()
            .UseCors()
            .UseAuthentication()
            .UseAuthorization()
            .UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Ok");
                });
            });
    }
}
