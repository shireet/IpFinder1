using IpFinder1.DAL.Models;

namespace IpFinder1.DAL.Interfaces;

public interface IIpParser
{
    IEnumerable<IpEntity> ParseIpAddress();
}