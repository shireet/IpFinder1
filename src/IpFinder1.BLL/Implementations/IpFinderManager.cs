using IpFinder1.BLL.Common;
using IpFinder1.BLL.Interfaces;
using IpFinder1.BLL.Mappers;
using IpFinder1.DAL.Interfaces;
using IpFinder1.Presentation.Interfaces;

namespace IpFinder1.BLL.Implementations;

public class IpFinderManager(
    IIpParser ipParser,
    IResultOutput resultOutput) : IIpFinderManager
{
    public void Run(string[] args)
    {
        try
        {
            var ipLines = ipParser.ParseIpAddress()?.ToList() ?? [];

            if (ipLines.Count == 0)
                throw new InvalidOperationException("No IP addresses found.");

            var ipAddresses = ipLines.Select(x => x.Ip);

            var result = Finder.FindSmallestFreeIPv4(ipAddresses);
            
            resultOutput.Output(result.ToPresentation());
            
        }
        catch (Exception e)
        {
            resultOutput.Output(e.Message.ToPresentation());
        }
    }
}