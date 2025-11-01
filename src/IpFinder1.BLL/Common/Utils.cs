using System.Net;

namespace IpFinder1.BLL.Common;

public class Utils
{
    public static uint Ipv4ToUint(IPAddress ip)
    {
        var b = ip.GetAddressBytes();
        if (b.Length != 4) throw new ArgumentException("Not IPv4");
        return ((uint)b[0] << 24) | ((uint)b[1] << 16) | ((uint)b[2] << 8) | b[3];
    }

    public static string UintToIPv4(uint v)
    {
        var a = (byte)((v >> 24) & 0xFF);
        var b = (byte)((v >> 16) & 0xFF);
        var c = (byte)((v >> 8) & 0xFF);
        var d = (byte)(v & 0xFF);
        return $"{a}.{b}.{c}.{d}";
    }
}
