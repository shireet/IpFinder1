using IpFinder1.DAL.Implementations;
using IpFinder1.DAL.Interfaces;
using IpFinder1.DAL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IpFinder1.DAL;

public static class DependencyInjection
{
    public static IServiceCollection AddDalLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<IpFinderSettings>(configuration.GetSection("IpFinderSettings"));
        
        services.AddScoped<IIpParser>(serviceProvider =>
        {
            var options = serviceProvider.GetRequiredService<IOptions<IpFinderSettings>>();
            var settings = options.Value;
            
            if (string.IsNullOrEmpty(settings.FilePath))
            {
                throw new InvalidOperationException("FilePath configuration is missing in appsettings.json");
            }
            
            return new IpParser(settings.FilePath);
        });
        return services;
    }
}