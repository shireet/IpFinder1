using IpFinder1.BLL.Implementations;
using IpFinder1.BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IpFinder1.BLL;

public static class DependencyInjection
{
    public static IServiceCollection AddBllLayer(this IServiceCollection services)
    {
        services.AddScoped<IIpFinderManager, IpFinderManager>();
        return services;
    }
}