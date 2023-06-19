using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WareHouse.Application.Common.Interfaces;
using WareHouse.Persistence.Repositories;

namespace WareHouse.Persistence
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            return services;
        }
    }
}
