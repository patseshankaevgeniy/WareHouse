using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WareHouse.Application.Common.Interfaces;
using WareHouse.Infrastructure.Services;

namespace WareHouse.Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        return services;
    }
}
