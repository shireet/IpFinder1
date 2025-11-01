using IpFinder1.Presentation.Models;

namespace IpFinder1.Presentation.Interfaces;

public interface IResultOutput
{
    void Output(OutputMessageDto ip);
}