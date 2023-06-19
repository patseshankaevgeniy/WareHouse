using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WareHouse.Application.Departments;
using WareHouse.Application.Departments.Models;
using WareHouse.Application.Products;
using WareHouse.Application.Products.Models;
using WareHouse.Application.Workers;
using WareHouse.Application.Workers.Models;

namespace WareHouse.Application
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            // Services
            services.AddScoped<IDepartmentsService, DepartmentsService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IWorkersService, WorkersService>();

            // Mappers
            services.AddAutoMapper(typeof(DepartmentAutoMapper), typeof(ProductAutoMapper));

            // Validators
            services.AddScoped<IValidator<DepartmentDto>, DepartmentDtoValidator>();
            services.AddScoped<IValidator<ProductDto>, ProductDtoValidator>();
            services.AddScoped<IValidator<WorkerDto>, WorkerDtoValidator>();

            return services;
        }
    }
}
