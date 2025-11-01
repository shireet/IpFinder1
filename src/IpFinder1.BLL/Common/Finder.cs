using System.Net;

namespace IpFinder1.BLL.Common;

public static class Finder 
{
    public static string? FindSmallestFreeIPv4(IEnumerable<string> ipStrings)
    {
        var set = new HashSet<uint>();
        var min = uint.MaxValue;
        foreach (var s in ipStrings)
        {
            if (!IPAddress.TryParse(s, out var ip)) continue;
            if (ip.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork) continue;
            var v = Utils.Ipv4ToUint(ip);
            set.Add(v);
            if (v < min)
                min = v;
        }

        if (set.Count == 0) return null;

        var cur = min;
        while (true)
        {
            if ((cur & 0xFF) == 0)
            {
                if (cur == uint.MaxValue) return null;
                cur++;
                continue;
            }

            if (!set.Contains(cur))
                return Utils.UintToIPv4(cur);

            if (cur == uint.MaxValue) return null;
            cur++;
        }
    }
}