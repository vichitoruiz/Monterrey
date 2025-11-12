using System;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace SSEL.MONTERREY.Licensing;

public static class HWIDGenerator
{
    public static string GetHardwareId()
    {
        string cpuId = GetWmiValue("Win32_Processor", "ProcessorId");
        string diskId = GetWmiValue("Win32_DiskDrive", "SerialNumber");
        string osId = GetWmiValue("Win32_OperatingSystem", "SerialNumber");

        string raw = $"{cpuId}-{diskId}-{osId}";
        var bytes = MD5.HashData(Encoding.UTF8.GetBytes(raw));
        return Convert.ToHexString(bytes);
    }

    private static string GetWmiValue(string wmiClass, string property)
    {
        try
        {
            using var searcher = new ManagementObjectSearcher($"SELECT {property} FROM {wmiClass}");
            foreach (var mo in searcher.Get())
                return mo[property]?.ToString() ?? "UNKNOWN";
        }
        catch { }
        return "UNKNOWN";
    }
}
