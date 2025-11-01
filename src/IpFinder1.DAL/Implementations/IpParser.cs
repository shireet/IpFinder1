using IpFinder1.DAL.Interfaces;
using IpFinder1.DAL.Models;

namespace IpFinder1.DAL.Implementations;

public class IpParser(
    string filePath) : IIpParser
{
    public IEnumerable<IpEntity> ParseIpAddress()
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException(filePath);
        }
        var lines = File.ReadAllLines(filePath)
            .Select(l => l.Trim())
            .Where(l => !string.IsNullOrEmpty(l))
            .Select(l => new IpEntity(l));
        return lines; 
    }
}