using IpFinder1.Presentation.Models;

namespace IpFinder1.BLL.Mappers;

public static class IpMapper
{
    public static OutputMessageDto ToPresentation(this string? ip)
    {
        return new OutputMessageDto(ip);
    }
}