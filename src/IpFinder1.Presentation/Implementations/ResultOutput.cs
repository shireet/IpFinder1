using IpFinder1.Presentation.Interfaces;
using IpFinder1.Presentation.Models;

namespace IpFinder1.Presentation.Implementations;

public class ResultOutput : IResultOutput
{
    public void Output(OutputMessageDto ip)
    {
        Console.WriteLine("Result: " + ip.Message);
    }
}