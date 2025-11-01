using IpFinder1.Presentation.Implementations;
using IpFinder1.Presentation.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IpFinder1.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentationLayer(this IServiceCollection services)
    {
        services.AddScoped<IResultOutput, ResultOutput>();
        return services;
    }
}