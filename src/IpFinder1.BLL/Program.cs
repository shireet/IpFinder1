using IpFinder1.BLL;
using IpFinder1.BLL.Interfaces;
using IpFinder1.DAL;
using IpFinder1.Presentation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var services = new ServiceCollection();
        services.AddDalLayer(configuration)
                .AddBllLayer()
                .AddPresentationLayer();

        var serviceProvider = services.BuildServiceProvider();
        var ipFinderManager = serviceProvider.GetRequiredService<IIpFinderManager>();
        ipFinderManager.Run(args);
    }
}